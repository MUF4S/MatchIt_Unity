using UnityEngine;

public class Chance : MonoBehaviour
{   
    public static Chance Instance;
    private GameObject _chance1;
    private GameObject _chance2;
    public GameManager gm;
    private int _chance = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start() {
        _chance1 = gameObject.transform.GetChild(0).gameObject;
        _chance2 = gameObject.transform.GetChild(1).gameObject;
    }
    public void LostChance(){
        _chance++;
        switch (_chance)
        {
            case 1:
                _chance1.SetActive(true);
                _chance1.GetComponent<Animator>().SetTrigger("ShowChance");
                break;
            case 2:
                _chance2.SetActive(true);
                _chance2.GetComponent<Animator>().SetTrigger("ShowChance");
                break;
            case 3:
                gm.GameOver("Sorry, You lost your chances.");
                break;
        }
    }
    public void ResetChance(){
        _chance = 0;
        _chance1.SetActive(false);
        _chance2.SetActive(false);
    }
}
