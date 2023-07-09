using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatUIManager : MonoBehaviour
{
    public PlayerData playerData;

    public List<TextMeshProUGUI> statUI;

    private void Start()
    {
        SetStats();
    }

    public void SetStats()
    {
        statUI[0].SetText(playerData.Life.ToString());
        statUI[1].SetText(playerData.Strength.ToString());
        statUI[2].SetText(playerData.Intelligence.ToString());
        statUI[3].SetText(playerData.Dexterity.ToString());
        statUI[4].SetText(playerData.Mana.ToString());
        statUI[5].SetText(playerData.Food.ToString());
        statUI[6].SetText(playerData.Gold.ToString());
    }
}