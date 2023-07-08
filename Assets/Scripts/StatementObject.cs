using System;
using System.Collections.Generic;
using UnityEngine;

public class StatementObject
{
    public List<ConditionObject> conditions = new List<ConditionObject>();
    public List<EffectObject> effects = new List<EffectObject>();

    public StatementObject(StatementSO statementSo)
    {
        foreach (var conditionSo in statementSo.conditionSos)
        {
            conditions.Add(new ConditionObject(conditionSo));
        }

        foreach (var effectSo in statementSo.effectSos)
        {
            effects.Add(new EffectObject(effectSo));
        }
    }

    public bool evaluate(PlayerData playerData)
    {
        foreach (var condition in conditions)
        {
            Debug.Log(condition.key);
            var k = playerData.getKeyPropertyInfo(condition.key);
            var keyValue = k.GetValue(playerData);
            switch (condition.op)
            {
                //uses key value
                case ConditionOperator.GreaterThan:
                    return parseToInt(keyValue) >= condition.value;

                //uses key value
                case ConditionOperator.LessThan:
                    return parseToInt(keyValue) < condition.value;
                    break;

                //uses key value
                case ConditionOperator.Equals:
                    return parseToInt(keyValue) == condition.value;
                    break;

                //uses key
                case ConditionOperator.HasItem:
                    break;

                //uses key
                case ConditionOperator.NotHasItem:
                    break;

                //uses key value
                case ConditionOperator.RollsAbove:
                    break;

                //uses key value
                case ConditionOperator.RollsBelow:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return false;
    }

    private int parseToInt(object o)
    {
        return int.Parse(o.ToString());
    }
}