using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
	public class Stat
	{
		public int stage;
		public int hp;
		public int moveSpeed;
		public int attackSpeed;
		public int attack;
		public int defense;
	}

	[Serializable]
	public class StatData : ILoader<int, Stat>
	{
		public List<Stat> stats = new List<Stat>();

		public Dictionary<int, Stat> MakeDict()
		{
			Dictionary<int, Stat> dict = new Dictionary<int, Stat>();
			foreach (Stat stat in stats)
				dict.Add(stat.stage, stat);
			return dict;
		}
	}
}