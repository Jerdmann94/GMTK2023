using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Card/Condition")]
public class ConditionSO : ScriptableObject
{
    public string key;
    public int value;
    public ConditionOperator op;
}

public enum ConditionOperator
{
    GreaterThan,
    LessThan,
    Equals,
    HasItem,
    NotHasItem,
    RollsAbove,
    RollsBelow
}