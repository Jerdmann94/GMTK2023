using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CardManager cardManager;

    public GameObject gameWinObj;

    public GameObject gameLostObj;

    public GameObject startScreenObj;

    public PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        cardManager.initDeck();
    }

    public void gameLost()
    {
        gameLostObj.SetActive(true);
    }

    public void gameWin()
    {
        gameWinObj.SetActive(true);
    }

    public void startGame()
    {
        playerData.initStats();
        cardManager.initDeck();
        startScreenObj.SetActive(false);
        gameWinObj.SetActive(false);
        gameLostObj.SetActive(false);
    }
}