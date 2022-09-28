using UnityEngine;
using UnityEngine.UI;
public class SetID : MonoBehaviour
{
    [SerializeField]
    private int id;
    

    public int setId{
        get => id;
        
        set{ id = value;
         SetImage();
         }
    }
    private void SetImage(){ 
        gameObject.GetComponent<Image>().sprite = SymbolBase.Instance.image[id];
    }
}

 