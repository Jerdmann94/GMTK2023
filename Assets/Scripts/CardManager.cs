using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class CardManager : MonoBehaviour
{
    //UI STUFF
    
    public Transform CardUIParent;

    public List<HandScript> handUi;
    // CARD DATA
    public List<CardSO> cardSos;
    private Queue<CardObject> _deck = new Queue<CardObject>();
    private List<CardObject> _hand = new List<CardObject>();
    //UI METHODS
    
    public void displayCard(GameObject card)
    {
        var c = Instantiate(card, CardUIParent);
    }

    public void displayHand()
    {
        foreach (var cardObject in _hand)
        {
            
        }
    }

    //DATA METHODS

    public void initDeck()
    {
        _deck = new Queue<CardObject>();
        _deck.Clear();
        var shuffledList = cardSos.OrderBy( x => Random.value ).ToList( );
        foreach (var cardSo in shuffledList)
        {
            _deck.Enqueue(new CardObject(cardSo));
        }
        drawHand();
    }
    
    public void drawHand()
    {
        _hand.Clear();
        _hand.Add(_deck.Dequeue());
        _hand.Add(_deck.Dequeue());
        _hand.Add(_deck.Dequeue());
        foreach (var cardObject in _hand)
        {
           Debug.Log(cardObject); 
        }
    }
    
    
    
   

}
