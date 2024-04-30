using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PhoneButton : MonoBehaviour, IPointerDownHandler , IPointerUpHandler , IPointerClickHandler, IPointerEnterHandler , IPointerExitHandler
{
   protected SpriteRenderer _spriteRenderer;
    private Color defaultColor;
    private bool _isMouseInside;
    public bool isMouseInside { get; private set;}

    private void OnEnable()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = _spriteRenderer.color;
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
        _spriteRenderer.color = Color.green;
        isMouseInside = true;
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
        _spriteRenderer.color = defaultColor;
        isMouseInside = false;
    }
}
