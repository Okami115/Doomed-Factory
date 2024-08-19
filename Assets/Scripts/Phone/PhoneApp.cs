using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PhoneApp : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField]  private GameObject appScreen;
    private Color defaultColor;
   
    public bool isSelected { get; private set; }

    private void OnEnable()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = _spriteRenderer.color;
        appScreen.SetActive(false);
    }
    private void Update()
    {
        if (isSelected)
            _spriteRenderer.color = Color.green;
        else
            _spriteRenderer.color = defaultColor;
    }
    public void AppInteraction(bool interact)
    {
        appScreen.SetActive(interact);
        Debug.Log("App Interaction");
    }
    public void SelectApp(bool selection) => isSelected = selection;
}
