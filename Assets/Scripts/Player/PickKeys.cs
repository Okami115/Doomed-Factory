using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickKeys : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Red":
                inventory.KeyRed = true;
                break;

            case "Yellow":
                inventory.KeyYellow = true;
                break;

            case "Orange":
                inventory.KeyOrange = true;
                break;

            case "Blue":
                inventory.KeyBlue = true;
                break;

            case "Green":
                inventory.KeyGreen = true;
                break;

            case "White":
                SceneManager.LoadScene("Menu");
                Cursor.lockState = CursorLockMode.Confined;
                break;

            default:
                break;
        }
    }
}
