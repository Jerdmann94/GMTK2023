using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Card/StatmentSO", order = 3)]
public class StatementSO : ScriptableObject
{
    public List<ConditionSO> conditionSos;
    public List<EffectSO> effectSos;
}