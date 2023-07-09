using UnityEngine;
using UnityEngine.UI;

public class HandScript : MonoBehaviour
{
    public Image image;

    public void setUIText(string t)
    {
        //text.SetText(t);
    }

    public void setUIImage(Sprite s, bool isInverted)
    {
        image.sprite = s;
        image.transform.eulerAngles = new Vector3(0, 0, 0);
        if (isInverted)
        {
//            Debug.Log(s + "should be inverted");
            image.transform.eulerAngles = new Vector3(0, 0, -180);
            //image.transform.rotation.SetLookRotation(new Vector3(0,0,-180),Vector3.up);
        }
    }
}