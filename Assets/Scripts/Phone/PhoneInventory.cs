using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PhoneInventory : PhoneApp
{
    [SerializeField] private PlayerMovemnet _player;
    [SerializeField] private PlayerInputsReader _inputsReader;
    [SerializeField] private SpriteRenderer _itemImage;
    [SerializeField] private List<Keys> inventoryKeys;
    [SerializeField] private TextMeshPro itemName;
    [SerializeField] private TextMeshPro itemDescription;

    [FormerlySerializedAs("itemIndex")] [SerializeField]
    private int currentItemIndex = 0;

    private void OnEnable()
    {
        hasAppInteraction = true;
        inventoryKeys = _player.GetKeys();
        if (hasAppInteraction)
            _inputsReader.OnScroll += MouseScroll;
    }

    private void OnDisable()
    {
        
        if (hasAppInteraction)
            _inputsReader.OnScroll -= MouseScroll;
    }

    private void MouseScroll(float mouseY)
    {
        if (isOpen)
        {
            if (mouseY > 0)
            {
                ++currentItemIndex;
                ChechIndex();
            }
            else if (mouseY < 0)
            {
                --currentItemIndex;
                ChechIndex();
            }
        }
    }

    private void ChechIndex()
    {
        int appsLenght = inventoryKeys.Count;

        if (currentItemIndex >= appsLenght)
            currentItemIndex = appsLenght  - 1;

        if (currentItemIndex <= 0)
            currentItemIndex = 0;
    }

    void Update()
    {
        CheckSelection();
        
        if (isOpen)
        {
            ChechIndex();
            if (inventoryKeys.Count > 0)
            {
                _itemImage.sprite = inventoryKeys[currentItemIndex].KeyImage;
                itemName.text = inventoryKeys[currentItemIndex].name;
                itemDescription.text = inventoryKeys[currentItemIndex].description;
            }
            else
            {
                _itemImage.sprite = null;
                itemName.text = "Empty Inventory";
                itemDescription.text = "";
            }
        }
    }
}