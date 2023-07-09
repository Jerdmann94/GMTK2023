using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string header;
    public string text;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ToolTipManager.Show(header, text);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTipManager.Hide();
    }
}