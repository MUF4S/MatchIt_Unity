using UnityEngine;
using UnityEngine.UI;
public class SetID : MonoBehaviour
{
    [SerializeField]
    private int id;
    
    public Sprite[] image;
    public int setId{
        get => id;
        
        set{ id = value;
         SetImage();
         }
    }
    private void SetImage(){ 
        gameObject.GetComponent<Image>().sprite = image[id];
    }
}

 