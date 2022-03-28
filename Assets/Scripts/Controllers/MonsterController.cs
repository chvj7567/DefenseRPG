using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class MonsterController : BaseController
{
    GameObject _target;
    NavMeshAgent _agent;

    public override void Init()
    {
        _target = GameObject.FindGameObjectWithTag("Finish");
        _agent = gameObject.GetOrAddComponent<NavMeshAgent>();
        StartCoroutine(ReTargeting());
        GameObjectType = Define.GameObjects.Monster;

        if (GetComponentInChildren<UI_HpBar>() == null)
            MainManager.UI.MakeWorldSpaceUI<UI_HpBar>(transform);
    }

    void OnEnable()
    {
        Init();
    }

    IEnumerator ReTargeting()
    {
        while (true)
        {
            _agent.SetDestination(_target.transform.position);
            yield return new WaitForSeconds(1f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Bullet"))
        {
            GetComponent<MonsterStat>().OnDamage(other.GetComponent<PlayerStat>(), "Bullet");
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name);
        if (other.transform.parent.parent.name == Enum.GetName(typeof(Skill.Area), (int)Skill.Area.Snow)
            || other.transform.parent.name == Enum.GetName(typeof(Skill.Area), (int)Skill.Area.Snow))
        {
            if (other.name == "Smoke")
                GetComponent<MonsterStat>().OnDamage(other.transform.parent.parent.GetComponent<PlayerStat>(), other.name);
            else
                GetComponent<MonsterStat>().OnDamage(other.transform.parent.GetComponent<PlayerStat>(), Enum.GetName(typeof(Skill.Area), (int)Skill.Area.Snow));
        }

        if (other.transform.parent.name == Enum.GetName(typeof(Skill.Area), (int)Skill.Area.Laser))
        {
            if (other.name == "Flash")
                GetComponent<MonsterStat>().OnDamage(other.transform.parent.GetComponent<PlayerStat>(), other.name);
            else
                GetComponent<MonsterStat>().OnDamage(other.transform.parent.GetComponent<PlayerStat>(), Enum.GetName(typeof(Skill.Area), (int)Skill.Area.Laser));
        }
    }
}