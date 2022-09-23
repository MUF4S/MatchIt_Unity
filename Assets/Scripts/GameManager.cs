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
         print("Requested a AD");
         requested = true;
      }
      print(requested);
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
      Timer.Instance.StopTime();
      obj.SetActive(false);
   }
   private void GetRevive(){
      Revive(overPanel);
   }
   private void Revive(GameObject obj){
      obj.SetActive(false);
      Timer.Instance.StopTime();
      //Time.timeScale = 1f;
      Timer.Instance.currentTime = Timer.Instance.defaultTime;
      Chance.Instance.ResetChance();
   }
   private static void GetRewardAd(UnityAction action){
      GoogleAdMobController.instance.OnUserEarnedRewardEvent.AddListener(action);
      print($"Wywołano {action}");
   }
   public void SetReviveAction(){
      GetRewardAd(_Revive);
   }
   public void SetHintAction(){
      GetRewardAd(_Hint);
   }
}
