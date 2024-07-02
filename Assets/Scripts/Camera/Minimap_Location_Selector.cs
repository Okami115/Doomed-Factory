using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap_Location_Selector : MonoBehaviour
{
    [SerializeField] private GameZones selectionZone;
    [SerializeField] private Minimap_Camera_Controller minimap;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            minimap.SetMiniMapCameraPosition(selectionZone);
    }
}
