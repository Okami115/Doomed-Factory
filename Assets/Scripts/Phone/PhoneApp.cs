using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PhoneApp : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField]  private List<GameObject> appScreen;
    private Color defaultColor;
   
    public bool isSelected { get; private set; }

    private void OnEnable()
    {
        defaultColor = _spriteRenderer.color;
        foreach (GameObject appObject in appScreen)
        {
            appObject.SetActive(false);
        }
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
        foreach (GameObject appObject in appScreen)
        {
            appObject.SetActive(interact);
        }
    }
    public void SelectApp(bool selection) => isSelected = selection;
}
