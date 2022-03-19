using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Loading : UI_Base
{
    CanvasGroup _canvasGroup;
    public Image Bar { get; set; }

    enum Images
    {
        LoadingBar,
    }

    public override void Init()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0f;
        
        Bind<Image>(typeof(Images));
        Bar = GetImage((int)Images.LoadingBar);
        Bar.fillAmount = 0f;
    }
}