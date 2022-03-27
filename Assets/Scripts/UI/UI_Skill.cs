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
            BindEvent(_skillSpace[i].gameObject, AddSkill, Define.UIEvent.Drop);
        }
    }

    public void AddSkill(PointerEventData eventData)
    {
        GameObject skillSpace = eventData.pointerEnter;
        if (SkillICon != null)
        {
            GameObject skill = UsingSkill(SkillICon.name);
            if (skill != null)
            {
                MainManager.Game.Despawn(skill.transform.GetChild(0).gameObject);
            }

            GameObject go = MainManager.Resource.Instantiate($"Skill/Icon/{SkillICon.name}", skillSpace.transform);
            go.GetComponent<Image>().raycastTarget = false;

            if (skillSpace.transform.childCount >= 2)
            {
                MainManager.Game.Despawn(skillSpace.transform.GetChild(0).gameObject);
            }

            SkillICon = null;
        }
    }

    public GameObject UsingSkill(string name)
    {
        foreach (Image image in _skillSpace)
        {
            if (image.transform.childCount != 0)
            {
                if (image.transform.GetChild(0).name == name)
                    return image.gameObject;
            }
        }

        return null;
    }
}
