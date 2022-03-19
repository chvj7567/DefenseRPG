using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowStat : BaseStat
{
    public string MyName { get; private set; } = Enum.GetName(typeof(Define.Players), (int)Define.Players.Tank_Yellow);

    public override void Init()
    {
        _stat = MainManager.Data.TankStat[MyName];
    }

    public override void OnDamage(BaseStat attacker)
    {

    }
}
