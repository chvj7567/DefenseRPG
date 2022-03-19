using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Game : UI_Base
{
    Image[] _icon;

    enum Images
    {
        Setting,
        ResearchShop,
        GoldShop,
        CrystalShop,
        Inventory,
    }

    public override void Init()
    {
        _icon = new Image[Enum.GetNames(typeof(Images)).Length];

        Bind<Image>(typeof(Images));

        _icon[(int)Images.Setting] = GetImage((int)Images.Setting);
        _icon[(int)Images.ResearchShop] = GetImage((int)Images.ResearchShop);
        _icon[(int)Images.GoldShop] = GetImage((int)Images.GoldShop);
        _icon[(int)Images.CrystalShop] = GetImage((int)Images.CrystalShop);
        _icon[(int)Images.Inventory] = GetImage((int)Images.Inventory);

        BindEvent(_icon[(int)Images.Setting].gameObject, SettingGame, Define.UIEvent.Click);
        BindEvent(_icon[(int)Images.ResearchShop].gameObject, ResearchGame, Define.UIEvent.Click);
        BindEvent(_icon[(int)Images.GoldShop].gameObject, GoldGame, Define.UIEvent.Click);
        BindEvent(_icon[(int)Images.CrystalShop].gameObject, CrystalGame, Define.UIEvent.Click);
        BindEvent(_icon[(int)Images.Inventory].gameObject, InventoryGame, Define.UIEvent.Click);
    }

    public void SettingGame(PointerEventData eventData)
    {
        MainManager.UI.ShowUI("SettingUI", Define.UI.Setting);
    }

    public void ResearchGame(PointerEventData eventData)
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

    public void GoldGame(PointerEventData eventData)
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
    public void CrystalGame(PointerEventData eventData)
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

    public void InventoryGame(PointerEventData eventData)
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
}
