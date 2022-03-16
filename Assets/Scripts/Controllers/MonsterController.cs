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

    private void OnEnable()
    {
        Init();
    }

    private void Update()
    {
        float dis = (_target.transform.position - transform.position).magnitude;
        
    }
}