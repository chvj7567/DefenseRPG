using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Stage : UI_Base
{
    Text _stageT;

    enum Texts
    {
        StageT,
    }

    public override void Init()
    {
        Bind<Text>(typeof(Texts));

        _stageT = GetText((int)Texts.StageT);
    }

    public void SetStage(int stage)
    {
        _stageT.text = $"Stage {stage}";
    }
}
