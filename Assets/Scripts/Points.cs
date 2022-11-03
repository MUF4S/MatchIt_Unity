using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    public static Points Instance;

    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField]private int _points;
    [SerializeField]private int _bonus = 1;
    private int _currentCombo;




    private void Awake() {
        Instance = this;
    }

    void Update()
    {
        
    }
    public void SetComboValue(int _combo){
        if(_combo == 0){
            SetNewBonus(1);
            _currentCombo =0;
        }
    
        _currentCombo += _combo;
        

        switch (_currentCombo)
        {
            case 5:
                SetNewBonus(2);
                break;
            case 20:
                SetNewBonus(3);
                break;
            case 56:
                SetNewBonus(4);
                break;
            default:
                break;
        }
    }
    public void GetPoints(int _pointsToAdd){
        _points += _pointsToAdd * _bonus;
        _score.text = _points.ToString();
    }
    private void SetNewBonus(int _newBonus){
        _bonus = _newBonus;
    }
    
}
