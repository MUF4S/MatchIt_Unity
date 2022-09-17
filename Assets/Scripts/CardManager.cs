using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random=UnityEngine.Random;

public class CardManager : MonoBehaviour
{
     
   
    public List<int[]> cards = new List<int[]>();
    List<int[]> usedCards = new List<int[]>();
    public GameObject stack;
    Button[] stackButtons;
    public GameObject playerStack;
    Button[] playerStackButtons;
    int[] currentCard = new int[6];
    int[] currentPlayerCard = new int[6];
    public List<float> objScale;
    List<float> newObjScale;
    GameObject pressedButton;
    int randomCard;
    float[] latestScale = new float[6];
    public Timer timer;
    public Chance chance;

#region Cards
   int[] Card1 = {0, 1, 2, 3, 4, 25};
   int[] Card2 = {5, 6, 7, 8, 9, 25};
   int[] Card3 = {10, 11, 12, 13, 14, 25};
   int[] Card4 = {15, 16, 17, 18, 19, 25};
   int[] Card5 = {20, 21, 22, 23, 24, 25};
   int[] Card6 = {0, 5, 10, 15, 20, 26};
   int[] Card7 = {1, 6, 11, 16, 21, 26};
   int[] Card8 = {2, 7, 12, 17, 22, 26};
   int[] Card9 = {3, 8, 13, 18, 23, 26};
   int[] Card10 = {4, 9, 14, 19, 24, 26};
   int[] Card11 = {0, 6, 12, 18, 24, 27};
   int[] Card12 = {1, 7, 13, 19, 20, 27};
   int[] Card13 = {2, 8, 14, 15, 21, 27};
   int[] Card14 = {3, 9, 10, 16, 22, 27};
   int[] Card15 = {4, 5, 11, 17, 23, 27};
   int[] Card16 = {0, 7, 14, 16, 23, 28};
   int[] Card17 = {1, 8, 10, 17, 24, 28};
   int[] Card18 = {2, 9, 11, 18, 20, 28};
   int[] Card19 = {3, 5, 12, 19, 21, 28};
   int[] Card20 = {4, 6, 13, 15, 22, 28};
   int[] Card21 = {0, 8, 11, 19, 22, 29};
   int[] Card22 = {1, 9, 12, 15, 23, 29};
   int[] Card23 = {2, 5, 13, 16, 24, 29};
   int[] Card24 = {3, 6, 14, 17, 20, 29};
   int[] Card25 = {4, 7, 10, 18, 21, 29};
   int[] Card26 = {0, 9, 13, 17, 21, 30};
   int[] Card27 = {1, 5, 14, 18, 22, 30};
   int[] Card28 = {2, 6, 10, 19, 23, 30};
   int[] Card29 = {3, 7, 11, 15, 24, 30};
   int[] Card30 = {4, 8, 12, 16, 20, 30};
   int[] Card31 = {25, 26, 27, 28, 29, 30};
#endregion


    private void Start() {
       
        
        
       newObjScale = new List<float>(objScale);
     
        stackButtons = new Button[stack.transform.childCount];
        playerStackButtons = new Button[playerStack.transform.childCount];
        for (int i = 0; i < stack.transform.childCount; i++)
            {
                stackButtons[i] = stack.transform.GetChild(i).GetComponent<Button>();
            }
        CreateStack();
        GetPlayerCard(getOneCard);
        GetCard();
        ShuffleCard();
    }
    private void Update() {
        
    }
    
    void CreateStack()
    {
        cards.Add(Card1);
        cards.Add(Card2);
        cards.Add(Card3);
        cards.Add(Card4);
        cards.Add(Card5);
        cards.Add(Card6);
        cards.Add(Card7);
        cards.Add(Card8);
        cards.Add(Card9);
        cards.Add(Card10);
        cards.Add(Card11);
        cards.Add(Card12);
        cards.Add(Card13);
        cards.Add(Card14);
        cards.Add(Card15);
        cards.Add(Card16);
        cards.Add(Card17);
        cards.Add(Card18);
        cards.Add(Card19);
        cards.Add(Card20);
        cards.Add(Card21);
        cards.Add(Card22);
        cards.Add(Card23);
        cards.Add(Card24);
        cards.Add(Card25);
        cards.Add(Card26);
        cards.Add(Card27);
        cards.Add(Card28);
        cards.Add(Card29);
        cards.Add(Card30);
        cards.Add(Card31);


       
        
    }
void ShuffleCard(){
     for (int i = 0; i < cards.Count; i++)
        {
            for (int j = 0; j < cards[i].Length; j++)
            {
                Array.Reverse(cards[i],Random.Range(0,3),Random.Range(3,5));
            }
            
        }
}
    void ShuffleUsedCards(){
        
        for (int i = 0; i < usedCards.Count; i++)
        {
            Array.Reverse(usedCards[i],Random.Range(0,3),Random.Range(3,6));
        }
    }

   int getOneCard{
    get{
        int val = Random.Range(1,cards.Count);
        
        return val;
    }
   }
   float getScale{
    
    get{
       float scale;
       int val = 0;
       if(newObjScale.Count > 1){
        val = Random.Range(1,newObjScale.Count);
       }
       else if(newObjScale.Count==1)
       {
        val = Random.Range(1,newObjScale.Count + 2);
       }
       
       scale = newObjScale[val];
       newObjScale.RemoveAt(val);

        return  scale;
    }
   }
      
void GetCard(){
    randomCard = getOneCard;
    
    for (int i = 0; i < stack.transform.childCount; i++)
        {
            float scale = getScale;
            stackButtons[i].transform.localScale = new Vector3(1f,1f,1f);
            stackButtons[i] = stack.transform.GetChild(i).GetComponent<Button>();
            stackButtons[i].transform.localScale *= scale;
            stackButtons[i].GetComponent<SetID>().setId = cards[randomCard][i];
           // stackButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = cards[randomCard][i].ToString();
            latestScale[i] = scale;        
        }
        
        currentCard = cards[randomCard];
        usedCards.Add(cards[randomCard]);
        cards.RemoveAt(randomCard);
        newObjScale = new List<float>(objScale);}
void GetPlayerCard(int card){
    
     currentPlayerCard = cards[card];
     for (int i = 0; i < playerStack.transform.childCount; i++)
        {
            playerStackButtons[i] = playerStack.transform.GetChild(i).GetComponent<Button>();
            playerStackButtons[i].transform.localScale *= getScale;
            playerStackButtons[i].GetComponent<SetID>().setId = cards[card][i];
            playerStackButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = cards[card][i].ToString();
            
                 
        }
        usedCards.Add(cards[card]);
        cards.RemoveAt(card);
        newObjScale = new List<float>(objScale);
}
void GetPlayerCard(int[] card){
    
     currentPlayerCard = card;
     for (int i = 0; i < playerStack.transform.childCount; i++)
        {
            playerStackButtons[i].transform.localScale = new Vector3(1f,1f,1f);;
            playerStackButtons[i] = playerStack.transform.GetChild(i).GetComponent<Button>();
            playerStackButtons[i].GetComponent<SetID>().setId =  currentPlayerCard[i];
            playerStackButtons[i].transform.localScale *= latestScale[i];
            //playerStackButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =  currentPlayerCard[i].ToString();
                 
        }
        newObjScale = new List<float>(objScale);
}
public void CheckItem(){
    bool isOK = false;
    for (int i = 0; i < stackButtons.Length; i++)
    {
        if(stackButtons[i].GetComponent<SetID>().setId == pressedButton.GetComponent<SetID>().setId)
        {
            if(cards.Count > 1)
            {
                Debug.Log("Brawo!");
                GetPlayerCard(currentCard);
                GetCard();
                timer.ResetTimer();
                isOK = true;
                return;
            }else{
                Debug.Log("Koniec gry my friend!");
            }
            
        }
        else{
            isOK = false;
            Debug.Log("Try again!");
        }

    }
    if(!isOK){
        chance.LostChance();
    }
    
}
public void SetPressedButton(GameObject obj){
    pressedButton = obj;
}
    
}
