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

    void Start()
    {
        Init();
    }

    public abstract void Init();

    public virtual void OnDamage(BaseStat attacker) { }
}