using System;
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
        if (String.IsNullOrEmpty(t))
        {
            return;
        }

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

    public void ClearMessages()
    {
        foreach (Transform transform in chatPanel)
        {
            UnityEngine.Object.Destroy(transform.gameObject);
        }

        messages.Clear();
    }
}

public class Message
{
    public string text;
    public TextMeshProUGUI textObject;
}