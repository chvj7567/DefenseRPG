using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Crystal : UI_Base
{
    PlayerStat _playerStat;
    Text _snowCost, _strongCost;
    Image _snow, _strong;
    Image _increment, _left, _right;
    int _currentPage;
    enum Texts
    {
        SnowCost,
        StrongCost,
    }

    enum Images
    {
        Snow,
        Strong,
        Increment,
        Left,
        Right,
    }

    public override void Init()
    {
        _playerStat = MainManager.Game.Player.GetComponent<PlayerStat>();
        _currentPage = (int)Images.Snow;

        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));

        _snowCost = GetText((int)Texts.SnowCost);
        _strongCost = GetText((int)Texts.StrongCost);

        _snow = GetImage((int)Images.Snow);
        _strong = GetImage((int)Images.Strong);
        _increment = GetImage((int)Images.Increment);
        _left = GetImage((int)Images.Left);
        _right = GetImage((int)Images.Right);

        BindEvent(_increment.gameObject, IncrementSkill, Define.UIEvent.Click);
        BindEvent(_left.gameObject, LeftPage, Define.UIEvent.Click);
        BindEvent(_right.gameObject, RightPage, Define.UIEvent.Click);

        _strongCost.gameObject.SetActive(false);
        _strong.gameObject.SetActive(false);
    }

    void IncrementSkill(PointerEventData eventData)
    {
        if (_currentPage == (int)Images.Snow && _playerStat.Crystal >= int.Parse(_snowCost.text))
        {
            _playerStat.AddSnow(10);
            _playerStat.AddCrystal(-int.Parse(_snowCost.text));
            _snowCost.text = $"{int.Parse(_snowCost.text) * 2}";
        }
        else if (_currentPage == (int)Images.Strong && _playerStat.Crystal >= int.Parse(_strongCost.text))
        {
            _playerStat.AddStrong(10);
            _playerStat.AddCrystal(-int.Parse(_strongCost.text));
            _strongCost.text = $"{int.Parse(_strongCost.text) * 2}";
        }
    }

    void LeftPage(PointerEventData eventData)
    {
        if (_currentPage == (int)Images.Snow)
        {
            _snow.gameObject.SetActive(false);
            _strong.gameObject.SetActive(true);

            _snowCost.gameObject.SetActive(false);
            _strongCost.gameObject.SetActive(true);

            _currentPage = (int)Images.Strong;
        }
        else if (_currentPage == (int)Images.Strong)
        {
            _strong.gameObject.SetActive(false);
            _snow.gameObject.SetActive(true);

            _strongCost.gameObject.SetActive(false);
            _snowCost.gameObject.SetActive(true);

            _currentPage = (int)Images.Snow;
        }
    }

    void RightPage(PointerEventData eventData)
    {
        if (_currentPage == (int)Images.Snow)
        {
            _snow.gameObject.SetActive(false);
            _strong.gameObject.SetActive(true);

            _snowCost.gameObject.SetActive(false);
            _strongCost.gameObject.SetActive(true);

            _currentPage = (int)Images.Strong;
        }
        else if (_currentPage == (int)Images.Strong)
        {
            _strong.gameObject.SetActive(false);
            _snow.gameObject.SetActive(true);

            _strongCost.gameObject.SetActive(false);
            _snowCost.gameObject.SetActive(true);

            _currentPage = (int)Images.Snow;
        }
    }
}
