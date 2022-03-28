using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStat : MonoBehaviour
{
    public abstract string Name { get; protected set; }
    public virtual int Level { get; protected set; }
    public virtual int MaxHp { get; protected set; }
    public virtual int Hp { get; protected set; }
    public virtual int Attack { get; protected set; }
    public virtual int Defense { get; protected set; }
    public virtual int Gold { get; protected set; }
    public virtual int Crystal { get; protected set; }
    public virtual int MaxExp { get; protected set; }
    public virtual int Exp { get; protected set; }
    public virtual float MoveSpeed { get; protected set; }
    public virtual float AttackSpeed { get; protected set; }
    public virtual int Snow { get; protected set; }
    public virtual int SnowCoolTime { get; protected set; }
    public virtual int Laser { get; protected set; }
    public virtual int LaserCoolTime { get; protected set; }
    public virtual int Strong { get; protected set; }
    public virtual int StrongStay { get; protected set; }
    public virtual int StrongCoolTime { get; protected set; }
    public virtual float FastAttack { get; protected set; }
    public virtual int FastAttackStay { get; protected set; }
    public virtual int FastAttackCoolTime { get; protected set; }

    void Start()
    {
        Init();
    }

    public abstract void Init();

    public virtual void OnDamage(BaseStat attacker) { }
}