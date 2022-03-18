using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    UI_Start _startUI;

    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scenes.Lobby;
        _startUI = MainManager.UI.ShowUI("StartUI", Define.UI.Start).GetComponent<UI_Start>();
        _startUI.onStartAction -= LoadGameScene;
        _startUI.onStartAction += LoadGameScene;
    }

    void LoadGameScene()
    {
        MainManager.Scene.LoadScene(Define.Scenes.Game);
    }

    public override void Clear()
    {

    }
}
