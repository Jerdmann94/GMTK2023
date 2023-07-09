using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    //UI STUFF
    public List<HandScript> handUi;
    public List<HandScript> previewUi;
    public ChatManager chatManager;
    public RoomObjectManager roomObjectManager;

    public GameManager gameManager;

    // CARD DATA
    public List<CardSO> cardSos;
    public CardSO relicSo;
    private int _playedCounter;
    private bool _returnTrip;
    private int _relicReturnCounter;
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


    public async void chooseCard(int i)
    {
        _playedCounter++;
        Debug.Log(_playedCounter);
        ToolTipManager.Hide();
        foreach (var handScript in handUi)
        {
            handScript.GetComponent<Button>().interactable = false;
        }

        playerData.Food--;

        if (_hand[i].name == "Relic")
        {
            doRelicStuff();

            return;
        }

        Debug.Log(i + "  " + _hand[i].name + " is inverted " + _hand[i].isInverted);

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
            await Task.Delay(2000);
            Debug.Log("Did delay 1");
            foreach (var statementObject in _hand[i].invertedStatementObjects)
            {
                var result = await statementObject.doStatement(playerData, chatManager);
                if (!result)
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
                var result = await statementObject.doStatement(playerData, chatManager);

                if (!result)
                {
                    break;
                }
            }
        }

        if (_returnTrip && _deck.Count < 4)
        {
            gameManager.gameWin();

            return;
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
        foreach (var handScript in handUi)
        {
            handScript.GetComponent<Button>().interactable = true;
        }
    }

    private void doRelicStuff()
    {
        Debug.Log("DoingRelic");
        _returnTrip = true;
        _previewCards.Clear();
        _deck.Clear();
        _hand.Clear();
        playerData.clearTempStats();
        var shuffledList = _chosenCards.OrderBy(x => Random.value).ToList();
        foreach (var card in shuffledList)
        {
            card.isInverted = !card.isInverted;
        }

        foreach (var card in shuffledList)
        {
            _deck.Enqueue(card);
        }

        var card1 = _deck.Dequeue();
        var card2 = _deck.Dequeue();
        var card3 = _deck.Dequeue();
        _previewCards.Add(card1);
        _previewCards.Add(card2);
        _previewCards.Add(card3);
        drawHand();
        foreach (var handScript in handUi)
        {
            handScript.GetComponent<Button>().interactable = true;
        }
    }

    public void initDeck()
    {
        chatManager.ClearMessages();
        foreach (var handScript in handUi)
        {
            handScript.GetComponent<Button>().interactable = true;
        }

        _playedCounter = 0;
        _returnTrip = false;
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
        var card1 = _deck.Dequeue();
        var card2 = _deck.Dequeue();
        var card3 = _deck.Dequeue();

        Debug.Log("Cards in preview " + card1.name + " " + card2.name + " " + card3.name + " ");
        _previewCards.Add(card1);
        _previewCards.Add(card2);
        _previewCards.Add(card3);
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
        var card1 = _deck.Dequeue();
        var card2 = _deck.Dequeue();
        var card3 = new CardObject(relicSo);
        if (_playedCounter > 7)
        {
            if (_relicReturnCounter <= 0)
            {
                card3 = new CardObject(relicSo);
                _relicReturnCounter = 3;
            }
            else
            {
                _relicReturnCounter--;
                card3 = _deck.Dequeue();
            }
        }
        else
        {
            card3 = _deck.Dequeue();
        }

        Debug.Log("Cards in preview " + card1.name + " " + card2.name + " " + card3.name + " ");
        _previewCards.Add(card1);
        _previewCards.Add(card2);
        _previewCards.Add(card3);
        displayPreview();
    }
}