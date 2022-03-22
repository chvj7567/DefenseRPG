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
		public int gold;
		public int crystal;
		public int maxExp;
		public int exp;

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
			gold = st.gold;
			crystal = st.crystal;
			maxExp = st.maxExp;
			exp = st.exp;
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

		public List<Data.Stat> MakeList(Dictionary<string, Data.Stat> dict)
		{
			List<Data.Stat> list = new List<Data.Stat>();
			foreach (Data.Stat stat in dict.Values)
			{
				list.Add(stat);
			}

			return list;
		}
	}
}