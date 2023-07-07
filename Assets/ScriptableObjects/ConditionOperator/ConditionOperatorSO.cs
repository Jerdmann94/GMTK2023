using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "Card/ConditionOperatorSo")]
public class ConditionOperatorSO : ScriptableObject
{
    public ConditionEnum conditionEnum;
}

public enum ConditionEnum
{
    GreaterThan,
    LessThan,
    HasItem
}
