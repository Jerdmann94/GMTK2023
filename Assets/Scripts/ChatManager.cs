using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatManager : MonoBehaviour
{
    private List<Message> messages = new List<Message>();
    public GameObject textPrefab;
    public Transform chatPanel;

    public void makeChatMessage(string t)
    {
        Message newMessage = new Message();
        newMessage.text = t;
        messages.Add(newMessage);
        var newText = Instantiate(textPrefab, chatPanel).GetComponent<TextMeshProUGUI>();
        newMessage.textObject = newText;
        newText.SetText(t);

        if (messages.Count >= 30)
        {
            var toDelete = messages[0];
            messages.Remove(toDelete);
            Destroy(toDelete.textObject.gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            makeChatMessage("a");
        }
    }
}

public class Message
{
    public string text;
    public TextMeshProUGUI textObject;
}