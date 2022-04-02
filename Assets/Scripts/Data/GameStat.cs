using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStat : BaseStat
{
    public override string Name { get; protected set; }
    public override int Stage { get { return MainManager.Data.PlayerGame[Name].stage; } }
    public override int AddHp { get { return MainManager.Data.PlayerGame[Name].addHp; } }
    public override int AddDefense { get { return MainManager.Data.PlayerGame[Name].addDefense; } }
    public override int SpawnNumber { get { return MainManager.Data.PlayerGame[Name].spawnNumber; } }
    public override float SpawnTime { get { return MainManager.Data.PlayerGame[Name].spawnTime; } }
    public override int AttackGold { get { return MainManager.Data.PlayerGame[Name].attackGold; } }
    public override int DefenseGold { get { return MainManager.Data.PlayerGame[Name].defenseGold; } }
    public override int GreenGold { get { return MainManager.Data.PlayerGame[Name].greenGold; } }
    public override int YellowGold { get { return MainManager.Data.PlayerGame[Name].yellowGold; } }
    public override int BlueGold { get { return MainManager.Data.PlayerGame[Name].blueGold; } }
    public override int RedGold { get { return MainManager.Data.PlayerGame[Name].redGold; } }
    public override int SnowCrystal { get { return MainManager.Data.PlayerGame[Name].snowCrystal; } }
    public override int LaserCrystal { get { return MainManager.Data.PlayerGame[Name].laserCrystal; } }
    public override int StrongCrystal { get { return MainManager.Data.PlayerGame[Name].strongCrystal; } }
    public override int FastAttackCrystal { get { return MainManager.Data.PlayerGame[Name].fastAttackCrystal; } }
    public override string SkillSlot1 { get { return MainManager.Data.PlayerGame[Name].skillSlot1; } protected set { MainManager.Data.PlayerGame[Name].skillSlot1 = value; } }
    public override string SkillSlot2 { get { return MainManager.Data.PlayerGame[Name].skillSlot2; } protected set { MainManager.Data.PlayerGame[Name].skillSlot2 = value; } }
    public override string SkillSlot3 { get { return MainManager.Data.PlayerGame[Name].skillSlot3; } protected set { MainManager.Data.PlayerGame[Name].skillSlot3 = value; } }
    public override void Init()
    {
        Name = MainManager.Data.PlayerStat[Enum.GetName(typeof(Define.GameObjects), (int)Define.GameObjects.Player)].name;
    }

    public void AddStage(int stage) { MainManager.Data.PlayerGame[Name].stage += stage; }
    public void AddSpawnNumber(int spawnNumber) { MainManager.Data.PlayerGame[Name].spawnNumber += spawnNumber; }
    public void AddSpawnTime(float spawnTime) { MainManager.Data.PlayerGame[Name].spawnTime += spawnTime; }
    public void AddAttackGold(int attackGold) { MainManager.Data.PlayerGame[Name].attackGold += attackGold; }
    public void AddDefenseGold(int defenseGold) { MainManager.Data.PlayerGame[Name].defenseGold += defenseGold; }
    public void AddGreenGold(int greenGold) { MainManager.Data.PlayerGame[Name].greenGold += greenGold; }
    public void AddYellowGold(int yellowGold) { MainManager.Data.PlayerGame[Name].yellowGold += yellowGold; }
    public void AddBlueGold(int blueGold) { MainManager.Data.PlayerGame[Name].blueGold += blueGold; }
    public void AddRedGold(int redGold) { MainManager.Data.PlayerGame[Name].redGold += redGold; }
    public void AddSnowCrystal(int snowCrystal) { MainManager.Data.PlayerGame[Name].snowCrystal += snowCrystal; }
    public void AddLaserCrystal(int laserCrystal) { MainManager.Data.PlayerGame[Name].laserCrystal += laserCrystal; }
    public void AddStrongCrystal(int strongCrystal) { MainManager.Data.PlayerGame[Name].strongCrystal += strongCrystal; }
    public void AddFastAttackCrystal(int fastAttackCrystal) { MainManager.Data.PlayerGame[Name].fastAttackCrystal += fastAttackCrystal; }
    public void SetSkillSlot1(string skill) { SkillSlot1 = skill; }
    public void SetSkillSlot2(string skill) { SkillSlot2 = skill; }
    public void SetSkillSlot3(string skill) { SkillSlot3 = skill; }
}
