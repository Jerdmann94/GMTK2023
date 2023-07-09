using System.Collections.Generic;
using UnityEngine;

public class CardObject
{
    public List<StatementObject> statementObjects = new();
    public string chosenText;
    public string hoverText;

    public List<StatementObject> invertedStatementObjects = new();
    public string invertedChosenText;
    public string invertedHoverText;

    public bool isInverted;
    public Sprite sprite;
    public Sprite inverseRoomSprite;
    public Sprite normalRoomSprite;

    public string name;

    public CardObject(CardSO cardSo)
    {
        Debug.Log(cardSo.name);
        name = cardSo.name;
        foreach (var statementSo in cardSo.statementSos)
        {
            statementObjects.Add(new StatementObject(statementSo));
        }

        foreach (var statementSo in cardSo.invertedStatementSos)
        {
            invertedStatementObjects.Add(new StatementObject(statementSo));
        }

        inverseRoomSprite = cardSo.inverseRoomSprite;
        normalRoomSprite = cardSo.normalRoomSprite;
        sprite = cardSo.cardImage;
        invertedChosenText = cardSo.invertedCardSelectText;
        invertedHoverText = cardSo.invertedCardHoverText;
        chosenText = cardSo.cardSelectText;
        hoverText = cardSo.cardHoverText;
        isInverted = Random.Range(0, 2) == 1;
    }
}