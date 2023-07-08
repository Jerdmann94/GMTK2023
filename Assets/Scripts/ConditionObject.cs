public class ConditionObject
{
    public string key;
    public int value;
    public ConditionOperator op;

    public ConditionObject(ConditionSO conditionSo)
    {
        this.key = conditionSo.key;
        this.value = conditionSo.value;
        this.op = conditionSo.op;
    }
}