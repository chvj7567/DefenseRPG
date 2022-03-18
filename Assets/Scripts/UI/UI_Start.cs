using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class UI_Start : UI_Base
{
    Image _background, _title, _game, _setting;
    public Action onStartAction = null;
    enum Images
    {
        Background,
        Title,
        Game,
        Setting,
    }

    public override void Init()
    {
        Bind<Image>(typeof(Images));
        _background = GetImage((int)Images.Background);
        _title = GetImage((int)Images.Title);
        _game = GetImage((int)Images.Game);
        _setting = GetImage((int)Images.Setting);

        BindEvent(_game.gameObject, StartGame, Define.UIEvent.Click);
        BindEvent(_setting.gameObject, SettingGame, Define.UIEvent.Click);
    }

    void StartGame(PointerEventData eventData)
    {
        if (onStartAction != null)
            onStartAction.Invoke();
    }

    void SettingGame(PointerEventData eventData)
    {
        MainManager.UI.HideUI(gameObject, Define.UI.Start);
        MainManager.UI.ShowUI("SettingUI", Define.UI.Setting);
    }
}
