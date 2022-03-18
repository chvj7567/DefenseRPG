using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStat : MonoBehaviour
{
    protected Dictionary<string, Data.Stat> _statDict = new Dictionary<string, Data.Stat>();
    protected Data.Stat _stat;

    public string Name { get { return _stat.name; } set { _stat.name = value; } }
    public int Level { get { return _stat.level; } set { _stat.level = value; } }
    public int MaxHp { get { return _stat.maxHp; } set { _stat.maxHp = value; } }
    public int Hp { get { return _stat.hp; } set { _stat.hp = value; } }
    public float MoveSpeed { get { return _stat.moveSpeed; } set { _stat.moveSpeed = value; } }
    public float AttackSpeed { get { return _stat.attackSpeed; } set { _stat.attackSpeed = value; } }
    public int Attack { get { return _stat.attack; } set { _stat.attack = value; } }
    public int Defense { get { return _stat.defense; } set { _stat.defense = value; } }

    public virtual void OnDamage(BaseStat attacker) { }
}