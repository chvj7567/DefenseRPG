using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Research : UI_Base
{
    PlayerStat _stat;
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
        _stat = MainManager.Game.Player.GetComponent<PlayerStat>();

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
        _stat.AddAttack(1);
    }

    void AddDefense(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }
}
