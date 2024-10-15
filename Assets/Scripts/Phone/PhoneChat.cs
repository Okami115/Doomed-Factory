using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhoneChat : PhoneApp
{
    [SerializeField] private List<ChatTextController> messages = new List<ChatTextController>();
    [SerializeField] private List<TextMeshPro> chatTexts = new List<TextMeshPro>();
    [SerializeField] private TextMeshPro questText;
    private int zoneIndex = 0;
    private float timerMaxTime = 2.0f;
    private float currentTime = 0f;
    private void FixedUpdate()
    {
        if (currentTime >= timerMaxTime)
        {
            UpdateChatTexts(messages[zoneIndex].GetNextChatText());
            currentTime = 0f;
        }
        else
            currentTime += Time.deltaTime;
    }
    private void UpdateChatTexts(string newmsg) 
    {
        for (int i = chatTexts.Count - 1; i >= 0; i--)
        {
            if (i != 0) 
            {
                chatTexts[i].text = chatTexts[i - 1].text;
            }
            else
                chatTexts[i].text = newmsg;
        }
    }
    public void ChangeZoneIndex(int zoneIndex) 
    {
        this.zoneIndex = zoneIndex;
    }
    public void SetQuestText(string newQuest) 
    {
        questText.text = newQuest;
    }
}
