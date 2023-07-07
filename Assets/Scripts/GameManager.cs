using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CardManager cardManager;
    // Start is called before the first frame update
    void Start()
    {
        cardManager.initDeck();
    }

    
}
