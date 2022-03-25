using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Gold : UI_Base
{
    PlayerStat _playerStat;
    Text _greenCost, _yellowCost, _blueCost, _redCost;
    Image _green, _yellow, _blue, _red;
    Image _addTank, _left, _right;
    int _currentPage;
    enum Texts
    {
        GreenCost,
        YellowCost,
        BlueCost,
        RedCost,
    }
    enum Images
    {
        Green,
        Yellow,
        Blue,
        Red,
        AddTank,
        Left,
        Right,
    }
    public override void Init()
    {
        _playerStat = MainManager.Game.Player.GetComponent<PlayerStat>();
        _currentPage = (int)Images.Green;

        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));

        _greenCost = GetText((int)Texts.GreenCost);
        _yellowCost = GetText((int)Texts.YellowCost);
        _blueCost = GetText((int)Texts.BlueCost);
        _redCost = GetText((int)Texts.RedCost);
        _green = GetImage((int)Images.Green);
        _yellow = GetImage((int)Images.Yellow);
        _blue = GetImage((int)Images.Blue);
        _red = GetImage((int)Images.Red);
        _addTank = GetImage((int)Images.AddTank);
        _left = GetImage((int)Images.Left);
        _right = GetImage((int)Images.Right);

        BindEvent(_addTank.gameObject, AddTank, Define.UIEvent.Click);
        BindEvent(_left.gameObject, LeftPage, Define.UIEvent.Click);
        BindEvent(_right.gameObject, RightPage, Define.UIEvent.Click);

        _yellow.gameObject.SetActive(false);
        _blue.gameObject.SetActive(false);
        _red.gameObject.SetActive(false);
        _yellowCost.gameObject.SetActive(false);
        _blueCost.gameObject.SetActive(false);
        _redCost.gameObject.SetActive(false);
    }

    void AddTank(PointerEventData eventData)
    {
        if (_currentPage == (int)Images.Green && _playerStat.Gold >= int.Parse(_greenCost.text))
        {
            _playerStat.AddGold(-int.Parse(_greenCost.text));
            MainManager.Game.Spawn(Define.GameObjects.Tank, "Tank_Green").transform.position = new Vector3(5, 1, -12);
        }
        else if (_currentPage == (int)Images.Yellow && _playerStat.Gold >= int.Parse(_yellowCost.text))
        {
            _playerStat.AddGold(-int.Parse(_yellowCost.text));
            MainManager.Game.Spawn(Define.GameObjects.Tank, "Tank_Yellow").transform.position = new Vector3(5, 2, -12);
        }
        else if (_currentPage == (int)Images.Blue && _playerStat.Gold >= int.Parse(_blueCost.text))
        {
            _playerStat.AddGold(-int.Parse(_blueCost.text));
            MainManager.Game.Spawn(Define.GameObjects.Tank, "Tank_Blue").transform.position = new Vector3(5, 3, -12);
        }
        else if (_currentPage == (int)Images.Red && _playerStat.Gold >= int.Parse(_redCost.text))
        {
            _playerStat.AddGold(-int.Parse(_redCost.text));
            MainManager.Game.Spawn(Define.GameObjects.Tank, "Tank_Red").transform.position = new Vector3(5, 4, -12);
        }
    }

    void LeftPage(PointerEventData eventData)
    {
        if (_currentPage == (int)Images.Green)
        {
            _green.gameObject.SetActive(false);
            _red.gameObject.SetActive(true);

            _greenCost.gameObject.SetActive(false);
            _redCost.gameObject.SetActive(true);

            _currentPage = (int)Images.Red;
        }
        else if (_currentPage == (int)Images.Yellow)
        {
            _yellow.gameObject.SetActive(false);
            _green.gameObject.SetActive(true);

            _yellowCost.gameObject.SetActive(false);
            _greenCost.gameObject.SetActive(true);

            _currentPage = (int)Images.Green;
        }
        else if (_currentPage == (int)Images.Blue)
        {
            _blue.gameObject.SetActive(false);
            _yellow.gameObject.SetActive(true);

            _blueCost.gameObject.SetActive(false);
            _yellowCost.gameObject.SetActive(true);

            _currentPage = (int)Images.Yellow;
        }
        else if (_currentPage == (int)Images.Red)
        {
            _red.gameObject.SetActive(false);
            _blue.gameObject.SetActive(true);

            _redCost.gameObject.SetActive(false);
            _blueCost.gameObject.SetActive(true);

            _currentPage = (int)Images.Blue;
        }
    }

    void RightPage(PointerEventData eventData)
    {
        if (_currentPage == (int)Images.Green)
        {
            _green.gameObject.SetActive(false);
            _yellow.gameObject.SetActive(true);

            _greenCost.gameObject.SetActive(false);
            _yellowCost.gameObject.SetActive(true);

            _currentPage = (int)Images.Yellow;
        }
        else if (_currentPage == (int)Images.Yellow)
        {
            _yellow.gameObject.SetActive(false);
            _blue.gameObject.SetActive(true);

            _yellowCost.gameObject.SetActive(false);
            _blueCost.gameObject.SetActive(true);

            _currentPage = (int)Images.Blue;
        }
        else if (_currentPage == (int)Images.Blue)
        {
            _blue.gameObject.SetActive(false);
            _red.gameObject.SetActive(true);

            _blueCost.gameObject.SetActive(false);
            _redCost.gameObject.SetActive(true);

            _currentPage = (int)Images.Red;
        }
        else if (_currentPage == (int)Images.Red)
        {
            _red.gameObject.SetActive(false);
            _green.gameObject.SetActive(true);

            _redCost.gameObject.SetActive(false);
            _greenCost.gameObject.SetActive(true);

            _currentPage = (int)Images.Green;
        }
    }
}
