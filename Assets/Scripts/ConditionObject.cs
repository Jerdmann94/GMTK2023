using System;
using Random = UnityEngine.Random;

public class ConditionObject
{
    public string key;
    public int value;
    public ConditionOperator op;


    public ConditionObject(ConditionSO conditionSo)
    {
        //Debug.Log(conditionSo.name);
        this.key = conditionSo.key;
        this.value = conditionSo.value;
        this.op = conditionSo.op;
    }

    public bool evaluate(PlayerData playerData)
    {
////        Debug.Log(key);
        var k = playerData.getKeyPropertyInfo(key);
        var keyValue = k.GetValue(playerData);
        switch (op)
        {
            //uses key value
            case ConditionOperator.GreaterThan:
                return parseToInt(keyValue) >= value;

            //uses key value
            case ConditionOperator.LessThan:
                return parseToInt(keyValue) < value;

            //uses key value
            case ConditionOperator.Equals:
                return parseToInt(keyValue) == value;

            //uses key
            case ConditionOperator.HasItem:
                return bool.Parse(keyValue.ToString());

            //uses key
            case ConditionOperator.NotHasItem:
                return !bool.Parse(keyValue.ToString());

            //uses key value
            case ConditionOperator.RollsAbove:
                return value <= (parseToInt(keyValue) + roll2d6());

            //uses key value
            case ConditionOperator.RollsBelow:
                return value > (parseToInt(keyValue) + roll2d6());

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private int roll2d6()
    {
        return Random.Range(1, 7) + Random.Range(1, 7);
    }

    public static int parseToInt(object o)
    {
        return int.Parse(o.ToString());
    }
}