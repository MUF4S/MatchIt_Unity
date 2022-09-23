using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseMenuScript : MonoBehaviour
{
    string[] funnyText;
    public TextMeshProUGUI funnyMessage;
    // Start is called before the first frame update
     void Awake() {
        
        
        funnyText = System.IO.File.ReadAllLines(@"F:\GitRepos\MatchIt_Unity\MatchIt\FunnyText.txt");
        funnyMessage.text = funnyText[Random.Range(0,2)];
        //Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
}
