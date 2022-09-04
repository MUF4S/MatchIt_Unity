using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
   public TextMeshProUGUI messageText;
   public GameObject gamePanel;
   public GameObject overPanel;




   public void GameOver(string message){
    //gamePanel.SetActive(false);
    overPanel.SetActive(true);
    messageText.text = message;
   }

   public void RestartGame(){
      SceneManager.LoadScene(1);
   }
}
