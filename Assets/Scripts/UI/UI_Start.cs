using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Start : UI_Base
{
    Image _background, _title, _game, _setting;
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
        MainManager.UI.HideUI(gameObject, Define.UI.Start);
    }

    void SettingGame(PointerEventData eventData)
    {
        MainManager.UI.HideUI(gameObject, Define.UI.Start);
        MainManager.UI.ShowUI("SettingUI", Define.UI.Setting);
    }
}
