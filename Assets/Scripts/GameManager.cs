using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;
    void Start()
    {
        inventory.KeyRed = false;
        inventory.KeyGreen = false;
        inventory.KeyBlue = false;
        inventory.KeyOrange = false;
        inventory.KeyYellow = false;
    }

}
