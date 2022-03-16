using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : BaseStat
{
    void Awake()
    {
        statDict = MainManager.Data.GetData("Monster");
    }
}