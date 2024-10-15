using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Chat Text Controller", menuName = "Custom/ChatTextController")]
public class ChatTextController : ScriptableObject
{
    public List<string> ChatTexts = new List<string>();
    private int chatIndex = 0;

    public string GetNextChatText()
    {
        chatIndex = Random.Range(0,ChatTexts.Count);
        return ChatTexts[chatIndex];
    }
}
