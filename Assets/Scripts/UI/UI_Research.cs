using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Research : UI_Base
{
    PlayerStat _playerStat;
    Text _attackGoldT, _defenseGoldT, _attackIncrementT, _defenseIncrementT;
    Image _attackIncrease, _defenseIncrease;

    enum Texts
    {
        AttackGoldT,
        DefenseGoldT,
        AttackIncrementT,
        DefenseIncrementT,
    }

    enum Images
    {
        AttackIncrease,
        DefenseIncrease,
    }

    public override void Init()
    {
        _playerStat = MainManager.Game.Player.GetComponent<PlayerStat>();

        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));

        _attackGoldT = GetText((int)Texts.AttackGoldT);
        _defenseGoldT = GetText((int)Texts.DefenseGoldT);
        _attackIncrementT = GetText((int)Texts.AttackIncrementT);
        _defenseIncrementT = GetText((int)Texts.DefenseIncrementT);

        _attackIncrease = GetImage((int)Images.AttackIncrease);
        _defenseIncrease = GetImage((int)Images.DefenseIncrease);

        BindEvent(_attackIncrease.gameObject, AddAttack, Define.UIEvent.Click);
        BindEvent(_defenseIncrease.gameObject, AddDefense, Define.UIEvent.Click);
    }

    void AddAttack(PointerEventData eventData)
    {
        if (_playerStat.Gold >= int.Parse(_attackGoldT.text))
        {
            _playerStat.AddGold(-int.Parse(_attackGoldT.text));
            _playerStat.AddAttack(int.Parse(_attackIncrementT.text));
            AddAttackGoldAndIncrement();
        }
        else
        {
            Debug.Log("∞ÒµÂ ∫Œ¡∑");
        }
    }

    void AddAttackGoldAndIncrement()
    {
        _attackGoldT.text = $"{int.Parse(_attackGoldT.text) + 10}";
        _attackIncrementT.text = $"{int.Parse(_attackIncrementT.text) + 1}";
    }

    void AddDefense(PointerEventData eventData)
    {
        if (_playerStat.Gold >= int.Parse(_attackGoldT.text))
        {
            _playerStat.AddGold(-int.Parse(_defenseGoldT.text));
            _playerStat.AddDefense(int.Parse(_defenseIncrementT.text));
            AddDefenseGoldAndIncrement();
        }
        else
        {
            Debug.Log("∞ÒµÂ ∫Œ¡∑");
        }
    }

    void AddDefenseGoldAndIncrement()
    {
        _defenseGoldT.text = $"{int.Parse(_defenseGoldT.text) + 10}";
        _defenseIncrementT.text = $"{int.Parse(_defenseIncrementT.text) + 1}";
    }
}
