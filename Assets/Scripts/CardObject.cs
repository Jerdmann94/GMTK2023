using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardObject
{
    public List<StatementObject> statementObjects = new();
    public CardObject(CardSO cardSo)
    {
        foreach (var statementSo in cardSo.statementSos)
        {
           statementObjects.Add(new StatementObject(statementSo)); 
        }
        
    }
}
