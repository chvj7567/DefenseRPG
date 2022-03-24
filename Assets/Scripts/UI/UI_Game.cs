using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Game : UI_Base
{
    PlayerStat _playerStat;
    Image[] _icon;
    Text[] _text;

    enum Images
    {
        Setting,
        ResearchShop,
        GoldShop,
        CrystalShop,
        Inventory,
        ExpBar,
    }

    enum Texts
    {
        AttackT,
        DefenseT,
        GoldT,
        CrystalT,
        LevelT,
    }

    public override void Init()
    {
        _playerStat = MainManager.Game.Player.GetComponent<PlayerStat>();
        _icon = new Image[Enum.GetNames(typeof(Images)).Length];
        _text = new Text[Enum.GetNames(typeof(Texts)).Length];

        Bind<Image>(typeof(Images));
        Bind<Text>(typeof(Texts));

        _icon[(int)Images.Setting] = GetImage((int)Images.Setting);
        _icon[(int)Images.ResearchShop] = GetImage((int)Images.ResearchShop);
        _icon[(int)Images.GoldShop] = GetImage((int)Images.GoldShop);
        _icon[(int)Images.CrystalShop] = GetImage((int)Images.CrystalShop);
        _icon[(int)Images.Inventory] = GetImage((int)Images.Inventory);
        _icon[(int)Images.ExpBar] = GetImage((int)Images.ExpBar);

        _text[(int)Texts.AttackT] = GetText((int)Texts.AttackT);
        _text[(int)Texts.DefenseT] = GetText((int)Texts.DefenseT);
        _text[(int)Texts.GoldT] = GetText((int)Texts.GoldT);
        _text[(int)Texts.CrystalT] = GetText((int)Texts.CrystalT);
        _text[(int)Texts.LevelT] = GetText((int)Texts.LevelT);

        BindEvent(_icon[(int)Images.Setting].gameObject, SettingGame, Define.UIEvent.Click);
        BindEvent(_icon[(int)Images.ResearchShop].gameObject, ResearchGame, Define.UIEvent.Click);
        BindEvent(_icon[(int)Images.GoldShop].gameObject, GoldGame, Define.UIEvent.Click);
        BindEvent(_icon[(int)Images.CrystalShop].gameObject, CrystalGame, Define.UIEvent.Click);
        BindEvent(_icon[(int)Images.Inventory].gameObject, InventoryGame, Define.UIEvent.Click);
        BindEvent(_icon[(int)Images.ExpBar].gameObject, SetExp);

        BindEvent(_text[(int)Texts.AttackT].gameObject, SetAttack);
        BindEvent(_text[(int)Texts.DefenseT].gameObject, SetDefense);
        BindEvent(_text[(int)Texts.GoldT].gameObject, SetGold);
        BindEvent(_text[(int)Texts.CrystalT].gameObject, SetCrystal);
        BindEvent(_text[(int)Texts.LevelT].gameObject, SetLevel);
    }

    void SettingGame(PointerEventData eventData)
    {
        MainManager.UI.ShowUI("SettingUI", Define.UI.Setting);
    }

    void ResearchGame(PointerEventData eventData)
    {
        if (MainManager.UI.CurrentSubUI == null)
        {
            MainManager.UI.CurrentSubUI = MainManager.UI.ShowUI("ResearchUI", Define.UI.Research);
            return;
        }

        if (MainManager.UI.CurrentSubUI != MainManager.UI.Research)
        {
            MainManager.UI.HideUI(MainManager.UI.CurrentSubUI);
            MainManager.UI.CurrentSubUI = null;
            MainManager.UI.CurrentSubUI = MainManager.UI.ShowUI("ResearchUI", Define.UI.Research);
        }
        else
        {
            MainManager.UI.HideUI(MainManager.UI.CurrentSubUI);
            MainManager.UI.CurrentSubUI = null;
        }
    }

    void GoldGame(PointerEventData eventData)
    {
        if (MainManager.UI.CurrentSubUI == null)
        {
            MainManager.UI.CurrentSubUI = MainManager.UI.ShowUI("GoldUI", Define.UI.Gold);
            return;
        }

        if (MainManager.UI.CurrentSubUI != MainManager.UI.Gold)
        {
            MainManager.UI.HideUI(MainManager.UI.CurrentSubUI);
            MainManager.UI.CurrentSubUI = null;
            MainManager.UI.CurrentSubUI = MainManager.UI.ShowUI("GoldUI", Define.UI.Gold);
        }
        else
        {
            MainManager.UI.HideUI(MainManager.UI.CurrentSubUI);
            MainManager.UI.CurrentSubUI = null;
        }
    }

    void CrystalGame(PointerEventData eventData)
    {
        if (MainManager.UI.CurrentSubUI == null)
        {
            MainManager.UI.CurrentSubUI = MainManager.UI.ShowUI("CrystalUI", Define.UI.Crystal);
            return;
        }

        if (MainManager.UI.CurrentSubUI != MainManager.UI.Crystal)
        {
            MainManager.UI.HideUI(MainManager.UI.CurrentSubUI);
            MainManager.UI.CurrentSubUI = null;
            MainManager.UI.CurrentSubUI = MainManager.UI.ShowUI("CrystalUI", Define.UI.Crystal);
        }
        else
        {
            MainManager.UI.HideUI(MainManager.UI.CurrentSubUI);
            MainManager.UI.CurrentSubUI = null;
        }
    }

    void InventoryGame(PointerEventData eventData)
    {
        if (MainManager.UI.CurrentSubUI == null)
        {
            MainManager.UI.CurrentSubUI = MainManager.UI.ShowUI("InventoryUI", Define.UI.Inventory);
            return;
        }

        if (MainManager.UI.CurrentSubUI != MainManager.UI.Inventory)
        {
            MainManager.UI.HideUI(MainManager.UI.CurrentSubUI);
            MainManager.UI.CurrentSubUI = null;
            MainManager.UI.CurrentSubUI = MainManager.UI.ShowUI("InventoryUI", Define.UI.Inventory);
        }
        else
        {
            MainManager.UI.HideUI(MainManager.UI.CurrentSubUI);
            MainManager.UI.CurrentSubUI = null;
        }
    }
    
    void SetExp()
    {
        if (_playerStat.Level <= 1)
        {
            _icon[(int)Images.ExpBar].fillAmount = _playerStat.Exp / (float)_playerStat.MaxExp;
        }
        else
        {
            int before = _playerStat.MaxExp / 2;
            _icon[(int)Images.ExpBar].fillAmount = (_playerStat.Exp - before) / (float)(_playerStat.MaxExp - before);
        }
    }

    void SetAttack() { _text[(int)Texts.AttackT].text = $"{_playerStat.Attack}"; }
    void SetDefense() { _text[(int)Texts.DefenseT].text = $"{_playerStat.Defense}"; }
    void SetGold() { _text[(int)Texts.GoldT].text = $"{_playerStat.Gold}"; }
    void SetCrystal() { _text[(int)Texts.CrystalT].text = $"{_playerStat.Crystal}"; }
    void SetLevel() { _text[(int)Texts.LevelT].text = $"{_playerStat.Level}"; }
}
