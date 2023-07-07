using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionObject
{
    public string conditionValue;
    public ConditionEnum conditionEnum;
    public ConditionObject(ConditionSO conditionSo)
    {
        conditionValue = conditionSo.conditionValue;
        conditionEnum = conditionSo.conditionSo.conditionEnum;
    }
}