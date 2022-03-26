using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Skill : UI_Base
{
    Image[] _skillSpace;
    public GameObject SkillICon { get; set; }

    enum Images
    {
        SkillSpace1,
        SkillSpace2,
        SkillSpace3,
    }
    public override void Init()
    {
        _skillSpace = new Image[Enum.GetNames(typeof(Images)).Length];

        Bind<Image>(typeof(Images));

        for (int i = 0; i < _skillSpace.Length; i++)
        {
            _skillSpace[i] = GetImage(i);
            BindEvent(_skillSpace[i].gameObject, AddSkill, Define.UIEvent.Enter);
        }
    }

    public void AddSkill(PointerEventData eventData)
    {
        if (SkillICon != null)
        {
            MainManager.Resource.Instantiate($"Skill/Icon/{SkillICon.name}", eventData.pointerEnter.transform);
        }

        SkillICon = null;
    }
}
