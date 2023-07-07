using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Card/CardSo", order = 1)]
public class CardSO : ScriptableObject
{
    public List<StatementSO> statementSos;
}
