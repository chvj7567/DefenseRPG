using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnMonster : MonoBehaviour
{
    GameStat _gameStat;
    int _spawnNumber;
    float _spawnTime;
    GameObject target;
    GameObject[] _spawnPositions;

    void Awake()
    {
        _gameStat = MainManager.Game.Player.GetComponent<GameStat>();
        _spawnNumber = MainManager.Data.PlayerGame[Enum.GetName(typeof(Define.GameObjects), (int)Define.GameObjects.Player)].spawnNumber;
        _spawnTime = MainManager.Data.PlayerGame[Enum.GetName(typeof(Define.GameObjects), (int)Define.GameObjects.Player)].spawnTime;
        _spawnPositions = GameObject.FindGameObjectsWithTag("MonsterSpawn");
        target = GameObject.FindGameObjectWithTag("Finish");
    }

    void Start()
    {
        StartCoroutine(CreateMonster());
    }

    IEnumerator CreateMonster()
    {
        while (true)
        {
            StartCoroutine(Stage());
            while (_spawnNumber > 0)
            {
                foreach (GameObject go in _spawnPositions)
                {
                    GameObject monster = MainManager.Game.Spawn(Define.GameObjects.Monster, "Monster", go.transform);
                    monster.transform.localPosition = Vector3.zero;
                    NavMeshAgent nma = monster.GetOrAddComponent<NavMeshAgent>();
                    nma.SetDestination(target.transform.position);
                }

                yield return new WaitForSeconds(_spawnTime);
                _spawnNumber--;
            }

            while (true)
            {
                if (MainManager.Game.Monster.Count == 0)
                {
                    PlayerStat playerStat = MainManager.Game.Player.GetComponent<PlayerStat>();
                    if (playerStat.Defense > 0)
                        StartCoroutine(NextStage());
                    playerStat.ResetDefense();
                    _spawnNumber = _gameStat.SpawnNumber;
                    break;
                }
                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSeconds(3f);
        }
    }

    IEnumerator NextStage()
    {
        yield return null;
        _gameStat.AddStage(1);
        _gameStat.AddSpawnNumber(1);
        MainManager.Data.MonsterInfo[Enum.GetName(typeof(Define.GameObjects), (int)Define.GameObjects.Monster)].maxHp += _gameStat.AddHp;
        MainManager.Data.MonsterInfo[Enum.GetName(typeof(Define.GameObjects), (int)Define.GameObjects.Monster)].hp += _gameStat.AddHp;
        MainManager.Data.MonsterStat[Enum.GetName(typeof(Define.GameObjects), (int)Define.GameObjects.Monster)].defense += _gameStat.AddDefense;
        _spawnNumber = _gameStat.SpawnNumber;
    }

    IEnumerator Stage()
    {
        MainManager.UI.ShowUI("StageUI", Define.UI.Stage);
        UI_Stage stage = MainManager.UI.Stage.GetComponent<UI_Stage>();
        yield return new WaitForSeconds(1f);
        MainManager.Audio.Play("Stage", Define.Audio.Effect);
        stage.SetStage(_gameStat.Stage);
        yield return new WaitForSeconds(2f);
        MainManager.UI.HideUI(MainManager.UI.Stage);
    }
}
