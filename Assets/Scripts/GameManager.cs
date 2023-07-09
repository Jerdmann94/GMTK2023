using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CardManager cardManager;

    public GameObject gameWinObj;

    public GameObject gameLostObj;

    public GameObject startScreenObj;

    public PlayerData playerData;

    // Start is called before the first frame update

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
        Debug.Log("start game");
        playerData.initStats();
        cardManager.initDeck();
        startScreenObj.SetActive(false);
        gameWinObj.SetActive(false);
        gameLostObj.SetActive(false);
    }

    public void restartGame()
    {
        Debug.Log("start game");
        playerData.initStats();
        cardManager.initDeck();
        startScreenObj.SetActive(false);
        gameWinObj.SetActive(false);
        gameLostObj.SetActive(false);
    }
}