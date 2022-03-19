using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : BaseStat
{
    public string MyName { get; private set; } = Enum.GetName(typeof(Define.Enemys), (int)Define.Enemys.Mummy);
    public override void Init()
    {
        _stat = MainManager.Data.MonsterStat[MyName];
    }

    public override void OnDamage(BaseStat attacker)
    {
        if (attacker as GreenStat)
        {
            Hp -= attacker.Attack - Defense;

            if (Hp <= 0)
            {
                Hp = 0;
                MainManager.Game.Despawn(gameObject);
            }
        }
    }
}