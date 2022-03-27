using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_InventorySlot : UI_Base
{
    GameObject _dragSkill;
    Transform _originPos;

    public override void Init()
    {
        BindEvent(gameObject, BeginDragSkill, Define.UIEvent.BeginDrag);
        BindEvent(gameObject, DragSkill, Define.UIEvent.Drag);
        BindEvent(gameObject, EndDragSkill, Define.UIEvent.EndDrag);
        BindEvent(gameObject, DropSkill, Define.UIEvent.Drop);
    }

    void CheckSkill(GameObject skill)
    {
        _dragSkill = skill;
        if (_dragSkill == null || _dragSkill.transform.childCount == 0)
        {
            _dragSkill = null;
            return;
        }

        _originPos = _dragSkill.transform;
        _dragSkill = _dragSkill.transform.GetChild(0).gameObject;
    }

    void BeginDragSkill(PointerEventData eventData)
    {
        CheckSkill(eventData.pointerEnter);
        if (_dragSkill == null)
            return;
        _dragSkill.transform.SetParent(gameObject.transform.parent.parent, false);
        
        MainManager.UI.Inventory.GetComponent<UI_Inventory>().DragSkill = _dragSkill;
        MainManager.UI.Inventory.GetComponent<UI_Inventory>().OriginPos = _originPos;
    }

    void DragSkill(PointerEventData eventData)
    {
        if (_dragSkill == null)
            return;
        _dragSkill.transform.position = eventData.position;

        MainManager.UI.Skill.GetComponent<UI_Skill>().SkillICon = _dragSkill;
    }

    void EndDragSkill(PointerEventData eventData)
    {
        if (_dragSkill == null || MainManager.UI.Inventory.GetComponent<UI_Inventory>().IsDrop)
            return;

        _dragSkill.transform.SetParent(_originPos);
        _dragSkill.transform.localPosition = Vector3.zero;

        MainManager.UI.Inventory.GetComponent<UI_Inventory>().DragSkill = null;
        MainManager.UI.Inventory.GetComponent<UI_Inventory>().OriginPos = null;
    }

    void DropSkill(PointerEventData eventData)
    {
        MainManager.UI.Inventory.GetComponent<UI_Inventory>().IsDrop = true;

        if (eventData.pointerDrag == null)
            return;

        MainManager.UI.Inventory.GetComponent<UI_Inventory>().SwapSkill(eventData.pointerDrag, gameObject);

        MainManager.UI.Inventory.GetComponent<UI_Inventory>().DragSkill = null;
        MainManager.UI.Inventory.GetComponent<UI_Inventory>().OriginPos = null;
    }
}
