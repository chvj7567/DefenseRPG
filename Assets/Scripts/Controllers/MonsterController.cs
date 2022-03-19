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
        _target = GameObject.Find("Tank_Green");
        _agent = gameObject.GetOrAddComponent<NavMeshAgent>();
        _agent.SetDestination(_target.transform.position);
    }

    void OnEnable()
    {
        Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "GreenBullet")
        {
            GetComponent<MonsterStat>().OnDamage(other.GetComponent<GreenStat>());
        }

        if (other.name == "YellowBullet")
        {
            GetComponent<MonsterStat>().OnDamage(other.GetComponent<YellowStat>());
        }

        if (other.name == "BlueBullet")
        {
            GetComponent<MonsterStat>().OnDamage(other.GetComponent<BlueStat>());
        }

        if (other.name == "RedBullet")
        {
            GetComponent<MonsterStat>().OnDamage(other.GetComponent<RedStat>());
        }
    }
}