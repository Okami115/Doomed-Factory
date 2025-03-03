using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerToTP : MonoBehaviour
{
    int counter = 0;
    [SerializeField] private PlayerMovementNavMesh player;
    [SerializeField] private Image background;
    [SerializeField] private GameObject Loop;
    [SerializeField] private PhoneChat phoneChat;
    [SerializeField] private List<GameObject> LoopDisableObjects = new List<GameObject>();
    [SerializeField] private string _loopSoundName;

    private void OnTriggerEnter(Collider other)
    {
        counter++;

        if ((counter % 2) == 0)
        {
            Loop.SetActive(true);
            if (LoopDisableObjects != null && LoopDisableObjects.Count > 0)
            {
                foreach (GameObject objec in LoopDisableObjects)
                {
                    if (objec.activeInHierarchy)
                        objec.SetActive(false);
                }
            }

            if (phoneChat != null)
            {
                phoneChat.ChangeZoneIndex(2);
                phoneChat.SetQuestText("Busca la forma de Salir");
            }
            
            player.isTPOn = true;
            background.color = new Color(0, 0, 0, 255);
            AkSoundEngine.PostEvent(_loopSoundName, gameObject);
            Destroy(this.gameObject);
        }
    }
}