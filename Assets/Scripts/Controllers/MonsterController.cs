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
        _agent.stoppingDistance = 5f;
    }

    void OnEnable()
    {
        Init();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.gameObject;

        if (go.name == "GreenBullet")
        {
            GetComponent<MonsterStat>().OnDamage(go.GetComponent<GreenStat>());
        }

        if (go.name == "YellowBullet")
        {
            GetComponent<MonsterStat>().OnDamage(go.GetComponent<YellowStat>());
        }

        if (go.name == "BlueBullet")
        {
            GetComponent<MonsterStat>().OnDamage(go.GetComponent<BlueStat>());
        }

        if (go.name == "RedBullet")
        {
            GetComponent<MonsterStat>().OnDamage(go.GetComponent<RedStat>());
        }
    }
}