using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}




