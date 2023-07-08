using System.Collections.Generic;

public class CardObject
{
    public List<StatementObject> statementObjects = new();
    public string chosenText;
    public string hoverText;

    public CardObject(CardSO cardSo)
    {
        foreach (var statementSo in cardSo.statementSos)
        {
            statementObjects.Add(new StatementObject(statementSo));
        }

        chosenText = cardSo.cardSelectText;
        hoverText = cardSo.cardHoverText;
    }
}