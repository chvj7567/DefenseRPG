using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : BaseStat
{
    public override string Name { get; protected set; }
    public override int Attack { get { return GetAttack(); } }
    public override float AttackSpeed { get { return MainManager.Data.PlayerStat[Name].attackSpeed; } }
    public override int Defense { get { return MainManager.Data.PlayerStat[Name].defense; } }
    public override int Level { get { return MainManager.Data.PlayerInfo[Name].level; } }
    public override int MaxHp { get { return MainManager.Data.PlayerInfo[Name].maxHp; } }
    public override int Hp { get { return MainManager.Data.PlayerInfo[Name].hp; } }
    public override int GreenTank { get { return MainManager.Data.PlayerInfo [Name].greenTank; } }
    public override int YellowTank { get { return MainManager.Data.PlayerInfo[Name].yellowTank; } }
    public override int BlueTank { get { return MainManager.Data.PlayerInfo[Name].blueTank; } }
    public override int RedTank { get { return MainManager.Data.PlayerInfo[Name].redTank; } }
    public override int Gold { get { return MainManager.Data.PlayerInfo[Name].gold; } }
    public override int Crystal { get { return MainManager.Data.PlayerInfo[Name].crystal; } }
    public override int MaxExp { get { return MainManager.Data.PlayerInfo[Name].maxExp; } }
    public override int Exp { get { return MainManager.Data.PlayerInfo[Name].exp; } }
    public override int Snow { get { return MainManager.Data.PlayerStat[Name].snow; } }
    public override int SnowCoolTime { get { return MainManager.Data.PlayerStat[Name].snowCoolTime; } }
    public override int Laser { get { return MainManager.Data.PlayerStat[Name].laser; } }
    public override int LaserCoolTime { get { return MainManager.Data.PlayerStat[Name].laserCoolTime; } }
    public override int Strong { get { return MainManager.Data.PlayerStat[Name].strong; } }
    public override int StrongStay { get { return MainManager.Data.PlayerStat[Name].strongStay; } }
    public override int StrongCoolTime { get { return MainManager.Data.PlayerStat[Name].strongCoolTime; } }
    public override float FastAttack { get { return MainManager.Data.PlayerStat[Name].fastAttack; } }
    public override int FastAttackStay { get { return MainManager.Data.PlayerStat[Name].fastAttackStay; } }
    public override int FastAttackCoolTime { get { return MainManager.Data.PlayerStat[Name].fastAttackCoolTime; } }

    public override void Init()
    {
        Name = MainManager.Data.PlayerStat[Enum.GetName(typeof(Define.GameObjects), (int)Define.GameObjects.Player)].name;
    }

    int GetAttack()
    {
        BulletController bullet = GetComponent<BulletController>();

        if (bullet == null)
        {
            int greenAttack = MainManager.Game.GreenNum * MainManager.Data.PlayerStat[Name].greenAttack;
            int yellowAttack = MainManager.Game.YellowNum * MainManager.Data.PlayerStat[Name].yellowAttack;
            int blueAttack = MainManager.Game.BlueNum * MainManager.Data.PlayerStat[Name].blueAttack;
            int redAttack = MainManager.Game.RedNum * MainManager.Data.PlayerStat[Name].redAttack;
            return greenAttack + yellowAttack + blueAttack + redAttack;
        }

        if (bullet.Color == Enum.GetName(typeof(Define.Tank), (int)Define.Tank.Green))
            return MainManager.Data.PlayerStat[Name].greenAttack;
        else if ((bullet.Color == Enum.GetName(typeof(Define.Tank), (int)Define.Tank.Yellow)))
            return MainManager.Data.PlayerStat[Name].yellowAttack;
        else if ((bullet.Color == Enum.GetName(typeof(Define.Tank), (int)Define.Tank.Blue)))
            return MainManager.Data.PlayerStat[Name].blueAttack;
        else if ((bullet.Color == Enum.GetName(typeof(Define.Tank), (int)Define.Tank.Red)))
            return MainManager.Data.PlayerStat[Name].redAttack;

        return -1;
    }

    public void AddAttack(int attack)
    {
        MainManager.Data.PlayerStat[Name].greenAttack += attack;
        MainManager.Data.PlayerStat[Name].yellowAttack += attack;
        MainManager.Data.PlayerStat[Name].blueAttack += attack;
        MainManager.Data.PlayerStat[Name].redAttack += attack;
    }
    public void AddAttackSpeed(float attackSpeed) { MainManager.Data.PlayerStat[Name].attackSpeed -= attackSpeed; }
    public void AddDefense(int defense) { MainManager.Data.PlayerStat[Name].defense += defense; }
    public void AddLevel(int level)
    {
        MainManager.Data.PlayerInfo[Name].level += level;
        AddAttack(10);
        AddDefense(10);
        AddMaxHp(100);
        SetHp(MaxHp);
    }
    public void AddMaxHp(int maxHp) { MainManager.Data.PlayerInfo[Name].maxHp += maxHp; }
    void SetHp(int hp) { MainManager.Data.PlayerInfo[Name].hp = hp; }
    public void AddHp(int hp) { MainManager.Data.PlayerInfo[Name].hp += hp; }
    public void AddGreenTank(int green) { MainManager.Data.PlayerInfo[Name].greenTank += green; }
    public void AddYellowTank(int yellow) { MainManager.Data.PlayerInfo[Name].greenTank += yellow; }
    public void AddBlueTank(int blue) { MainManager.Data.PlayerInfo[Name].greenTank += blue; }
    public void AddRedTank(int red) { MainManager.Data.PlayerInfo[Name].greenTank += red; }
    public void AddGold(int gold) { MainManager.Data.PlayerInfo[Name].gold += gold; }
    public void AddCrystal(int crystal) { MainManager.Data.PlayerInfo[Name].crystal += crystal; }
    public void AddMaxExp(int maxExp) { MainManager.Data.PlayerInfo[Name].maxExp += maxExp; }
    public void AddExp(int exp)
    {
        MainManager.Data.PlayerInfo[Name].exp += exp;

        while (Exp >= MaxExp)
        {
            AddLevel(1);
            AddMaxExp(MaxExp);
            AddMaxHp(MaxHp);
            MainManager.Data.PlayerInfo[Name].hp = MaxHp;
        }
    }

    public void AddSnow(int snow) { MainManager.Data.PlayerStat[Name].snow += snow; }
    public void AddLaser(int laser) { MainManager.Data.PlayerStat[Name].laser += laser; }
    public void AddStrong(int strong) { MainManager.Data.PlayerStat[Name].strong += strong; }
    public void AddFastAttack(float fastAttack) { MainManager.Data.PlayerStat[Name].fastAttack += fastAttack; }
}