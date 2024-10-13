using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatTextController : ScriptableObject
{
    private List<string> ChatTexts = new List<string>();
    private int chatIndex = -1;

    public string GetNextChatText()
    {
        chatIndex++;
        return ChatTexts[chatIndex];
    }
}
