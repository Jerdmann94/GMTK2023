using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatUIManager : MonoBehaviour
{
    public PlayerData playerData;

    public List<TextMeshProUGUI> statUI;

    private void Start()
    {
        statUI[0].SetText(playerData.life.ToString());
        statUI[1].SetText(playerData.strength.ToString());
        statUI[2].SetText(playerData.intelligence.ToString());
        statUI[3].SetText(playerData.dexterity.ToString());
        
    }
}
