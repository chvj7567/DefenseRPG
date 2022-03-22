using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Game : UI_Base
{
    string _player;
    string[] _tanks;
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
        _player = "Player";
        _tanks = Enum.GetNames(typeof(Define.Players));

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
        BindEvent(_icon[(int)Images.ExpBar].gameObject, GetExp);

        BindEvent(_text[(int)Texts.AttackT].gameObject, GetAttack);
        BindEvent(_text[(int)Texts.DefenseT].gameObject, GetDefense);
        BindEvent(_text[(int)Texts.GoldT].gameObject, GetGold);
        BindEvent(_text[(int)Texts.CrystalT].gameObject, GetCrystal);
        BindEvent(_text[(int)Texts.LevelT].gameObject, GetLevel);
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

    public void GetAttack() { SetAttack(); }
    public void GetDefense() { SetDefense(); }
    public void GetGold() { SetGold(); }
    public void GetCrystal() { SetCrystal(); }
    public void GetLevel() { SetLevel(); }
    public void GetExp() { SetExp(); }

    public void SetAttack(string tank = null, int attack = 0)
    {
        int totAttack = 0;

        if (tank != null)
        {
            foreach (string name in _tanks)
            {
                if (tank == name)
                {
                    MainManager.Data.PlayerStat[tank].attack += attack;
                }
            }
        }

        foreach (string name in _tanks)
        {
            totAttack += MainManager.Data.PlayerStat[name].attack;
        }

        _text[(int)Texts.AttackT].text = $"{totAttack}";
    }

    public void SetDefense(int defense = 0)
    {
        MainManager.Data.PlayerStat[_player].defense += defense;
        _text[(int)Texts.DefenseT].text = $"{MainManager.Data.PlayerStat[_player].defense}";
    }

    public void SetGold(int gold = 0)
    {
        MainManager.Data.PlayerStat[_player].gold += gold;
        _text[(int)Texts.GoldT].text = $"{MainManager.Data.PlayerStat[_player].gold}";
    }

    public void SetCrystal(int crystal = 0)
    {
        MainManager.Data.PlayerStat[_player].crystal += crystal;
        _text[(int)Texts.CrystalT].text = $"{MainManager.Data.PlayerStat[_player].crystal}";
    }

    public void SetLevel(int level = 0)
    {
        MainManager.Data.PlayerStat[_player].level += level;
        _text[(int)Texts.LevelT].text = $"{MainManager.Data.PlayerStat[_player].level}";
    }

    public void SetExp(int exp = 0)
    {
        MainManager.Data.PlayerStat[_player].exp += exp;
        if (MainManager.Data.PlayerStat[_player].exp >= MainManager.Data.PlayerStat[_player].maxExp)
        {
            Debug.Log("Level Up!");
            SetLevel(1);
            MainManager.Data.PlayerStat[_player].maxExp *= 2;
            MainManager.Data.PlayerStat[_player].maxHp *= 2;
            MainManager.Data.PlayerStat[_player].hp = MainManager.Data.PlayerStat[_player].maxHp;
            MainManager.Data.PlayerStat[_player].defense *= 2;
            MainManager.Data.PlayerStat[_player].exp = 0;
            //MainManager.Data.ChangeLevel();
        }
        else
        {
            _icon[(int)Images.ExpBar].fillAmount = (MainManager.Data.PlayerStat[_player].exp) / (float)MainManager.Data.PlayerStat[_player].maxExp;
        }
    }
}
