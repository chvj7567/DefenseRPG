using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Setting : UI_Base
{
    Image _volume, _back;
    Slider _slider;

    enum Images
    {
        Volume,
        Back,
    }

    public override void Init()
    {
        Bind<Image>(typeof(Images));

        _volume = GetImage((int)Images.Volume);
        _back = GetImage((int)Images.Back);

        _slider = Util.FindChild<Slider>(_volume.gameObject, "Slider");

        BindEvent(_volume.gameObject, SliderVolume);
        BindEvent(_back.gameObject, BackGame, Define.UIEvent.Click);
    }

    public void SliderVolume()
    {
        MainManager.Audio.SetVolume(_slider.value);
    }

    public void BackGame(PointerEventData data)
    {
        MainManager.UI.HideUI(gameObject, Define.UI.Setting);
        MainManager.UI.ShowUI("StartUI", Define.UI.Start);
    }
}
