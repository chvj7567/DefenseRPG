using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStat : MonoBehaviour
{
    protected Data.Stat _stat;

    public string Name { get { return _stat.name; } set { _stat.name = value; } }
    public int Level { get { return _stat.level; } set { _stat.level = value; } }
    public int MaxHp { get { return _stat.maxHp; } set { _stat.maxHp = value; } }
    public int Hp { get { return _stat.hp; } set { _stat.hp = value; } }
    public float MoveSpeed { get { return _stat.moveSpeed; } set { _stat.moveSpeed = value; } }
    public float AttackSpeed { get { return _stat.attackSpeed; } set { _stat.attackSpeed = value; } }
    public int Attack { get { return _stat.attack; } set { _stat.attack = value; } }
    public int Defense { get { return _stat.defense; } set { _stat.defense = value; } }
    public int Gold { get { return _stat.gold; } set { _stat.gold = value; } }
    public int Crystal { get { return _stat.crystal; } set { _stat.crystal = value; } }
    public int MaxExp { get { return _stat.maxExp; } set { _stat.maxExp = value; } }
    public int Exp { get { return _stat.exp; } set { _stat.exp = value; } }

    void Start()
    {
        Init();
    }

    public abstract void Init();
    public virtual void OnDamage(BaseStat attacker) { }
}