using System.Collections.Generic;

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

    //if all conditions passed ,do all effects
    public bool doStatement(PlayerData playerData)
    {
        foreach (var condition in conditions)
        {
            if (!condition.evaluate(playerData))
            {
                return true;
            }
        }

        foreach (var effect in effects)
        {
            if (!effect.resolve(playerData))
            {
                return false;
            }
        }

        return true;
    }
}