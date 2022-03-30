using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
	[Serializable]
	public class Stat
	{
		public string name;
		public float moveSpeed;
		public float attackSpeed;
		public int attack;
		public int defense;
		public int greenAttack;
		public int yellowAttack;
		public int blueAttack;
		public int redAttack;
		public int snow;
		public int snowCoolTime;
		public int laser;
		public int laserCoolTime;
		public int strong;
		public int strongCoolTime;
		public int strongStay;
		public float fastAttack;
		public int fastAttackStay;
		public int fastAttackCoolTime;

		public Stat(Stat stat)
        {
			name = stat.name;
			moveSpeed = stat.moveSpeed;
			attackSpeed = stat.attackSpeed;
			attack = stat.attack;
			defense = stat.defense;
			greenAttack = stat.greenAttack;
			yellowAttack = stat.yellowAttack;
			blueAttack = stat.blueAttack;
			redAttack = stat.redAttack;
			snow = stat.snow;
			snowCoolTime = stat.snowCoolTime;
			laser = stat.laser;
			laserCoolTime = stat.laserCoolTime;
			strong = stat.strong;
			strongStay = stat.strongStay;
			strongCoolTime = stat.strongCoolTime;
			fastAttack = stat.fastAttack;
			fastAttackStay = stat.fastAttackStay;
			fastAttackCoolTime = stat.fastAttackCoolTime;
        }
	}

	[Serializable]
	public class Info
	{
		public string name;
		public int level;
		public int maxHp;
		public int hp;
		public int greenTank;
		public int yellowTank;
		public int blueTank;
		public int redTank;
		public int gold;
		public int crystal;
		public int maxExp;
		public int exp;

		public Info(Info info)
		{
			name = info.name;
			level = info.level;
			maxHp = info.maxHp;
			hp = info.hp;
			greenTank = info.greenTank;
			yellowTank = info.yellowTank;
			blueTank = info.blueTank;
			redTank = info.redTank;
			gold = info.gold;
			crystal = info.crystal;
			maxExp = info.maxExp;
			exp = info.exp;
		}
	}

	[Serializable]
	public class ExtractData<T> : ILoader<string, T> where T : class
	{
		public List<Info> infos = new List<Info>();
		public List<Stat> stats = new List<Stat>();

        public Dictionary<string, T> MakeDict()
        {
			Dictionary<string, T> dict = new Dictionary<string, T>();
			
			if (typeof(T) == typeof(Info))
            {
				foreach (Info info in infos)
					dict.Add(info.name, info as T);
			}
			else if (typeof(T) == typeof(Stat))
            {
				foreach (Stat stat in stats)
					dict.Add(stat.name, stat as T);
			}

			return dict;
		}

        public List<T> MakeList(Dictionary<string, T> dict)
        {
			List<T> list = new List<T>();

			if (typeof(T) == typeof(Info))
			{
				foreach (T info in dict.Values)
					list.Add(info);
			}
			else if (typeof(T) == typeof(Stat))
			{
				foreach (T stat in dict.Values)
					list.Add(stat);
			}

			return list;
		}
	}
}