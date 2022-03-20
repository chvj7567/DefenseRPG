using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedStat : BaseStat
{
    public string MyName { get; private set; } = Enum.GetName(typeof(Define.Players), (int)Define.Players.Tank_Red);

    public override void Init()
    {
        _stat = new Data.Stat(MainManager.Data.PlayerStat[MyName]);
    }

    public override void OnDamage(BaseStat attacker)
    {

    }
}
