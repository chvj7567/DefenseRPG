using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        MainManager.Game.Spawn(Define.GameObjects.Map, "Ground");
        MainManager.Game.Spawn(Define.GameObjects.Tank, "Tank_Green").transform.position = new Vector3(0, 1, -12);
        MainManager.Game.Spawn(Define.GameObjects.MainCamera, "Player");
        MainManager.Game.ChangeCamera(MainManager.Game.MainCamera);
        MainManager.UI.ShowUI("GameUI", Define.UI.Game);

        /*if (GameObject.Find("@Spawning") == null)
        {
            GameObject spawning = new GameObject { name = "@Spawning" };
            spawning.GetOrAddComponent<SpawnMonster>();
        }*/
    }

    public override void Clear()
    {

    }
}