
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hints : MonoBehaviour
{

    private GameObject _imgStack;
    private GameObject _imgPlayerStack;
    [SerializeField] private TextMeshProUGUI _hintsNumber;
    public bool _hint;
    [SerializeField] private int _maxHints;
    [SerializeField] private int _hintIndex;
    // Start is called before the first frame update
    void Start()
    {
        _hintIndex = _maxHints;
        _hintsNumber.text = _hintIndex.ToString() + " / " + _maxHints.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(_hintIndex == 0){
            print("Zero hints");
            ZeroHints();
        }
    }

    public void ShowHint(GameObject imgStack, GameObject imgPlayerStack){
        _imgPlayerStack = imgPlayerStack;
        _imgStack = imgStack;
        _hintIndex--;
        _imgPlayerStack.SetActive(true);
        _imgStack.SetActive(true);

        _hintsNumber.text = _hintIndex.ToString() + " / " + _maxHints.ToString();
    }

    public void ChangeButtonState(){
        GetComponent<Button>().interactable = !GetComponent<Button>().interactable;
    }
    public  void RemoveHint(){
        _imgPlayerStack.SetActive(false);
        _imgStack.SetActive(false);
        _hint = false;
        ChangeButtonState();
    }

    private void ZeroHints(){
        print($"Max hints reached {_hintIndex}");
        this.gameObject.SetActive(false);
    }
}
