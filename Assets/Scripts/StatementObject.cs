using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class StatementObject
{
    public List<ConditionObject> conditions = new List<ConditionObject>();
    public List<EffectObject> effects = new List<EffectObject>();
    public string failText;
    public string successText;

    public StatementObject(StatementSO statementSo)
    {
        if (statementSo.conditionFailText.Count > 0)
        {
            failText = statementSo.conditionFailText[0];
        }

        if (statementSo.conditionSuccessText.Count > 0)
        {
            successText = statementSo.conditionSuccessText[0];
        }


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
    public async Task<bool> doStatement(PlayerData playerData, ChatManager chatManager)
    {
        for (var index = 0; index < conditions.Count; index++)
        {
            var condition = conditions[index];
            if (!condition.evaluate(playerData))
            {
                if (!string.IsNullOrEmpty(failText))
                {
                    chatManager.makeChatMessage(failText);
                    await Task.Delay(3000);

                    Debug.Log("Did delay 2");
                }

                return true;
            }
        }

        if (!string.IsNullOrEmpty(successText))
        {
            chatManager.makeChatMessage(successText);
            await Task.Delay(3000);

            Debug.Log("Did delay 3");
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