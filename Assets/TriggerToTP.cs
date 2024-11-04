using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerToTP : MonoBehaviour
{
    int counter = 0;
    [SerializeField] private PlayerMovementNavMesh player;
    [SerializeField] private Image background;
    [SerializeField] private GameObject Loop;
    [SerializeField] private List<GameObject> LoopDisableObjects = new List<GameObject>();

    private void OnCollisionEnter(Collision collision)
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

            player.isTPOn = true;
            background.color = new Color(0, 0, 0, 255);
            Destroy(this.gameObject);
        }
    }
}