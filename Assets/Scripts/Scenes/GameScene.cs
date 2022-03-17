using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();
        MainManager.Game.Spawn(Define.GameObjects.Map, "Map");
        MainManager.Game.Spawn(Define.GameObjects.Player, "Tank_Green").transform.position = new Vector3(0, 2, -12);

        GameObject spawning = new GameObject { name = "@Spawning" };
        spawning.GetOrAddComponent<SpawnMonster>();
    }

    public override void Clear()
    {

    }
}