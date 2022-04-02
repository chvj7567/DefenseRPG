using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Crystal : UI_Base
{
    GameStat _gameStat;
    PlayerStat _playerStat;
    Text _snowCost, _laserCost, _strongCost, _fastAttackCost;
    Image _snow, _laser, _strong, _fastAttack;
    Image _increment, _left, _right;
    int _currentPage;

    enum Texts
    {
        SnowCost,
        LaserCost,
        StrongCost,
        FastAttackCost,
    }

    enum Images
    {
        Snow,
        Laser,
        Strong,
        FastAttack,
        Increment,
        Left,
        Right,
    }

    public override void Init()
    {
        _gameStat = MainManager.Game.Player.GetComponent<GameStat>();
        _playerStat = MainManager.Game.Player.GetComponent<PlayerStat>();
        _currentPage = (int)Images.Snow;

        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));

        _snowCost = GetText((int)Texts.SnowCost);
        _laserCost = GetText((int)Texts.LaserCost);
        _strongCost = GetText((int)Texts.StrongCost);
        _fastAttackCost = GetText((int)Texts.FastAttackCost);
        _snow = GetImage((int)Images.Snow);
        _laser = GetImage((int)Images.Laser);
        _strong = GetImage((int)Images.Strong);
        _fastAttack = GetImage((int)Images.FastAttack);
        _increment = GetImage((int)Images.Increment);
        _left = GetImage((int)Images.Left);
        _right = GetImage((int)Images.Right);

        _snowCost.text = $"{_gameStat.SnowCrystal}";
        _laserCost.text = $"{_gameStat.LaserCrystal}";
        _strongCost.text = $"{_gameStat.StrongCrystal}";
        _fastAttackCost.text = $"{_gameStat.FastAttackCrystal}";

        BindEvent(_increment.gameObject, IncrementSkill, Define.UIEvent.Click);
        BindEvent(_left.gameObject, LeftPage, Define.UIEvent.Click);
        BindEvent(_right.gameObject, RightPage, Define.UIEvent.Click);

        _laserCost.gameObject.SetActive(false);
        _strongCost.gameObject.SetActive(false);
        _fastAttackCost.gameObject.SetActive(false);
        _laser.gameObject.SetActive(false);
        _strong.gameObject.SetActive(false);
        _fastAttack.gameObject.SetActive(false);
    }

    void IncrementSkill(PointerEventData eventData)
    {
        if (_currentPage == (int)Images.Snow && _playerStat.Crystal >= int.Parse(_snowCost.text))
        {
            _playerStat.AddSnow(10);
            _playerStat.AddCrystal(-int.Parse(_snowCost.text));
            _gameStat.AddSnowCrystal(int.Parse(_snowCost.text));
            _snowCost.text = $"{_gameStat.SnowCrystal}";
        }
        else if (_currentPage == (int)Images.Laser && _playerStat.Crystal >= int.Parse(_laserCost.text))
        {
            _playerStat.AddLaser(10);
            _playerStat.AddCrystal(-int.Parse(_laserCost.text));
            _gameStat.AddLaserCrystal(int.Parse(_laserCost.text));
            _laserCost.text = $"{_gameStat.LaserCrystal}";
        }
        else if (_currentPage == (int)Images.Strong && _playerStat.Crystal >= int.Parse(_strongCost.text))
        {
            _playerStat.AddStrong(10);
            _playerStat.AddCrystal(-int.Parse(_strongCost.text));
            _gameStat.AddStrongCrystal(int.Parse(_strongCost.text));
            _strongCost.text = $"{_gameStat.StrongCrystal}";
        }
        else if (_currentPage == (int)Images.FastAttack && _playerStat.Crystal >= int.Parse(_fastAttackCost.text))
        {
            _playerStat.AddFastAttack(0.5f);
            _playerStat.AddCrystal(-int.Parse(_fastAttackCost.text));
            _gameStat.AddFastAttackCrystal(int.Parse(_fastAttackCost.text));
            _fastAttackCost.text = $"{_gameStat.FastAttackCrystal}";
        }
    }

    void LeftPage(PointerEventData eventData)
    {
        if (_currentPage == (int)Images.Snow)
        {
            _snow.gameObject.SetActive(false);
            _fastAttack.gameObject.SetActive(true);

            _snowCost.gameObject.SetActive(false);
            _fastAttackCost.gameObject.SetActive(true);

            _currentPage = (int)Images.FastAttack;
        }
        else if (_currentPage == (int)Images.Laser)
        {
            _snow.gameObject.SetActive(true);
            _laser.gameObject.SetActive(false);

            _snowCost.gameObject.SetActive(true);
            _laserCost.gameObject.SetActive(false);

            _currentPage = (int)Images.Snow;
        }
        else if (_currentPage == (int)Images.Strong)
        {
            _laser.gameObject.SetActive(true);
            _strong.gameObject.SetActive(false);

            _laserCost.gameObject.SetActive(true);
            _strongCost.gameObject.SetActive(false);

            _currentPage = (int)Images.Laser;
        }
        else if (_currentPage == (int)Images.FastAttack)
        {
            _strong.gameObject.SetActive(true);
            _fastAttack.gameObject.SetActive(false);

            _strongCost.gameObject.SetActive(true);
            _fastAttackCost.gameObject.SetActive(false);

            _currentPage = (int)Images.Strong;
        }
    }

    void RightPage(PointerEventData eventData)
    {
        if (_currentPage == (int)Images.Snow)
        {
            _snow.gameObject.SetActive(false);
            _laser.gameObject.SetActive(true);

            _snowCost.gameObject.SetActive(false);
            _laserCost.gameObject.SetActive(true);

            _currentPage = (int)Images.Laser;
        }
        else if (_currentPage == (int)Images.Laser)
        {
            _laser.gameObject.SetActive(false);
            _strong.gameObject.SetActive(true);

            _laserCost.gameObject.SetActive(false);
            _strongCost.gameObject.SetActive(true);

            _currentPage = (int)Images.Strong;
        }
        else if (_currentPage == (int)Images.Strong)
        {
            _strong.gameObject.SetActive(false);
            _fastAttack.gameObject.SetActive(true);

            _strongCost.gameObject.SetActive(false);
            _fastAttackCost.gameObject.SetActive(true);

            _currentPage = (int)Images.FastAttack;
        }
        else if (_currentPage == (int)Images.FastAttack)
        {
            _fastAttack.gameObject.SetActive(false);
            _snow.gameObject.SetActive(true);

            _fastAttackCost.gameObject.SetActive(false);
            _snowCost.gameObject.SetActive(true);

            _currentPage = (int)Images.Snow;
        }
    }
}
