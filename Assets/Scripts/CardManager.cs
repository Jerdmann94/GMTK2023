using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    //UI STUFF

    public Transform CardUIParent;

    public List<HandScript> handUi;

    public ChatManager chatManager;

    // CARD DATA
    public List<CardSO> cardSos;
    private Queue<CardObject> _deck = new Queue<CardObject>();

    private List<CardObject> _hand = new List<CardObject>();

    // PLAYER DATA
    public PlayerData playerData;


    //UI METHODS
    public void displayCard(GameObject card)
    {
        var c = Instantiate(card, CardUIParent);
    }

    public void displayHand()
    {
        for (var index = 0; index < _hand.Count; index++)
        {
            var cardObject = _hand[index];
            handUi[index].setUIText(cardObject.ToString());
        }
    }

    public void chooseCard(int i)
    {
        chatManager.makeChatMessage(_hand[i].chosenText);
        foreach (var statementObject in _hand[i].statementObjects)
        {
            Debug.Log(statementObject.evaluate(playerData));
        }
    }

    //DATA METHODS


    public void initDeck()
    {
        _deck = new Queue<CardObject>();
        _deck.Clear();
        var shuffledList = cardSos.OrderBy(x => Random.value).ToList();
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

        displayHand();
    }
}