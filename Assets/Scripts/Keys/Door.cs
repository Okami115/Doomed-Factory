using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private Keys _doorKey;
    [SerializeField] private Animator doorTimeline;
    [SerializeField] private float waitTime;
    [SerializeField] private Transform doorCamera;
    
    private bool isPlayerInRange;
    private bool isDoorOpen;
    private bool corrutineRuning = false;

    private void Update()
    {
        Quaternion direction = Quaternion.Inverse(transform.rotation) * Camera.main.transform.rotation;

        doorCamera.localEulerAngles = new Vector3(direction.eulerAngles.x, 
                                                    direction.eulerAngles.y - 270, 
                                                    direction.eulerAngles.z);

        Vector3 distance = transform.InverseTransformPoint(Camera.main.transform.position);
        //doorCamera.localPosition = -new Vector3(distance.x, -distance.y, distance.z);
    }

    public void Interact(List<Keys> keysList)
    {
        if (isPlayerInRange && !isDoorOpen)
        {
            if (keysList.Contains(_doorKey) || _doorKey == null)
            {
                doorTimeline.SetTrigger("OnOpenDoor");
                
                if (!corrutineRuning)
                    StartCoroutine(PlayOpenSound(waitTime));
                
                isDoorOpen = true;
            }
            else
                AkSoundEngine.PostEvent("Play_SFX_Player_Interact_Door_Metal_Lock", gameObject);
        }
    }
    
    public IEnumerator PlayOpenSound(float waitTime)
    {
        corrutineRuning = true;
        yield return new WaitForSeconds(waitTime);
        AkSoundEngine.PostEvent("Play_SFX_Player_Interact_Door_Metal_Unlock", gameObject);
        yield return null;
        Destroy(this);
        corrutineRuning = false;
    }

    public void ReadyToInteract(bool ans)
    {
        isPlayerInRange = ans;
    }
}