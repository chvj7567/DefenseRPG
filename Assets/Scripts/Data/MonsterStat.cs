using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : BaseStat
{
    void Awake()
    {
        
        _statDict = MainManager.Data.GetData("Monster");
        _stat = _statDict[Enum.GetName(typeof(Define.Enemys), (int)Define.Enemys.A)];
    }

    public override void OnDamage(BaseStat attacker)
    {
        if (attacker as GreenStat)
        {
            Hp -= attacker.Attack - Defense;

            if (Hp <= 0)
                MainManager.Game.Despawn(gameObject);
            Debug.Log(Hp);
        }
    }
}