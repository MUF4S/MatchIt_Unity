using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetID : MonoBehaviour
{
    [SerializeField]int id;
    public Sprite[] image;
    public int setId{
        
        get{
            return id;
        }
        set{
         id = value;
         SetImage();
         }
        }
        void SetImage(){

            gameObject.GetComponent<Image>().sprite = image[id-1];
    }
    }

 