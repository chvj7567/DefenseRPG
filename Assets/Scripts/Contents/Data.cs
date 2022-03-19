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

		public Stat(Stat st)
        {
			name = st.name;
			level = st.level;
			maxHp = st.maxHp;
			hp = st.hp;
			moveSpeed = st.moveSpeed;
			attackSpeed = st.attackSpeed;
			defense = st.defense;
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
	}
}