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
        {
            MainManager.Audio.Play("Touch", Define.Audio.Effect);
            OnClickHandler.Invoke(eventData);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (OnDownHandler != null)
        {
            MainManager.Audio.Play("Touch", Define.Audio.Effect);
            OnDownHandler.Invoke(eventData);
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (OnUpHandler != null)
        {
            OnUpHandler.Invoke(eventData);
        }
    }
    void Update()
    {
        if (OnUpdateHandler != null)
            OnUpdateHandler.Invoke();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (OnBeginDragHandler != null)
        {
            MainManager.Audio.Play("Touch", Define.Audio.Effect);
            OnBeginDragHandler.Invoke(eventData);
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragHandler != null)
        {
            OnDragHandler.Invoke(eventData);
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (OnEndDragHandler != null)
        {
            MainManager.Audio.Play("Touch", Define.Audio.Effect);
            OnEndDragHandler.Invoke(eventData);
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (OnDropHandler != null)
        {
            MainManager.Audio.Play("Touch", Define.Audio.Effect);
            OnDropHandler.Invoke(eventData);
        }
    }
}
