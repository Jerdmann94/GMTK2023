using UnityEngine;
using UnityEngine.UI;

public class RoomObjectManager : MonoBehaviour
{
    public Image spriteLoc;
    public Image playerLoc;
    public Sprite fighter;
    public Sprite rogue;
    public Sprite wizard;

    public void spawnRoomSprite(Sprite sprite)
    {
        var tempColor = spriteLoc.color;
        tempColor.a = 1f;
        Debug.Log(sprite);
        if (sprite == null)
        {
            spriteLoc.sprite = null;
            tempColor.a = 0f;
            spriteLoc.color = tempColor;

            return;
        }

        spriteLoc.color = tempColor;
        spriteLoc.sprite = sprite;
    }

    public void spawnPlayerSprite(int i)
    {
        if (i == 0)
        {
            playerLoc.sprite = fighter;
        }

        if (i == 1)
        {
            playerLoc.sprite = rogue;
        }

        if (i == 2)
        {
            playerLoc.sprite = wizard;
        }

        Debug.Log("spawn player " + i);
    }
}