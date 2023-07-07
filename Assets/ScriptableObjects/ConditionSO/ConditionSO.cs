using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "Card/ConditionSO")]
public class ConditionSO : ScriptableObject
{
    public ConditionOperatorSO conditionSo;
    public string conditionValue;
    
}

[CreateAssetMenu(fileName = "Data", menuName = "Card/ConditionAttributeSO")]
public class AttributeCondition : ConditionSO
{
    public string attribute;
}

[CreateAssetMenu(fileName = "Data", menuName = "Card/ConditionAttributeSO")]
public class Condition : ConditionSO
{
    public string attribute;
}