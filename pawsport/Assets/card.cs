using UnityEngine;
using UnityEngine.UI;
namespace DialogueSystemJadsa
{
    public class card : MonoBehaviour
    {
       [SerializeField] private Image iconImage;
       public Sprite hiddenIconsprite;
       public Sprite Iconsprite;
       public bool isSelected;
       public ControllerCard controller;
       public void OncardClick(){
        controller.Setselected(this);
       }
       public void setIconSprite (Sprite sp){
        Iconsprite =sp;
       }
        public void show(){
            iconImage.sprite = Iconsprite;
            isSelected = true;
        }
        public void Hide(){
            iconImage.sprite=hiddenIconsprite;
            isSelected=false;
        }
    }
}
