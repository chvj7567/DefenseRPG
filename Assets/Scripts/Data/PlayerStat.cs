using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : BaseStat
{
    public override string Name { get; protected set; }
    public override int Attack { get { return GetAttack(); } }
    public override int Defense { get { return MainManager.Data.PlayerStat[Name].defense; } }
    public override int Level { get { return MainManager.Data.PlayerStat[Name].level; } }
    public override int MaxHp { get { return MainManager.Data.PlayerStat[Name].maxHp; } }
    public override int Hp { get { return MainManager.Data.PlayerStat[Name].hp; } }
    public override int Gold { get { return MainManager.Data.PlayerStat[Name].gold; } }
    public override int Crystal { get { return MainManager.Data.PlayerStat[Name].crystal; } }
    public override int MaxExp { get { return MainManager.Data.PlayerStat[Name].maxExp; } }
    public override int Exp { get { return MainManager.Data.PlayerStat[Name].exp; } }

    public override void Init()
    {
        Name = MainManager.Data.PlayerStat[Enum.GetName(typeof(Define.GameObjects), (int)Define.GameObjects.Player)].name;
    }

    int GetAttack()
    {
        return MainManager.Data.PlayerStat[Name].greenAttack;
    }

    public void AddAttack(int attack)
    {
        MainManager.Data.PlayerStat[Name].greenAttack += attack;
        MainManager.Data.PlayerStat[Name].yellowAttack += attack;
        MainManager.Data.PlayerStat[Name].blueAttack += attack;
        MainManager.Data.PlayerStat[Name].redAttack += attack;
    }

    public void AddDefense(int defense) { MainManager.Data.PlayerStat[Name].defense += defense; }
    public void AddLevel(int level) { MainManager.Data.PlayerStat[Name].level += level; }
    public void AddMaxHp(int maxHp) { MainManager.Data.PlayerStat[Name].maxHp += maxHp; }
    public void AddHp(int hp) { MainManager.Data.PlayerStat[Name].hp += hp; }
    public void AddGold(int gold) { MainManager.Data.PlayerStat[Name].gold += gold; }
    public void AddCrystal(int crystal) { MainManager.Data.PlayerStat[Name].crystal += crystal; }
    public void AddMaxExp(int maxExp) { MainManager.Data.PlayerStat[Name].maxExp += maxExp; }
    public void AddExp(int exp)
    {
        MainManager.Data.PlayerStat[Name].exp += exp;

        while (Exp >= MaxExp)
        {
            AddLevel(1);
            AddMaxExp(MaxExp);
            AddMaxHp(MaxHp);
            MainManager.Data.PlayerStat[Name].hp = MaxHp;
        }
    }
}