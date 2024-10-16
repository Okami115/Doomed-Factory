using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerToTP : MonoBehaviour
{
    int counter = 0;
    [SerializeField] private PlayerMovementNavMesh player;

    private void OnCollisionEnter(Collision collision)
    {
        counter++;

        if((counter % 2) == 0)
        {
            player.isTPOn = true;
        }
    }
}
