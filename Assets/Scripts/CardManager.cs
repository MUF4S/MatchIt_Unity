using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CardManager : MonoBehaviour
{
    private List<int[]> _cards = new();
    private List<int[]> _usedCards = new();
    public List<float> objScale;
    private List<float> _newObjScale;
    
    public GameObject stack;
    private GameObject _imgStack;
    private GameObject _imgPlayerStack;
    private GameObject _pressedButton;
    public GameObject playerStack;
    
    private Button[] _stackButtons;
    private Button[] _playerStackButtons;
    
    public Timer timer;
    public Chance chance;
    
    private int[] _currentCard = new int[6];
    private int[] _currentPlayerCard = new int[6];
    private float[] _latestScale = new float[6];
    
    private int _randomCard;
    
    private bool _hint;

#region Cards
   private int[] _card1 = {0, 1, 2, 3, 4, 25};
   private int[] _card2 = {5, 6, 7, 8, 9, 25};
   private int[] _card3 = {10, 11, 12, 13, 14, 25};
   private int[] _card4 = {15, 16, 17, 18, 19, 25};
   private int[] _card5 = {20, 21, 22, 23, 24, 25};
   private int[] _card6 = {0, 5, 10, 15, 20, 26};
   private int[] _card7 = {1, 6, 11, 16, 21, 26};
   private int[] _card8 = {2, 7, 12, 17, 22, 26};
   private int[] _card9 = {3, 8, 13, 18, 23, 26};
   private int[] _card10 = {4, 9, 14, 19, 24, 26};
   private int[] _card11 = {0, 6, 12, 18, 24, 27};
   private int[] _card12 = {1, 7, 13, 19, 20, 27};
   private int[] _card13 = {2, 8, 14, 15, 21, 27};
   private int[] _card14 = {3, 9, 10, 16, 22, 27};
   private int[] _card15 = {4, 5, 11, 17, 23, 27};
   private int[] _card16 = {0, 7, 14, 16, 23, 28};
   private int[] _card17 = {1, 8, 10, 17, 24, 28};
   private int[] _card18 = {2, 9, 11, 18, 20, 28};
   private int[] _card19 = {3, 5, 12, 19, 21, 28};
   private int[] _card20 = {4, 6, 13, 15, 22, 28};
   private int[] _card21 = {0, 8, 11, 19, 22, 29};
   private int[] _card22 = {1, 9, 12, 15, 23, 29};
   private int[] _card23 = {2, 5, 13, 16, 24, 29};
   private int[] _card24 = {3, 6, 14, 17, 20, 29};
   private int[] _card25 = {4, 7, 10, 18, 21, 29};
   private int[] _card26 = {0, 9, 13, 17, 21, 30};
   private int[] _card27 = {1, 5, 14, 18, 22, 30};
   private int[] _card28 = {2, 6, 10, 19, 23, 30};
   private int[] _card29 = {3, 7, 11, 15, 24, 30};
   private int[] _card30 = {4, 8, 12, 16, 20, 30};
   private int[] _card31 = {25, 26, 27, 28, 29, 30};
#endregion

    private void Start() {
        
       _newObjScale = new List<float>(objScale);
       _stackButtons = new Button[stack.transform.childCount];
       _playerStackButtons = new Button[playerStack.transform.childCount];
        
        for(var i = 0; i < stack.transform.childCount; i++)
        { 
            _stackButtons[i] = stack.transform.GetChild(i).GetComponent<Button>();
        }
        
        CreateStack();
        GetPlayerCard(getOneCard);
        GetCard();
        ShuffleCard();
    }
    private void Update() {
        if(_cards.Count<2){
            CreateStack(_usedCards);
        }
    }
    private void CreateStack()
    {
        _cards.Add(_card1);
        _cards.Add(_card2);
        _cards.Add(_card3);
        _cards.Add(_card4);
        _cards.Add(_card5);
        _cards.Add(_card6);
        _cards.Add(_card7);
        _cards.Add(_card8);
        _cards.Add(_card9);
        _cards.Add(_card10);
        _cards.Add(_card11);
        _cards.Add(_card12);
        _cards.Add(_card13);
        _cards.Add(_card14);
        _cards.Add(_card15);
        _cards.Add(_card16);
        _cards.Add(_card17);
        _cards.Add(_card18);
        _cards.Add(_card19);
        _cards.Add(_card20);
        _cards.Add(_card21);
        _cards.Add(_card22);
        _cards.Add(_card23);
        _cards.Add(_card24);
        _cards.Add(_card25);
        _cards.Add(_card26);
        _cards.Add(_card27);
        _cards.Add(_card28);
        _cards.Add(_card29);
        _cards.Add(_card30);
        _cards.Add(_card31);
    }
    private void CreateStack(List<int[]> list)
    {
        foreach (var t in list)
        {
            _cards.Add(t);
        }
    }
    private void ShuffleCard(){
        for (int i = 0; i < _cards.Count; i++)
        {
            for (int j = 0; j < _cards[i].Length; j++)
            {
                Array.Reverse(_cards[i],Random.Range(0,3),Random.Range(3,5));
            }
        } 
    }
    private void ShuffleUsedCards()
    {
        foreach (var usedCards in _usedCards)
        {
            Array.Reverse(usedCards,Random.Range(0,3),Random.Range(3,6));
        }
    }
    private int getOneCard{
        get{ var val = Random.Range(1,_cards.Count);
            return val; 
        }
    }
    private float getScale{
    
    get{ var val = 0;
       if(_newObjScale.Count > 1){
        val = Random.Range(1,_newObjScale.Count);
       }
       else if(_newObjScale.Count==1)
       {
        val = Random.Range(1,_newObjScale.Count + 2);
       }
       var scale = _newObjScale[val];
       _newObjScale.RemoveAt(val);
       return  scale;
    }
   }
    private void GetCard(){
        _randomCard = getOneCard;
    
        for (var i = 0; i < stack.transform.childCount; i++)
        {
            var scale = getScale;
            
            _stackButtons[i].transform.localScale = new Vector3(1f,1f,1f);
            _stackButtons[i] = stack.transform.GetChild(i).GetComponent<Button>();
            _stackButtons[i].transform.localScale *= scale;
            _stackButtons[i].GetComponent<SetID>().setId = _cards[_randomCard][i];
            
            _latestScale[i] = scale;        
        }
        _currentCard = _cards[_randomCard];
        _usedCards.Add(_cards[_randomCard]);
        _cards.RemoveAt(_randomCard);
        _newObjScale = new List<float>(objScale);
    }
    private void GetPlayerCard(int card){
    
     _currentPlayerCard = _cards[card];
     
     for (var i = 0; i < playerStack.transform.childCount; i++)
     { 
         _playerStackButtons[i] = playerStack.transform.GetChild(i).GetComponent<Button>();
         _playerStackButtons[i].transform.localScale *= getScale;
         _playerStackButtons[i].GetComponent<SetID>().setId = _cards[card][i];
     }
     
     _usedCards.Add(_cards[card]);
     _cards.RemoveAt(card);
     _newObjScale = new List<float>(objScale);
}
    private void GetPlayerCard(int[] card){
    
     _currentPlayerCard = card;
     
     for (var i = 0; i < playerStack.transform.childCount; i++)
     { 
         _playerStackButtons[i].transform.localScale = new Vector3(1f,1f,1f);;
         _playerStackButtons[i] = playerStack.transform.GetChild(i).GetComponent<Button>();
         _playerStackButtons[i].GetComponent<SetID>().setId =  _currentPlayerCard[i];
         _playerStackButtons[i].transform.localScale *= _latestScale[i];
     }
     
     _newObjScale = new List<float>(objScale);
}
    public void CheckItem(){
        var isOk = false;
        if(_hint){
            RemoveHint();
        }
        
        for (int i = 0; i < _stackButtons.Length; i++)
        {
            if(_stackButtons[i].GetComponent<SetID>().setId == _pressedButton.GetComponent<SetID>().setId)
            {
                if(_cards.Count > 1)
                {
                    Debug.Log("Brawo!");
                    GetPlayerCard(_currentCard);
                    GetCard();
                    timer.ResetTimer();
                    isOk = true;
                    return;
                }else{
                    Debug.Log("Koniec gry my friend!");
                }
                
            }
            else{
                isOk = false;
                Debug.Log("Try again!");
            }

        }
        if(!isOk){
            chance.LostChance();
        }
    }
    public void GetHint(){
    _hint = true;
    for (var i = 0; i < _stackButtons.Length; i++)
    {
        for (var j = 0; j < _playerStackButtons.Length; j++)
        {
            if(_stackButtons[i].GetComponent<SetID>().setId == _playerStackButtons[j].GetComponent<SetID>().setId){
                    Hint(_stackButtons[i].transform.GetChild(0).gameObject, _playerStackButtons[j].transform.GetChild(0).gameObject);
                    return;
            }
        }
    }
}
    private void Hint(GameObject imgStack, GameObject imgPlayerStack){
        _imgPlayerStack = imgPlayerStack;
        _imgStack = imgStack;

        _imgPlayerStack.SetActive(true);
        _imgStack.SetActive(true);
    }
    private void RemoveHint(){
        _imgPlayerStack.SetActive(false);
        _imgStack.SetActive(false);
        _hint = false;
    }
    public void SetPressedButton(GameObject obj){
        _pressedButton = obj;
    }
}
