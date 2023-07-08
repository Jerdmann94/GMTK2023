using System;
using System.Collections.Generic;

public class StatementObject
{
    public List<ConditionObject> conditions = new List<ConditionObject>();
    public List<EffectObject> effects;

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

    public void evaluate()
    {
        foreach (var condition in conditions)
        {
            switch (condition.op)
            {
                //uses key value
                case Operator.GreaterThan:
                    break;

                //uses key value
                case Operator.LessThan:
                    break;

                //uses key value
                case Operator.Equals:
                    break;

                //uses key
                case Operator.HasItem:
                    break;

                //uses key
                case Operator.NotHasItem:
                    break;

                //uses key value
                case Operator.RollsAbove:
                    break;

                //uses key value
                case Operator.RollsBelow:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}