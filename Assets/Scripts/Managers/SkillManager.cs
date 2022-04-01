using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager
{
    GameObject[] _areaSkills = new GameObject[(int)Define.AreaSkill.MaxCount];

    public void Init()
    {
        GameObject root = GameObject.Find("@Skill");
        if (root == null)
        {
            root = new GameObject { name = "@Skill" };

            string[] skillNames = Enum.GetNames(typeof(Define.AreaSkill));
            for (int i = 0; i < skillNames.Length - 1; i++)
            {
                string path = $"Skill/Effect/{skillNames[i]}";

                GameObject go = MainManager.Resource.Instantiate(path);

                if (go != null)
                {
                    _areaSkills[i] = go;
                    go.transform.parent = root.transform;
                    ParticleSystem[] particles = go.GetComponentsInChildren<ParticleSystem>();
                    foreach (ParticleSystem particle in particles)
                        particle.Stop();
                }
                else
                    Debug.Log($"SkillObject Missing! {path}");
            }

            UnityEngine.Object.DontDestroyOnLoad(root);
        }
    }

    public void StartSkill(Define.AreaSkill type)
    {
        _areaSkills[(int)type].GetOrAddComponent<PlayerStat>();
        ParticleSystem[] particles = _areaSkills[(int)type].GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem particle in particles)
            particle.Play();
    }
}
