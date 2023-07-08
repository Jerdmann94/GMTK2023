using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatUIManager : MonoBehaviour
{
    public PlayerData playerData;

    public List<TextMeshProUGUI> statUI;

    private void Start()
    {
        statUI[0].SetText(playerData.Life.ToString());
        statUI[1].SetText(playerData.Strength.ToString());
        statUI[2].SetText(playerData.Intelligence.ToString());
        statUI[3].SetText(playerData.Dexterity.ToString());
    }
}