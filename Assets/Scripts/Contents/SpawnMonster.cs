using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnMonster : MonoBehaviour
{
    StageStat _stageStat;
    int _spawnNumber;
    float _spawnTime;
    GameObject target;
    GameObject[] _spawnPositions;

    void Awake()
    {
        _stageStat = GameObject.Find("@GameScene").GetComponent<StageStat>();
        _spawnNumber = MainManager.Data.StageInfo["Stage"].spawnNumber;
        _spawnTime = MainManager.Data.StageInfo["Stage"].spawnTime;
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
            Debug.Log("Stage " + _stageStat.Level);
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
                    _spawnNumber = _stageStat.SpawnNumber;
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
        _stageStat.AddLevel(1);
        _stageStat.AddSpawnNumber(1);
        MainManager.Data.MonsterInfo[Enum.GetName(typeof(Define.GameObjects), (int)Define.GameObjects.Monster)].maxHp += _stageStat.AddHp;
        MainManager.Data.MonsterInfo[Enum.GetName(typeof(Define.GameObjects), (int)Define.GameObjects.Monster)].hp += _stageStat.AddHp;
        MainManager.Data.MonsterStat[Enum.GetName(typeof(Define.GameObjects), (int)Define.GameObjects.Monster)].defense += _stageStat.AddDefense;
        _spawnNumber = _stageStat.SpawnNumber;
    }
}
