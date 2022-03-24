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
        GameObjectType = Define.GameObjects.Monster;
        
        if (GetComponentInChildren<UI_HpBar>() == null)
            MainManager.UI.MakeWorldSpaceUI<UI_HpBar>(transform);
    }

    void OnEnable()
    {
        Init();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Bullet"))
        {
            GetComponent<MonsterStat>().OnDamage(other.GetComponent<PlayerStat>());
        }
    }
}