using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    //UI STUFF
    public List<HandScript> handUi;
    public List<HandScript> previewUi;
    public ChatManager chatManager;
    public RoomObjectManager roomObjectManager;

    // CARD DATA
    public List<CardSO> cardSos;
    private Queue<CardObject> _deck = new Queue<CardObject>();
    private List<CardObject> _hand = new List<CardObject>();
    private List<CardObject> _chosenCards = new List<CardObject>();
    private List<CardObject> _previewCards = new();
    private List<CardObject> _discardedCards = new();

    // PLAYER DATA
    public PlayerData playerData;


    //UI METHODS


    public void displayHand(CardObject cardObject, int i)
    {
        var ttt = handUi[i].GetComponent<ToolTipTrigger>();
        ttt.header = cardObject.name;
        ttt.text = cardObject.hoverText;
        handUi[i].setUIImage(cardObject.sprite, cardObject.isInverted);
    }

    private void displayPreview()
    {
        for (var index = 0; index < _previewCards.Count; index++)
        {
            var card = _previewCards[index];
            previewUi[index].setUIImage(card.sprite, card.isInverted);
        }
    }


    //DATA METHODS
    public void chooseCard(int i)
    {
        Debug.Log("is inverted" + _hand[i].isInverted);
        Debug.Log(_hand[i].sprite.name);

        if (_hand[i].isInverted)
        {
            if (_hand[i].inverseRoomSprite != null)
            {
                roomObjectManager.spawnRoomSprite(_hand[i].inverseRoomSprite);
            }
            else if (_hand[i].normalRoomSprite != null)
            {
                roomObjectManager.spawnRoomSprite(_hand[i].normalRoomSprite);
            }
            else
            {
                roomObjectManager.spawnRoomSprite(null);
            }

            chatManager.makeChatMessage(_hand[i].invertedChosenText);

            foreach (var statementObject in _hand[i].invertedStatementObjects)
            {
                if (!statementObject.doStatement(playerData))
                {
                    break;
                }
            }
        }
        else
        {
            roomObjectManager.spawnRoomSprite(_hand[i].normalRoomSprite != null ? _hand[i].normalRoomSprite : null);
            chatManager.makeChatMessage(_hand[i].chosenText);
            foreach (var statementObject in _hand[i].statementObjects)
            {
                if (!statementObject.doStatement(playerData))
                {
                    break;
                }
            }
        }

        _chosenCards.Add(_hand[i]);
        _hand.RemoveAt(i);
        foreach (var card in _hand)
        {
            _discardedCards.Add(card);
        }

        _hand.Clear();
        playerData.clearTempStats();
        drawHand();
    }

    public void initDeck()
    {
        _deck = new Queue<CardObject>();
        _deck.Clear();
        _previewCards.Clear();
        _hand.Clear();
        _discardedCards.Clear();
        _chosenCards.Clear();
        var shuffledList = cardSos.OrderBy(x => Random.value).ToList();
        foreach (var cardSo in shuffledList)
        {
            _deck.Enqueue(new CardObject(cardSo));
        }

        _previewCards.Clear();
        _previewCards.Add(_deck.Dequeue());
        _previewCards.Add(_deck.Dequeue());
        _previewCards.Add(_deck.Dequeue());
        drawHand();
    }

    public void drawHand()
    {
        if (_deck.Count <= 4)
        {
            var shuffledList = _discardedCards.OrderBy(x => Random.value).ToList();
            foreach (var card in shuffledList)
            {
                _deck.Enqueue(card);
            }

            _discardedCards.Clear();
        }

        for (var index = 0; index < _previewCards.Count; index++)
        {
            var card = _previewCards[index];
            _hand.Add(card);
            displayHand(card, index);
        }

        _previewCards.Clear();
        _previewCards.Add(_deck.Dequeue());
        _previewCards.Add(_deck.Dequeue());
        _previewCards.Add(_deck.Dequeue());
        displayPreview();
    }
}