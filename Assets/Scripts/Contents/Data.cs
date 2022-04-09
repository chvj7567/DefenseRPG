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
	public class Game
	{
		public string name;
		public int stage;
		public int addHp;
		public int addDefense;
		public int spawnNumber;
		public float spawnTime;
		public int attackGold;
		public int defenseGold;
		public int attackIncrement;
		public int defenseIncrement;
		public int greenGold;
		public int yellowGold;
		public int blueGold;
		public int redGold;
		public int snowCrystal;
		public int laserCrystal;
		public int strongCrystal;
		public int fastAttackCrystal;
		public string skillSlot1;
		public string skillSlot2;
		public string skillSlot3;
		public string lastTime;
		//public string currentTime;

		public Game(Game game)
		{
			name = game.name;
			stage = game.stage;
			addHp = game.addHp;
			addDefense = game.addDefense;
			spawnNumber = game.spawnNumber;
			spawnTime = game.spawnTime;
			attackGold = game.attackGold;
			defenseGold = game.defenseGold;
			attackIncrement = game.attackIncrement;
			defenseIncrement = game.defenseIncrement;
			greenGold = game.greenGold;
			yellowGold = game.yellowGold;
			blueGold = game.blueGold;
			redGold = game.redGold;
			snowCrystal = game.snowCrystal;
			laserCrystal = game.laserCrystal;
			strongCrystal = game.strongCrystal;
			fastAttackCrystal = game.fastAttackCrystal;
			skillSlot1 = game.skillSlot1;
			skillSlot2 = game.skillSlot2;
			skillSlot3 = game.skillSlot3;
			lastTime = game.lastTime;
			//currentTime = game.currentTime;
		}
	}

	[Serializable]
	public class ExtractData<T> : ILoader<string, T> where T : class
	{
		public List<Game> games = new List<Game>();
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
			else if (typeof (T) == typeof(Game))
            {
				foreach (Game game in games)
					dict.Add(game.name, game as T);
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
			else if (typeof(T) == typeof(Game))
			{
				foreach (T game in dict.Values)
					list.Add(game);
			}

			return list;
		}
	}
}