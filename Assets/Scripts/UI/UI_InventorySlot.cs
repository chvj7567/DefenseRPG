using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_InventorySlot : UI_Base
{
    UI_Inventory _Inventory;

    public override void Init()
    {
        _Inventory = MainManager.UI.Inventory.GetComponent<UI_Inventory>();
        BindEvent(gameObject, BeginDragSkill, Define.UIEvent.BeginDrag);
        BindEvent(gameObject, DragSkill, Define.UIEvent.Drag);
        BindEvent(gameObject, EndDragSkill, Define.UIEvent.EndDrag);
        BindEvent(gameObject, DropSkill, Define.UIEvent.Drop);
    }

    void CheckSkill(GameObject skill)
    {
        _Inventory.DragSkill = skill;
        if (_Inventory.DragSkill == null || _Inventory.DragSkill.transform.childCount == 0)
        {
            _Inventory.DragSkill = null;
            _Inventory.OriginPos = null;
            return;
        }

        _Inventory.OriginPos = _Inventory.DragSkill.transform;
        _Inventory.DragSkill = _Inventory.DragSkill.transform.GetChild(0).gameObject;
    }

    void BeginDragSkill(PointerEventData eventData)
    {
        _Inventory.DragSkill = null;
        _Inventory.OriginPos = null;
        _Inventory.IsDrop = false;

        CheckSkill(eventData.pointerEnter);
        if (_Inventory.DragSkill == null)
            return;
        _Inventory.DragSkill.transform.SetParent(gameObject.transform.parent.parent, false);
    }

    void DragSkill(PointerEventData eventData)
    {
        if (_Inventory.DragSkill == null)
            return;
        _Inventory.DragSkill.transform.position = eventData.position;

        MainManager.UI.Skill.GetComponent<UI_Skill>().SkillICon = _Inventory.DragSkill;
    }

    void EndDragSkill(PointerEventData eventData)
    {
        if (_Inventory.DragSkill == null || _Inventory.IsDrop)
            return;

        _Inventory.DragSkill.transform.SetParent(_Inventory.OriginPos);
        _Inventory.DragSkill.transform.localPosition = Vector3.zero;
    }

    void DropSkill(PointerEventData eventData)
    {
        MainManager.UI.Inventory.GetComponent<UI_Inventory>().IsDrop = true;

        if (eventData.pointerDrag == null)
            return;

        MainManager.UI.Inventory.GetComponent<UI_Inventory>().SwapSkill(eventData.pointerDrag, gameObject);
    }
}
