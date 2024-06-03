using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Door : MonoBehaviour
{
    [SerializeField] private Keys _doorKey;
    [SerializeField] private PlayableDirector doorTimeline;
    private bool isPlayerInRange;
    private PlayerInventory _playerInventory;

    public void Interact(List<Keys> keysList)
    {
        if (isPlayerInRange)
        {
            if (keysList.Contains(_doorKey))
                doorTimeline.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            isPlayerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            isPlayerInRange = false;
    }
}