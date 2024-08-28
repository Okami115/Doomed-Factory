using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneInventory : MonoBehaviour
{
    [SerializeField] private PlayerMovemnet _player;
    [SerializeField] private VerticalLayoutGroup _group;

    private void OnEnable()
    {
        foreach (Keys key in _player.GetKeys())
        {
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
