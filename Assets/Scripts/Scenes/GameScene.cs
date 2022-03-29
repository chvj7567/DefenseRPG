using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scenes.Game;
        MainManager.Game.Spawn(Define.GameObjects.Map, "Ground");
        MainManager.Game.Spawn(Define.GameObjects.Player, "Player");
        MainManager.Game.Spawn(Define.GameObjects.Tank, "Tank_Green").transform.position = new Vector3(0, 1, -12);
        //MainManager.Game.Spawn(Define.GameObjects.MainCamera, "Player");
        //MainManager.Game.ChangeCamera(MainManager.Game.MainCamera);
        MainManager.UI.ShowUI("GameUI", Define.UI.Game);
        MainManager.UI.ShowUI("SkillUI", Define.UI.Skill);

        if (GameObject.Find("@Spawning") == null)
        {
            GameObject spawning = new GameObject { name = "@Spawning" };
            spawning.GetOrAddComponent<SpawnMonster>();
        }
    }

    private void Update()
    {
        Quaternion qua = Sun.transform.rotation;
        qua.eulerAngles += new Vector3(Time.deltaTime, 0f, 0f);
        Sun.transform.rotation = qua;
    }

    public override void Clear()
    {

    }
}