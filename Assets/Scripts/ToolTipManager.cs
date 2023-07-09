using UnityEngine;

public class ToolTipManager : MonoBehaviour
{
    public ToolTip toolTip;

    private static ToolTipManager instance;

    private void Awake()
    {
        instance = this;
    }

    public static void Show(string header, string content)
    {
        Debug.Log("Show tooltip");
        instance.toolTip.setText(header, content);
        instance.toolTip.gameObject.SetActive(true);
    }

    public static void Hide()
    {
        instance.toolTip.gameObject.SetActive(false);
    }
}