using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void setUIText(string t)
    {
        text.SetText(t);
    }
}
