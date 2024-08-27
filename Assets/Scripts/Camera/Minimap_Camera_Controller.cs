using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameZones
{
    Entrance,
    Red_Zone,
    Blue_Zone
}
public class Minimap_Camera_Controller : MonoBehaviour
{
    [SerializeField] Camera minimapCamera;
    [SerializeField] Transform entrnacePos;
    [SerializeField] Transform Red_ZonePos;
    [SerializeField] Transform BlueZone_ZonePos;

    [SerializeField] private GameZones currentZone = GameZones.Entrance;
    
   

    public void SetMiniMapCameraPosition(GameZones newZone) => currentZone = newZone;

    private void Update()
    {
        switch (currentZone)
        {
            case GameZones.Entrance:
                minimapCamera.transform.position = entrnacePos.position;
                break;
            case GameZones.Red_Zone:
                minimapCamera.transform.position = Red_ZonePos.position;
                break;
            case GameZones.Blue_Zone:
                minimapCamera.transform.position = BlueZone_ZonePos.position;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
