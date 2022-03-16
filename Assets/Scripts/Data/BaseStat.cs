using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStat : MonoBehaviour
{
    protected Dictionary<int, Data.Stat> statDict = new Dictionary<int, Data.Stat>();
    protected int _stage;
    protected int _hp;
    protected float _moveSpeed;
    protected float _attackSpeed;
    protected int _attack;
    protected int _defense;

    public int Stage { get { return _stage; } set { _stage = value; } }
    public int Hp { get { return _hp; } set { _hp = value; } }
    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }
    public float AttackSpeed { get { return _attackSpeed; } set { _attackSpeed = value; } }
    public int Attack { get { return _attack; } set { _attack = value; } }
    public int Defense { get { return _defense; } set { _defense = value; } }

    public virtual void OnDamage(BaseStat attacker) { }
}