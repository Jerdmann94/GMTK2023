using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject
{
    public int effectValue;
    public EffectEnum effectEnum;
    public EffectObject(EffectSO effectSo)
    {
        effectValue = effectSo.effectValue;
        effectEnum = effectSo.effectSo.effectEnum;
    }
}
