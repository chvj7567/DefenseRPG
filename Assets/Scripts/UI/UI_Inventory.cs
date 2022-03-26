using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Inventory : UI_Base
{
    PlayerStat _playerStat;
    Image[] _skillSpace;
    List<GameObject> _skillIcon;

    bool _isInit;
    enum Images
    {
        SkillSpace1,
        SkillSpace2,
        SkillSpace3,
        SkillSpace4,
    }

    public override void Init()
    {
        if (!_isInit)
        {
            _isInit = true;
            _playerStat = MainManager.Game.Player.GetComponent<PlayerStat>();
            _skillSpace = new Image[Enum.GetNames(typeof(Images)).Length];
            _skillIcon = new List<GameObject>();

            Bind<Image>(typeof(Images));

            for (int i = 0; i < _skillSpace.Length; i++)
            {
                _skillSpace[i] = GetImage(i);
                BindEvent(_skillSpace[i].gameObject, BeginDragSkill, Define.UIEvent.Drag);
                BindEvent(_skillSpace[i].gameObject, EndDragSkill, Define.UIEvent.Up);
            }
        }
    }
    void OnEnable()
    {
        if (_playerStat == null)
        {
            Init();
        }

        InputSkill();

    }

    void BeginDragSkill(PointerEventData eventData)
    {
        Transform skill = eventData.pointerDrag.transform.GetChild(0);

        skill.position = eventData.position;

        MainManager.UI.Skill.GetComponent<UI_Skill>().SkillICon = skill.gameObject;
    }

    void EndDragSkill(PointerEventData eventData)
    {
        Transform skill = eventData.pointerDrag.transform.GetChild(0);

        skill.localPosition = Vector3.zero;
    }

    public void InputSkill()
    {
        if (_playerStat.Snow != 0 && !UsingSkill(Enum.GetName(typeof(Define.Skill), (int)Define.Skill.Snow)))
        {
            GameObject go = MainManager.Resource.Instantiate("Skill/Icon/Snow", GetLastSpace().transform);
            if (go != null)
                _skillIcon.Add(go);
        }

        if (_playerStat.Strong != 0 && !UsingSkill(Enum.GetName(typeof(Define.Skill), (int)Define.Skill.Strong)))
        {
            GameObject go = MainManager.Resource.Instantiate("Skill/Icon/Strong", GetLastSpace().transform);
            if (go != null)
                _skillIcon.Add(go);
        }
    }

    public GameObject GetLastSpace()
    {
        foreach (Image image in _skillSpace)
        {
            if (image.transform.childCount == 0)
            {
                return image.gameObject;
            }
        }

        return null;
    }

    public bool UsingSkill(string skill)
    {
        foreach (GameObject go in _skillIcon)
        {
            if (go.name == skill)
                return true;
        }

        return false;
    }
}
