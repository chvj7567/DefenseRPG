using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : BaseScene
{
    GameObject _player;
    Vector3 _fristPos;
    GameObject _map;
    protected override void Init()
    {
        base.Init();
        MainManager.Audio.Play("MainBgm", Define.Audio.Bgm);
        MainManager.Game.Spawn(Define.GameObjects.Background, "Background");
        MainManager.UI.ShowUI("StartUI", Define.UI.Start);
    }

    public override void Clear()
    {

    }
}