using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenStat : BaseStat
{
    public string MyName { get; private set; } = Enum.GetName(typeof(Define.Players), (int)Define.Players.Tank_Green);

    public override void Init()
    {
        _stat = new Data.Stat(MainManager.Data.TankStat[MyName]);
    }

    public override void OnDamage(BaseStat attacker)
    {
        if (attacker as MonsterStat)
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