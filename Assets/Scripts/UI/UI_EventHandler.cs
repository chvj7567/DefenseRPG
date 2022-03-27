using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Action<PointerEventData> OnClickHandler = null;
    public Action<PointerEventData> OnDownHandler = null;
    public Action<PointerEventData> OnUpHandler = null;
    public Action<PointerEventData> OnBeginDragHandler = null;
    public Action<PointerEventData> OnDragHandler = null;
    public Action<PointerEventData> OnEndDragHandler = null;
    public Action<PointerEventData> OnDropHandler = null;

    public Action OnUpdateHandler = null; 

    public void OnPointerClick(PointerEventData eventData)
    {
        if (OnClickHandler != null)
            OnClickHandler.Invoke(eventData);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (OnDownHandler != null)
            OnDownHandler.Invoke(eventData);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (OnUpHandler != null)
            OnUpHandler.Invoke(eventData);
    }
    void Update()
    {
        if (OnUpdateHandler != null)
            OnUpdateHandler.Invoke();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (OnBeginDragHandler != null)
            OnBeginDragHandler.Invoke(eventData);
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragHandler != null)
            OnDragHandler.Invoke(eventData);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (OnEndDragHandler != null)
            OnEndDragHandler.Invoke(eventData);
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (OnDropHandler != null)
            OnDropHandler.Invoke(eventData);
    }
}
