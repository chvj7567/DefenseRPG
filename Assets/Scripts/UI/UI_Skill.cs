using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Skill : UI_Base
{
    public Image[] SkillSlot;
    public GameObject SkillIcon { get; set; }

    enum Images
    {
        SkillSpace1,
        SkillSpace2,
        SkillSpace3,
    }
    public override void Init()
    {
        SkillSlot = new Image[Enum.GetNames(typeof(Images)).Length];

        Bind<Image>(typeof(Images));

        for (int i = 0; i < SkillSlot.Length; i++)
        {
            SkillSlot[i] = GetImage(i);
            BindEvent(SkillSlot[i].gameObject, AddSkill, Define.UIEvent.Drop);
        }
    }

    public void AddSkill(PointerEventData eventData)
    {
        GameObject skillSpace = eventData.pointerEnter;

        if (SkillIcon != null)
        {
            GameObject skill = UsingSkill(SkillIcon.name);
            if (skill != null)
            {
                skill.transform.GetChild(0).SetParent(skillSpace.transform, false);
            }
            else
            {
                if (SkillIcon.name == Enum.GetName(typeof(Define.AreaSkill), (int)Define.AreaSkill.Snow))
                    MainManager.Skill.ShowIcon(MainManager.Skill.SnowIcon, skillSpace.transform);
                else if (SkillIcon.name == Enum.GetName(typeof(Define.AreaSkill), (int)Define.AreaSkill.Laser))
                    MainManager.Skill.ShowIcon(MainManager.Skill.LaserIcon, skillSpace.transform);
                else if (SkillIcon.name == Enum.GetName(typeof(Define.BuffSkill), (int)Define.BuffSkill.Strong))
                    MainManager.Skill.ShowIcon(MainManager.Skill.StrongIcon, skillSpace.transform);
                else if (SkillIcon.name == Enum.GetName(typeof(Define.BuffSkill), (int)Define.BuffSkill.FastAttack))
                    MainManager.Skill.ShowIcon(MainManager.Skill.FastAttackIcon, skillSpace.transform);
            }

            if (skillSpace.transform.childCount >= 2)
            {
                MainManager.Skill.HideIcon(skillSpace.transform.GetChild(0).gameObject);
            }

            SkillIcon = null;
        }
    }

    public GameObject UsingSkill(string name)
    {
        foreach (Image image in SkillSlot)
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
