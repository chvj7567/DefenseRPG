using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Skill : UI_Base
{
    GameStat _gameStat;
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
        _gameStat = MainManager.Game.Player.GetComponent<GameStat>();
        SkillSlot = new Image[Enum.GetNames(typeof(Images)).Length];

        Bind<Image>(typeof(Images));

        for (int i = 0; i < SkillSlot.Length; i++)
        {
            SkillSlot[i] = GetImage(i);
            BindEvent(SkillSlot[i].gameObject, AddSkill, Define.UIEvent.Drop);
        }

        LoadSkill(_gameStat.SkillSlot1, 1);
        LoadSkill(_gameStat.SkillSlot2, 2);
        LoadSkill(_gameStat.SkillSlot3, 3);
    }

    void LoadSkill(string skillSlot, int number)
    {
        if (skillSlot != null)
        {
            if (skillSlot == Enum.GetName(typeof(Define.AreaSkill), (int)Define.AreaSkill.Snow))
                MainManager.Skill.ShowIcon(MainManager.Skill.SnowIcon, SkillSlot[number - 1].transform);
            else if (skillSlot == Enum.GetName(typeof(Define.AreaSkill), (int)Define.AreaSkill.Laser))
                MainManager.Skill.ShowIcon(MainManager.Skill.LaserIcon, SkillSlot[number - 1].transform);
            else if (skillSlot == Enum.GetName(typeof(Define.BuffSkill), (int)Define.BuffSkill.Strong))
                MainManager.Skill.ShowIcon(MainManager.Skill.StrongIcon, SkillSlot[number - 1].transform);
            else if (skillSlot == Enum.GetName(typeof(Define.BuffSkill), (int)Define.BuffSkill.FastAttack))
                MainManager.Skill.ShowIcon(MainManager.Skill.FastAttackIcon, SkillSlot[number - 1].transform);
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

        SaveSkill();
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

    void SaveSkill()
    {
        for (int i = 0; i < SkillSlot.Length; i++)
        {
            Debug.Log(SkillSlot[i].transform.childCount);
            if (SkillSlot[i].transform.childCount > 0)
            {
                switch (i)
                {
                    case 0:
                        _gameStat.SetSkillSlot1(SkillSlot[i].transform.GetChild(0).name);
                        break;
                    case 1:
                        _gameStat.SetSkillSlot2(SkillSlot[i].transform.GetChild(0).name);
                        break;
                    case 2:
                        _gameStat.SetSkillSlot3(SkillSlot[i].transform.GetChild(0).name);
                        break;
                }
            }
            else
            {
                switch (i)
                {
                    case 0:
                        _gameStat.SetSkillSlot1(null);
                        break;
                    case 1:
                        _gameStat.SetSkillSlot2(null);
                        break;
                    case 2:
                        _gameStat.SetSkillSlot3(null);
                        break;
                }
            }
        }
    }
}
