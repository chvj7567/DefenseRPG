using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Setting : UI_Base
{
    Image _volume, _back, _exit;
    Slider _slider;

    enum Images
    {
        Volume,
        Back,
        Exit,
    }

    public override void Init()
    {
        Bind<Image>(typeof(Images));

        _volume = GetImage((int)Images.Volume);
        _back = GetImage((int)Images.Back);
        _exit = GetImage((int)Images.Exit);

        _slider = Util.FindChild<Slider>(_volume.gameObject, "Slider");

        BindEvent(_volume.gameObject, SliderVolume);
        BindEvent(_back.gameObject, BackGame, Define.UIEvent.Click);
        BindEvent(_exit.gameObject, ExitGame, Define.UIEvent.Click);
    }

    void SliderVolume()
    {
        MainManager.Audio.SetVolume(_slider.value);
    }

    void BackGame(PointerEventData data)
    {
        MainManager.UI.HideUI(gameObject);
    }

    void ExitGame(PointerEventData data)
    {
        Debug.Log("데이터 저장 후 종료");
        MainManager.Data.SaveData();
        MainManager.Game.ExitGame();
    }
}
