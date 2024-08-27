using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;

public class PhoneController : MonoBehaviour
{
    [SerializeField] private PlayerInputsReader _inputsReader;
    [SerializeField] private List<PhoneApp> _apps = new List<PhoneApp>();
    [SerializeField] private int currentSelectedApp = 0;
    [SerializeField] private bool isActive = false;

    private void Start()
    {
        gameObject.SetActive(isActive);
        
        _inputsReader.OnScroll += MouseScroll;
        _inputsReader.OnPlayerInteract += OnOpenApp;
        _inputsReader.OnPlayerExitApp += OnCloseApp;
        _inputsReader.OnPlayerOpenPhone += UsePhone;
    }

    private void UsePhone()
    {
        isActive = !isActive;
        gameObject.SetActive(isActive);
    }

    private void OnOpenApp()
    {
        if (isActive)
        {
            foreach (PhoneApp app in _apps)
            {
                if (app.isSelected)
                    app.AppInteraction(true);
            }
        }
    }

    private void OnCloseApp()
    {
        foreach (PhoneApp app in _apps)
        {
            if (app.isSelected)
                app.AppInteraction(false);
        }
    }
    private void MouseScroll(float mouseY)
    {
        if (!isActive)
            return;
        
        if (mouseY > 0)
        {
            currentSelectedApp++;
            ChechIndex();
        }
        else if (mouseY < 0)
        {
            currentSelectedApp--;
            ChechIndex();
        }
    }

    private void ChechIndex()
    {
        int appsLenght = _apps.Count;
        
        if (currentSelectedApp >= appsLenght)
            currentSelectedApp = appsLenght - 1;
        
        if (currentSelectedApp < 0)
            currentSelectedApp = 0;
    }

    void Update()
    {
        int appsLenght = _apps.Count;
      
        for (int i = 0; i < appsLenght; i++)
        {
            if (currentSelectedApp == i)
                _apps[i].SelectApp(true);
            else
                _apps[i].SelectApp(false);
        }
    }
}
