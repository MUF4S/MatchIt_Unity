using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

   #region variables
   public TextMeshProUGUI messageText;
   public CardManager cardMan;
   public GameObject gamePanel;
   public GameObject overPanel;
   public bool requested = false;
   public UnityAction _Revive;
   public UnityAction _Hint;


   #endregion
   private void Start() {
      cardMan = GetComponent<CardManager>();

      _Revive += GetRevive;
      _Hint += cardMan.GetHint;
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
    overPanel.SetActive(true);
    messageText.text = message;
   }

   public void RestartGame(){
      SceneManager.LoadScene(1);
      Time.timeScale = 1f;
      
   }
   public void ContinuePlaying(GameObject obj){
      //Time.timeScale = 1f;
      Timer.instance.StopTime();
      obj.SetActive(false);

   }
   void GetRevive(){
      Revive(overPanel);
   }
   void Revive(GameObject obj){
      obj.SetActive(false);
      Timer.instance.StopTime();
      //Time.timeScale = 1f;
      Timer.instance.currentTime = Timer.instance.defaultTime;
      Chance.instance.ResetChance();
      
   }
   void GetRewardAd(UnityAction action){
      GoogleAdMobController.instance.OnUserEarnedRewardEvent.AddListener(action);
      Debug.Log("Wywołano" + action);
   }
   public void SetReviveAction(){
      GetRewardAd(_Revive);
   }
   public void SetHintAction(){
      GetRewardAd(_Hint);
   }

}
