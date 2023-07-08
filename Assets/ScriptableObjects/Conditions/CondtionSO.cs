using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Card/Condition")]
public class ConditionSO : ScriptableObject
{
    public string key;
    public int value;
    public Operator op;
}

public enum Operator {
    GreaterThan,
    LessThan,
    Equals,
    HasItem,
    NotHasItem,
    RollsAbove,
    RollsBelow
}