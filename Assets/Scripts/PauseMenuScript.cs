using UnityEngine;
using TMPro;

public class PauseMenuScript : MonoBehaviour
{
    private string[] _funnyText;
    public TextMeshProUGUI funnyMessage;
    private void Awake() { 
        _funnyText = System.IO.File.ReadAllLines(@"F:\GitRepos\MatchIt_Unity\MatchIt\FunnyText.txt");
        funnyMessage.text = _funnyText[Random.Range(0,2)];
        //Time.timeScale = 0f;
    }
}
