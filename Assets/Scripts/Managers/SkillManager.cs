using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager
{
    GameObject[] _skills = new GameObject[(int)Define.Skill.MaxCount];

    public void Init()
    {
        GameObject root = GameObject.Find("@Skill");
        if (root == null)
        {
            root = new GameObject { name = "@Skill" };

            string[] skillNames = Enum.GetNames(typeof(Define.Skill));
            for (int i = 0; i < skillNames.Length - 1; i++)
            {
                string path = $"Skill/Effect/{skillNames[i]}";

                GameObject go = MainManager.Resource.Instantiate(path);

                if (go != null)
                {
                    _skills[i] = go;
                    go.transform.parent = root.transform;
                    go.SetActive(false);
                }
                else
                    Debug.Log($"SkillObject Missing! {path}");
            }

            UnityEngine.Object.DontDestroyOnLoad(root);
        }
    }

    public void StartSkill(Define.Skill type)
    {
        _skills[(int)type].SetActive(true);
    }

    public void EndSkill(Define.Skill type)
    {
        _skills[(int)type].SetActive(false);
    }
}
