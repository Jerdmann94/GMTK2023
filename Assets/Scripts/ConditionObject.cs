using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionObject
{
    public string key;
    public int value;
    public Operator op;
    public ConditionObject(ConditionSO conditionSo)
    {
        this.key = conditionSo.key;
        this.value = conditionSo.value;
        this.op = conditionSo.op;
    }

    public Boolean Evaluate(PlayerData player, CardObject card)
    {
        return true;
    }
    
}