using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chance : MonoBehaviour
{   
    GameObject chance1;
    GameObject chance2;
    public GameManager gm;
    int chance = 0;
    private void Start() {
        chance1 = gameObject.transform.GetChild(0).gameObject;
        chance2 = gameObject.transform.GetChild(1).gameObject;
    }
    public void LostChance(){
        chance++;
        switch (chance)
        {
            case 1:
                chance1.SetActive(true);
                break;
            case 2:
                chance2.SetActive(true);
                break;
            case 3:
                gm.GameOver("Sorry, You lost your chances.");
                break;

            default:
                break;
        }
    }
}
