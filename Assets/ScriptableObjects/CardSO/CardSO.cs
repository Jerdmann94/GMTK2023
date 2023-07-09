using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Card/CardSo", order = 1)]
public class CardSO : ScriptableObject
{
    public List<StatementSO> statementSos;
    public string cardSelectText;
    public string cardHoverText;
    public Sprite cardImage;
    public List<StatementSO> invertedStatementSos;
    public string invertedCardSelectText;
    public string invertedCardHoverText;
    public Sprite normalRoomSprite;
    public Sprite inverseRoomSprite;
}