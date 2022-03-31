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
        //MainManager.Game.Spawn(Define.GameObjects.MainCamera, "Player");
        //MainManager.Game.ChangeCamera(MainManager.Game.MainCamera);
        MainManager.UI.ShowUI("GameUI", Define.UI.Game);
        MainManager.UI.ShowUI("SkillUI", Define.UI.Skill);

        /*if (GameObject.Find("@MonsterSpawning") == null)
        {
            GameObject spawning = new GameObject { name = "@MonsterSpawning" };
            spawning.GetOrAddComponent<SpawnMonster>();
        }*/
        if (GameObject.Find("@TankSpawning") == null)
        {
            GameObject spawning = new GameObject { name = "@TankSpawning" };
            MainManager.Game.TankSpawning = spawning.GetOrAddComponent<SpawnTank>();
            MainManager.Game.TankSpawning.CreateAllTank();
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