using UnityEngine;

namespace DialogueSystemJadsa
{
    public class Carta : MonoBehaviour{
    
    private SpriteRenderer spriteRenderer;
    private cambio gameManager;
    public int cardID; // ID para identificar el par

        [System.Obsolete]
        void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<cambio>();

    }

    void OnMouseDown()
    {
        gameManager.RevealCard(spriteRenderer, cardID);
    }
}}
