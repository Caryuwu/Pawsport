using System.Collections.Generic;
using DialogueSystemJadsa;
using UnityEngine;
    
    public class ControllerCard : MonoBehaviour
    {
        
    
    
     [SerializeField]card cardPreFab;
     [SerializeField]Transform gridTransform;
     [SerializeField] Sprite[] sprites;
     private List<Sprite> spritePairs;

     private void Start()
     {
        PrepareSprites();
        CreateCard();
     }
     private void PrepareSprites(){
        spritePairs= new List<Sprite>();
        for (int i=0; i <sprites.Length;i++){
            spritePairs.Add(sprites[i]);
            spritePairs.Add(sprites[i]);
        }
        ShuffleSprites(spritePairs);
        
            }
            void CreateCard(){
                for(int i=0; i< spritePairs.Count; i++){
                    card card = instantiate(cardPreFab, gridTransform);
                    card.setIconSprite(spritePairs[i]);
                    card.controller=this;
                }
            }
    public void Setselected(card card){
        if(!card.isSelected==false){
            card.show();
        }
    }
    private card instantiate(card cardPreFab, Transform gridTransform)
    {
        throw new System.NotImplementedException();
    }

    void ShuffleSprites(List<Sprite> spriteList){
            for (int i= spriteList.Count - 1; 1>0;i--){
                int randomIndex= Random.Range(0,i+1);
                Sprite temp =spriteList[i];
                spriteList[i]=spriteList[randomIndex];
                spriteList[randomIndex]=temp;
        }
     }
    }

