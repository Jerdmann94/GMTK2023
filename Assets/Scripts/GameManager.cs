using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CardManager cardManager;

    public GameObject gameWinObj;

    public GameObject gameLostObj;

    public GameObject startScreenObj;

    public PlayerData playerData;
    public ChatManager chatManager;

    // Start is called before the first frame update

    public void gameLost()
    {
        StartCoroutine(GameOver());
    }

    private IEnumerator GameOver()
    {
        chatManager.makeChatMessage("You are dead!!");
        yield return new WaitForSeconds(3);
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
        startGame();
    }
}