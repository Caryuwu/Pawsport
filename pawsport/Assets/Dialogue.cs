using UnityEngine;
using System.Collections;
using TMPro;

    public class Dialogue : MonoBehaviour
    {
        [SerializeField] private GameObject DialogueMark;
        [SerializeField] private GameObject DialoguePanel;
        [SerializeField] private TMP_Text DialogueText;
        [SerializeField, TextArea(4,6)] private string [] DialogueLines;
private float typingTime = 0.05f;
     private bool IsPlayerInrange;
     private bool didDialogueStart;
     private int lineindex; 
     void Update()
        {
            Debug.Log("Time.timeScale: " + Time.timeScale);
        if (IsPlayerInrange && Input.GetMouseButtonDown(1))
        {
            if(!didDialogueStart)
            {
            StartDialogue();
            }
            else if (DialogueText.text == DialogueLines[lineindex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                DialogueText.text = DialogueLines[lineindex];
            }
        }
        }
        private void StartDialogue(){
 didDialogueStart = true;
       DialoguePanel.SetActive(true);
       DialogueMark.SetActive(false);
       lineindex = 0;
       Time.timeScale = 0f;
       StartCoroutine(ShowLine());
        
        }
      

        private void NextDialogueLine(){
        lineindex ++;
        if(lineindex < DialogueLines.Length){
            StartCoroutine(ShowLine());
        }
        else{
            didDialogueStart = false;
            DialoguePanel.SetActive(false);
            DialogueMark.SetActive(true);
            Time.timeScale = 1f;
        }
        }
        
        private IEnumerator ShowLine(){
            DialogueText.text =string.Empty;
            foreach( char ch in DialogueLines[lineindex]){
                DialogueText.text += ch;
                yield return new WaitForSecondsRealtime (typingTime);
            }
        }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
             IsPlayerInrange = true;
             DialogueMark.SetActive(true);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
         if(collision.gameObject.CompareTag("Player")){
 IsPlayerInrange = false;
 DialogueMark.SetActive(false);
         }
       
    }

        
}

