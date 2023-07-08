using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "Card/EffectSO")]
public class EffectSO : ScriptableObject
{
    public EffectOperator op;
    public string key;
    public int value;
}

public enum EffectOperator
{
    IncreaseState,
    ReduceState,
    IncreasePlayer,
    ReducePlayer,
    GiveItem,
    UseItem
}