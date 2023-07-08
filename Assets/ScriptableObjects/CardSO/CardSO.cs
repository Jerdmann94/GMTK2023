using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Data", menuName = "Card/CardSo", order = 1)]
public class CardSO : ScriptableObject
{
    public List<StatementSO> statementSos;
    public string cardSelectText;
    public string cardHoverText;
    public Image cardImage;
}