using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Gold : UI_Base
{
    Text _goldTextT;
    Image _green, _yellow, _blue, _red;
    Image _addTank, _left, _right;
    int _currentPage;
    enum Texts
    {
        GoldCostT,
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
        _currentPage = (int)Images.Green;

        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));

        _goldTextT = GetText((int)Texts.GoldCostT);
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
    }

    void AddTank(PointerEventData eventData)
    {
        if (_green.gameObject.activeSelf)
        {
            MainManager.Game.Spawn(Define.GameObjects.Tank, "Tank_Green").transform.position = new Vector3(5, 1, -12);
        }
        else if (_yellow.gameObject.activeSelf)
        {
            MainManager.Game.Spawn(Define.GameObjects.Tank, "Tank_Yellow").transform.position = new Vector3(5, 2, -12);
        }
        else if (_blue.gameObject.activeSelf)
        {
            MainManager.Game.Spawn(Define.GameObjects.Tank, "Tank_Blue").transform.position = new Vector3(5, 3, -12);
        }
        else if (_red.gameObject.activeSelf)
        {
            MainManager.Game.Spawn(Define.GameObjects.Tank, "Tank_Red").transform.position = new Vector3(5, 4, -12);
        }
    }

    void LeftPage(PointerEventData eventData)
    {
        if (_currentPage == (int)Images.Green)
        {
            _green.gameObject.SetActive(false);
            _red.gameObject.SetActive(true);
            _currentPage = (int)Images.Red;
        }
        else if (_currentPage == (int)Images.Yellow)
        {
            _yellow.gameObject.SetActive(false);
            _green.gameObject.SetActive(true);
            _currentPage = (int)Images.Green;
        }
        else if (_currentPage == (int)Images.Blue)
        {
            _blue.gameObject.SetActive(false);
            _yellow.gameObject.SetActive(true);
            _currentPage = (int)Images.Yellow;
        }
        else if (_currentPage == (int)Images.Red)
        {
            _red.gameObject.SetActive(false);
            _blue.gameObject.SetActive(true);
            _currentPage = (int)Images.Blue;
        }
    }

    void RightPage(PointerEventData eventData)
    {
        if (_currentPage == (int)Images.Green)
        {
            _green.gameObject.SetActive(false);
            _yellow.gameObject.SetActive(true);
            _currentPage = (int)Images.Yellow;
        }
        else if (_currentPage == (int)Images.Yellow)
        {
            _yellow.gameObject.SetActive(false);
            _blue.gameObject.SetActive(true);
            _currentPage = (int)Images.Blue;
        }
        else if (_currentPage == (int)Images.Blue)
        {
            _blue.gameObject.SetActive(false);
            _red.gameObject.SetActive(true);
            _currentPage = (int)Images.Red;
        }
        else if (_currentPage == (int)Images.Red)
        {
            _red.gameObject.SetActive(false);
            _green.gameObject.SetActive(true);
            _currentPage = (int)Images.Green;
        }
    }
}
