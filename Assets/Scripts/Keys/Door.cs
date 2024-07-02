using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private Keys _doorKey;
    [SerializeField] private PlayableDirector doorTimeline;
    [SerializeField] private PhoneControlle playerPhone;
    private bool isPlayerInRange;
    private bool isDoorOpen;

    public void Interact(List<Keys> keysList)
    {
        if (isPlayerInRange && !isDoorOpen)
        {
            if (keysList.Contains(_doorKey))
            {
                playerPhone.HidePhone();
                doorTimeline.Play();
                isDoorOpen = true;
                Destroy(this);
            }
            else
                AkSoundEngine.PostEvent("Play_SFX_Player_Interact_Door_Metal_Lock", gameObject);
        }
    }

    public void ReadyToInteract(bool ans)
    {
        isPlayerInRange = ans;
    }
}