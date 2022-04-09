using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStat : MonoBehaviour
{
    public abstract string Name { get; protected set; }
    public virtual int Level { get; protected set; }
    public virtual int Stage { get; protected set; }
    public virtual int MaxHp { get; protected set; }
    public virtual int Hp { get; protected set; }
    public virtual int GreenTank { get; protected set; }
    public virtual int YellowTank { get; protected set; }
    public virtual int BlueTank { get; protected set; }
    public virtual int RedTank { get; protected set; }
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
    public virtual int AddHp { get; protected set; }
    public virtual int AddDefense { get; protected set; }
    public virtual int SpawnNumber { get; protected set; }
    public virtual float SpawnTime { get; protected set; }
    public virtual int AttackGold { get; protected set; }
    public virtual int DefenseGold { get; protected set; }
    public virtual int AttackIncrement { get; protected set; }
    public virtual int DefenseIncrement { get; protected set; }
    public virtual int GreenGold { get; protected set; }
    public virtual int YellowGold { get; protected set; }
    public virtual int BlueGold { get; protected set; }
    public virtual int RedGold { get; protected set; }
    public virtual int SnowCrystal { get; protected set; }
    public virtual int LaserCrystal { get; protected set; }
    public virtual int StrongCrystal { get; protected set; }
    public virtual int FastAttackCrystal { get; protected set; }
    public virtual string SkillSlot1 { get; protected set; }
    public virtual string SkillSlot2 { get; protected set; }
    public virtual string SkillSlot3 { get; protected set; }
    public virtual string LastTime { get; protected set; }
    //public virtual string CurrentTime { get; protected set; }

    void OnEnable()
    {
        Init();
    }

    public abstract void Init();

    public virtual void OnDamage(BaseStat attacker, string name) { }
}