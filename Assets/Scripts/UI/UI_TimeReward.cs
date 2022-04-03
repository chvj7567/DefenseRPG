using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TimeReward : UI_Base
{
    Text _timeT, _goldRewardT, _crystalRewardT;

    enum Texts
    {
        TimeT,
        GoldRewardT,
        CrystalRewardT,
    }

    public override void Init()
    {
        Bind<Text>(typeof(Texts));

        _timeT = GetText((int)Texts.TimeT);
        _goldRewardT = GetText((int)Texts.GoldRewardT);
        _crystalRewardT = GetText((int)Texts.CrystalRewardT);

        Reward();
    }

    void Reward()
    {
        DateTime lastTime = Convert.ToDateTime(MainManager.Data.PlayerGame["Player"].lastTime);
        DateTime currentTime = DateTime.Now;

        TimeSpan time = currentTime - lastTime;

        int minutes = (int)Mathf.Clamp(time.Hours * 60f + time.Minutes, -48000f, 480f);

        _timeT.text = $"½Ã°£º¸»ó : {minutes}/480";
        _goldRewardT.text = $"{minutes * 10} °ñµå";
        _crystalRewardT.text = $"{minutes * 10} Å©¸®½ºÅ»";
        MainManager.Data.PlayerInfo["Player"].gold += minutes * 10;
        MainManager.Data.PlayerInfo["Player"].crystal += minutes * 10;
    }
}
