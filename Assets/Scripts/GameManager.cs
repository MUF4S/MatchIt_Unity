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
   bool requested = false;

   private void Start() {
      GoogleAdMobController.instance.RequestAndLoadRewardedAd();
   }
   private void Update() {
      if(!requested)
      {
         GoogleAdMobController.instance.RequestAndLoadRewardedAd();
      }
   }


   public void GameOver(string message){
    //gamePanel.SetActive(false);
    overPanel.SetActive(true);
    messageText.text = message;
   /* if(!requested)
    {
      GoogleAdMobController.instance.RequestAndLoadRewardedAd();
      requested = true;
    }*/
    
   }

   public void RestartGame(){
      SceneManager.LoadScene(1);
      Time.timeScale = 1f;
      
   }
   public void ContinuePlaying(GameObject obj){
      Time.timeScale = 1f;
      obj.SetActive(false);

   }
   public void Revive(GameObject obj){
      obj.SetActive(false);
      Time.timeScale = 1f;
      Timer.instance.currentTime = Timer.instance.defaultTime;
      Chance.instance.ResetChance();
      requested = false;

   }
}
