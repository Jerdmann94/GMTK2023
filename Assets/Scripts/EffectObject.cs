using System;

public class EffectObject
{
    public EffectOperator op;
    public string key;
    public int value;

    public EffectObject(EffectSO effectSo)
    {
        key = effectSo.key;
        value = effectSo.value;
        op = effectSo.op;
    }


    public bool resolve(PlayerData playerData)
    {
        //THIS IS OUR BREAK OUT, HOW WE EXIT OUT OF A STATEMENT EARLY
        if (op == EffectOperator.Exit)
        {
            return false;
        }

        var k = playerData.getKeyPropertyInfo(key);
        var keyValue = k.GetValue(playerData);

        switch (op)
        {
            case EffectOperator.IncreasePlayer:
                k.SetValue(playerData, ConditionObject.parseToInt(keyValue) + value);
                break;
            case EffectOperator.ReducePlayer:
                k.SetValue(playerData, ConditionObject.parseToInt(keyValue) - value);
                break;
            case EffectOperator.GiveItem:
                k.SetValue(playerData, true);
                break;
            case EffectOperator.UseItem:
                k.SetValue(playerData, false);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return true;
    }
}