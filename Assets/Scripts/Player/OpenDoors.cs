using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Red":
                if (inventory.KeyRed)
                    Destroy(collision.gameObject);
                break;

            case "Yellow":
                if (inventory.KeyYellow)
                    Destroy(collision.gameObject);
                break;

            case "Orange":
                if (inventory.KeyOrange)
                    Destroy(collision.gameObject);
                break;

            case "Blue":
                if (inventory.KeyBlue)
                    Destroy(collision.gameObject);
                break;

            case "Green":
                if (inventory.KeyGreen)
                    Destroy(collision.gameObject);
                break;

            default:
                break;
        }
    }
}
