using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ToolTip : MonoBehaviour
{
    public TextMeshProUGUI headerField;

    public TextMeshProUGUI contentfield;

    public LayoutElement element;

    public int characterWrapLimit;


    public void setText(string headerText, string content)
    {
        headerField.SetText(headerText);
        contentfield.SetText(content);

        int headerLength = headerField.text.Length;
        int contentLength = contentfield.text.Length;
        element.enabled = (headerLength > characterWrapLimit || contentLength > characterWrapLimit);
    }

    private void Update()
    {
        Vector2 position = Input.mousePosition;
        transform.position = position;
    }
}