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
		public int level;
		public int maxHp;
		public int hp;
		public float moveSpeed;
		public float attackSpeed;
		public int attack;
		public int defense;
		public int greenAttack;
		public int yellowAttack;
		public int blueAttack;
		public int redAttack;
		public int gold;
		public int crystal;
		public int maxExp;
		public int exp;
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

		public Stat(Stat st)
        {
			name = st.name;
			level = st.level;
			maxHp = st.maxHp;
			hp = st.hp;
			moveSpeed = st.moveSpeed;
			attackSpeed = st.attackSpeed;
			attack = st.attack;
			defense = st.defense;
			greenAttack = st.greenAttack;
			yellowAttack = st.yellowAttack;
			blueAttack = st.blueAttack;
			redAttack = st.redAttack;
			gold = st.gold;
			crystal = st.crystal;
			maxExp = st.maxExp;
			exp = st.exp;
			snow = st.snow;
			snowCoolTime = st.snowCoolTime;
			laser = st.laser;
			laserCoolTime = st.laserCoolTime;
			strong = st.strong;
			strongStay = st.strongStay;
			strongCoolTime = st.strongCoolTime;
			fastAttack = st.fastAttack;
			fastAttackStay = st.fastAttackStay;
			fastAttackCoolTime = st.fastAttackCoolTime;
        }
	}

	[Serializable]
	public class StatData : ILoader<string, Stat>
	{
		public List<Stat> stats = new List<Stat>();

		public Dictionary<string, Stat> MakeDict()
		{
			Dictionary<string, Stat> dict = new Dictionary<string, Stat>();
			foreach (Stat stat in stats)
				dict.Add(stat.name, stat);
			return dict;
		}

		public List<Stat> MakeList(Dictionary<string, Stat> dict)
		{
			List<Stat> list = new List<Stat>();
			foreach (Stat stat in dict.Values)
			{
				list.Add(stat);
			}

			return list;
		}
	}
}