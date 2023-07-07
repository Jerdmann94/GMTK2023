using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "Card/EffectOperatorSo", order = 1)]
public class EffectOperatorSO : ScriptableObject
{
    public EffectEnum effectEnum;
}

public enum EffectEnum
{
    GiveGold,
    GiveStrength
}