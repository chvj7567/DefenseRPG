using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterStat : BaseStat
{
    public string MyName { get; private set; } = Enum.GetName(typeof(Define.Enemys), (int)Define.Enemys.Mummy);

    UI_Game _game;
    public override void Init()
    {
        _stat = new Data.Stat(MainManager.Data.MonsterStat[MyName]);
        _game = MainManager.UI.Game.GetComponent<UI_Game>();
    }

    void OnEnable()
    {
        Init();
    }

    public override void OnDamage(BaseStat attacker)
    {
        if (attacker as GreenStat)
        {
            if (attacker.Attack - Defense <= 0)
                Hp -= 1;
            else
                Hp -= attacker.Attack - Defense;

            if (Hp <= 0)
            {
                Booty();
                MainManager.Game.Despawn(gameObject);
            }
        }
    }

    void Booty()
    {
        _game.SetGold(Gold);
        _game.SetCrystal(Crystal);
        _game.SetExp(Exp);
    }
}