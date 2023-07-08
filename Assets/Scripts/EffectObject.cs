using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    public void Resolve(PlayerData player, CardObject card) {}
    
    //don't mutate data directly
}
