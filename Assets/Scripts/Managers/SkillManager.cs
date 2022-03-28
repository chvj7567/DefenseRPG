using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager
{
    GameObject[] _areaSkills = new GameObject[(int)Skill.Area.MaxCount];
    GameObject[] _buffSkills = new GameObject[(int)Skill.Buff.MaxCount];

    public void Init()
    {
        GameObject root = GameObject.Find("@Skill");
        if (root == null)
        {
            root = new GameObject { name = "@Skill" };

            string[] skillNames = Enum.GetNames(typeof(Skill.Area));
            for (int i = 0; i < skillNames.Length - 1; i++)
            {
                string path = $"Skill/Effect/{skillNames[i]}";

                GameObject go = MainManager.Resource.Instantiate(path);

                if (go != null)
                {
                    _areaSkills[i] = go;
                    go.transform.parent = root.transform;
                    go.SetActive(false);
                }
                else
                    Debug.Log($"SkillObject Missing! {path}");
            }

            UnityEngine.Object.DontDestroyOnLoad(root);
        }
    }

    public void StartSkill(Skill.Area type)
    {
        _areaSkills[(int)type].GetOrAddComponent<PlayerStat>();
        _areaSkills[(int)type].SetActive(false);
        _areaSkills[(int)type].SetActive(true);
    }
}
