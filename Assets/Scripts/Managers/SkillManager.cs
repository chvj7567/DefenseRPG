using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager
{
    public GameObject SnowIcon { get; private set; }
    public GameObject LaserIcon { get; private set; }
    public GameObject StrongIcon { get; private set; }
    public GameObject FastAttackIcon { get; private set; }
    public GameObject Root { get; private set; }

    public GameObject Effect { get; private set; }
    public GameObject Icon { get; private set; }

    public GameObject[] AreaSkills = new GameObject[(int)Define.AreaSkill.MaxCount];

    public void Init()
    {
        Root = GameObject.Find("@Skill_Root");

        if (Root == null)
        {
            Root = new GameObject { name = "@Skill_Root" };
        }
        UnityEngine.Object.DontDestroyOnLoad(Root);

        Effect = new GameObject { name = "Effect" };
        Icon = new GameObject { name = "Icon" };
        Effect.transform.SetParent(Root.transform);
        Icon.transform.SetParent(Root.transform);

        string[] skillNames = Enum.GetNames(typeof(Define.AreaSkill));
        for (int i = 0; i < skillNames.Length - 1; i++)
        {
            string path = $"Skill/Effect/{skillNames[i]}";

            GameObject go = MainManager.Resource.Instantiate(path);

            if (go != null)
            {
                AreaSkills[i] = go;
                go.transform.parent = Util.FindChild(Root, "Effect").transform;
                ParticleSystem[] particles = go.GetComponentsInChildren<ParticleSystem>();
                foreach (ParticleSystem particle in particles)
                    particle.Stop();
            }
            else
                Debug.Log($"SkillObject Missing! {path}");
        }

        skillNames = Enum.GetNames(typeof(Define.AreaSkill));
        for (int i = 0; i < skillNames.Length - 1; i++)
        {
            string path = $"Skill/Icon/{skillNames[i]}";

            GameObject go = MainManager.Resource.Instantiate(path);

            if (go != null)
            {
                Image[] images = go.GetComponentsInChildren<Image>();
                foreach (Image image in images)
                    image.raycastTarget = false;
                go.transform.SetParent(Util.FindChild(Root, "Icon").transform);

                if (skillNames[i] == Enum.GetName(typeof(Define.AreaSkill), (int)Define.AreaSkill.Snow))
                    SnowIcon = go;
                else if (skillNames[i] == Enum.GetName(typeof(Define.AreaSkill), (int)Define.AreaSkill.Laser))
                    LaserIcon = go;

                go.SetActive(false);
            }
            else
                Debug.Log($"SkillObject Missing! {path}");
        }

        skillNames = Enum.GetNames(typeof(Define.BuffSkill));
        for (int i = 0; i < skillNames.Length - 1; i++)
        {
            string path = $"Skill/Icon/{skillNames[i]}";

            GameObject go = MainManager.Resource.Instantiate(path);

            if (go != null)
            {
                Image[] images = go.GetComponentsInChildren<Image>();
                foreach (Image image in images)
                    image.raycastTarget = false;
                go.transform.SetParent(Util.FindChild(Root, "Icon").transform);

                if (skillNames[i] == Enum.GetName(typeof(Define.BuffSkill), (int)Define.BuffSkill.Strong))
                    StrongIcon = go;
                else if (skillNames[i] == Enum.GetName(typeof(Define.BuffSkill), (int)Define.BuffSkill.FastAttack))
                    FastAttackIcon = go;

                go.SetActive(false);
            }
            else
                Debug.Log($"SkillObject Missing! {path}");
        }
    }

    public void StartSkill(Define.AreaSkill type)
    {
        AreaSkills[(int)type].GetOrAddComponent<PlayerStat>();
        ParticleSystem[] particles = AreaSkills[(int)type].GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem particle in particles)
            particle.Play();
    }

    public void ShowIcon(GameObject icon, Transform parent)
    {
        icon.transform.SetParent(parent, false);
        icon.SetActive(true);
    }

    public void HideIcon(GameObject icon)
    {
        icon.transform.SetParent(Icon.transform, false);
        icon.SetActive(false);
    }
}
