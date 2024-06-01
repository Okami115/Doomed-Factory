using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Keys _doorKey;
    private bool isPlayerInRange;
    private PlayerInventory _playerInventory;

    public void Interact(List<Keys> keysList)
    {
        if (isPlayerInRange)
        {
            foreach (Keys key in keysList)
            {
                if (key == _doorKey)
                    Destroy(gameObject);
            }
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