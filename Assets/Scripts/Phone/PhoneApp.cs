using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PhoneApp : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    [SerializeField] protected List<GameObject> appScreen;
    protected Color defaultColor;

    public string AkSoundPositiveInteraction;
    public string AkSoundNegativeInteraction;
    public bool isSelected { get; private set; }
    public bool isOpen { get; set; }
    public bool hasAppInteraction { get; set; }

    private void OnEnable()
    {
        Debug.Log(gameObject.name);
        _spriteRenderer.color = Color.white;
        defaultColor = _spriteRenderer.color;
        foreach (GameObject appObject in appScreen)
        {
            appObject.SetActive(false);
        }
    }

    private void Update()
    {
        CheckSelection();
    }

    protected void CheckSelection()
    {
        if (isSelected)
        {
            _spriteRenderer.color = Color.green;
        }

        else
            _spriteRenderer.color = defaultColor;
    }

    public void AppInteraction(bool interact)
    {
        isOpen = interact;
        if (interact)
        {
            if (AkSoundPositiveInteraction != null)
                AkSoundEngine.PostEvent(AkSoundPositiveInteraction, gameObject);
        }
        else
        {
            if (AkSoundNegativeInteraction != null)
                AkSoundEngine.PostEvent(AkSoundNegativeInteraction, gameObject);
        }

        foreach (GameObject appObject in appScreen)
        {
            appObject.SetActive(interact);
        }
    }

    public void SelectApp(bool selection) => isSelected = selection;
}