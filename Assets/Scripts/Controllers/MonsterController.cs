using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class MonsterController : BaseController
{
    public override void Init()
    {
        GameObjectType = Define.GameObjects.Monster;
        if (GetComponentInChildren<UI_HpBar>() == null)
            MainManager.UI.MakeWorldSpaceUI<UI_HpBar>(transform);
    }

    void Update()
    {
        if (transform.position.z < -30f)
        {
            MainManager.Game.Despawn(gameObject);
            MainManager.Game.Player.GetComponent<PlayerStat>().AddDefense(-1);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Bullet"))
        {
            GetComponent<MonsterStat>().OnDamage(other.GetComponent<PlayerStat>(), "Bullet");
        }
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.transform.parent.parent.name == Enum.GetName(typeof(Define.AreaSkill), (int)Define.AreaSkill.Snow)
            || other.transform.parent.name == Enum.GetName(typeof(Define.AreaSkill), (int)Define.AreaSkill.Snow))
        {
            if (other.name == "Smoke")
                GetComponent<MonsterStat>().OnDamage(other.transform.parent.parent.GetComponent<PlayerStat>(), other.name);
            else
                GetComponent<MonsterStat>().OnDamage(other.transform.parent.GetComponent<PlayerStat>(), Enum.GetName(typeof(Define.AreaSkill), (int)Define.AreaSkill.Snow));
        }

        if (other.transform.parent.name == Enum.GetName(typeof(Define.AreaSkill), (int)Define.AreaSkill.Laser))
        {
            if (other.name == "Flash")
                GetComponent<MonsterStat>().OnDamage(other.transform.parent.GetComponent<PlayerStat>(), other.name);
            else
                GetComponent<MonsterStat>().OnDamage(other.transform.parent.GetComponent<PlayerStat>(), Enum.GetName(typeof(Define.AreaSkill), (int)Define.AreaSkill.Laser));
        }
    }
}