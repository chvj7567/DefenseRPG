using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterStat : BaseStat
{
    Data.Stat _stat;
    PlayerStat _player;
    public override string Name { get; protected set; }
    public override int Attack { get { return _stat.attack; } protected set { _stat.attack = value; } }
    public override int Defense { get { return _stat.defense; } protected set { _stat.defense = value; } }
    public override int Level { get { return _stat.level; } protected set { _stat.level = value; } }
    public override int MaxHp { get { return _stat.maxHp; } protected set { _stat.maxHp = value; } }
    public override int Hp { get { return _stat.hp; } protected set { _stat.hp = value; } }
    public override float MoveSpeed { get { return _stat.moveSpeed; } protected set { _stat.moveSpeed = value; } }
    public override float AttackSpeed { get { return _stat.attackSpeed; } protected set { _stat.attackSpeed = value; } }
    public override int Gold { get { return _stat.gold; } protected set { _stat.gold = value; } }
    public override int Crystal { get { return _stat.crystal; } protected set { _stat.crystal = value; } }
    public override int Exp { get { return _stat.exp; } protected set { _stat.exp = value; } }

    public override void Init()
    {
        Name = MainManager.Data.MonsterStat[Enum.GetName(typeof(Define.GameObjects), (int)Define.GameObjects.Monster)].name;
        _stat = new Data.Stat(MainManager.Data.MonsterStat[Name]);
        _player = MainManager.Game.Player.GetComponent<PlayerStat>();
    }

    public override void OnDamage(BaseStat attacker, string name)
    {
        if (attacker as PlayerStat)
        {
            if (name == "Bullet")
            {
                if (attacker.Attack - Defense <= 0)
                    Hp -= 1;
                else
                    Hp -= attacker.Attack - Defense;
            }
            else if (name == Enum.GetName(typeof(Skill.Area), (int)Skill.Area.Snow))
                Hp -= attacker.Snow;
            else if (name == "Smoke")
                Hp -= 20;
            else if (name == Enum.GetName(typeof(Skill.Area), (int)Skill.Area.Laser))
                Hp -= attacker.Laser;
            else if (name == "Flash")
                Hp -= 20;

            if (Hp <= 0)
            {
                Booty();
                MainManager.Game.Despawn(gameObject);
            }
        }
    }

    void Booty()
    {
        _player.AddGold(Gold);
        _player.AddCrystal(Crystal);
        _player.AddExp(Exp);
    }
}