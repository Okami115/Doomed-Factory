using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeZone : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private float batterymultiplier;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
            inventory.Battery += batterymultiplier * Time.deltaTime;
    }
}
