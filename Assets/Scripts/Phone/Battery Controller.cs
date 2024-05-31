using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryController : MonoBehaviour
{
    [SerializeField] private Transform BatteryUI;
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private float BatteryMultiplier;
    [SerializeField] private Light light;
    [SerializeField] private GameObject lightObject;

    private Vector3 maxLevelBattery;
    private Vector3 currentLevelBattery;

    private void Start()
    {
        maxLevelBattery = BatteryUI.transform.localScale;
        currentLevelBattery = maxLevelBattery;
        inventory.Battery = 100;
    }

    void Update()
    {
        if(light.isActiveAndEnabled)
            inventory.Battery -= BatteryMultiplier * Time.deltaTime;

        currentLevelBattery.z = (inventory.Battery * maxLevelBattery.z) / 100;

        if (inventory.Battery < 5)
            lightObject.SetActive(false);
        else 
            lightObject.SetActive(true);

        BatteryUI.localScale = currentLevelBattery;
    }
}
