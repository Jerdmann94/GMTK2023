using UnityEngine;
using UnityEngine.UI;

public class RoomObjectManager : MonoBehaviour
{
    public Image spriteLoc;

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
}