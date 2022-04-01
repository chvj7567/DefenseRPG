using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageStat : BaseStat
{
    public override string Name { get; protected set; }
    public override int Level { get { return MainManager.Data.StageInfo[Name].level; } }
    public override int AddHp { get { return MainManager.Data.StageInfo[Name].addHp; } }
    public override int AddDefense { get { return MainManager.Data.StageInfo[Name].addDefense; } }
    public override int SpawnNumber { get { return MainManager.Data.StageInfo[Name].spawnNumber; } }
    public override float SpawnTime { get { return MainManager.Data.StageInfo[Name].spawnTime; } }

    public override void Init()
    {
        Name = "Stage";
    }

    public void AddLevel(int level) { MainManager.Data.StageInfo[Name].level += level; }
    public void AddSpawnNumber(int spawnNumber) { MainManager.Data.StageInfo[Name].spawnNumber += spawnNumber; }
    public void AddSpawnTime(float spawnTime) { MainManager.Data.StageInfo[Name].spawnTime += spawnTime; }
}