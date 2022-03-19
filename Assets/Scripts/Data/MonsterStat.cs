using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : BaseStat
{
    public string MyName { get; private set; } = Enum.GetName(typeof(Define.Enemys), (int)Define.Enemys.Mummy);
    public override void Init()
    {
        _stat = new Data.Stat(MainManager.Data.MonsterStat[MyName]);
    }

    void OnEnable()
    {
        Init();
    }

    public override void OnDamage(BaseStat attacker)
    {
        if (attacker as GreenStat)
        {
            if (attacker.Attack - Defense <= 0)
                Hp -= 1;
            else
                Hp -= attacker.Attack - Defense;

            if (Hp <= 0)
            {
                Hp = 0;
                MainManager.Game.Despawn(gameObject);
            }
        }
    }
}