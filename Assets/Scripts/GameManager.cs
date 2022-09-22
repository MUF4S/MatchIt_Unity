using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
   public TextMeshProUGUI messageText;
   public GameObject gamePanel;
   public GameObject overPanel;
   public bool requested = false;
   public UnityAction _Revive;
   private void Start() {
      //GoogleAdMobController.instance.RequestAndLoadRewardedAd();
      _Revive += Revive;
   }
   private void Update() {
      if(!requested)
      {
         GoogleAdMobController.instance.RequestAndLoadRewardedAd();
         Debug.Log("Requested a AD");
         requested = true;
      }
      Debug.Log(requested);
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
   void Revive(){
      
   }
   public void Revive(GameObject obj){
      obj.SetActive(false);
      Time.timeScale = 1f;
      Timer.instance.currentTime = Timer.instance.defaultTime;
      Chance.instance.ResetChance();
      
   }
   void GetRewardAd(){
      GoogleAdMobController.instance.OnUserEarnedRewardEvent.AddListener(Revive);
   }
}
