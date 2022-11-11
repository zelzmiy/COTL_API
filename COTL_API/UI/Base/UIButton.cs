﻿using UnityEngine;
using UnityEngine.EventSystems;

namespace COTL_API.UI;
public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public delegate void ButtonAction();

    /// <summary>
    /// UIButton cursor event. You can subscribe void methods with no parameters to it.
    /// </summary>
    public event ButtonAction OnClick, OnCursorEnter, OnCursorExit;

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnCursorEnter?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnCursorExit?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnClick?.Invoke();
    }
}
