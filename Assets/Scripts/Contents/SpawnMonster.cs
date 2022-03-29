using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnMonster : MonoBehaviour
{
    float _spawnTime;
    GameObject[] _spawnPositions;

    void Awake()
    {
        _spawnTime = .5f;
        _spawnPositions = GameObject.FindGameObjectsWithTag("Respawn");
    }

    void Start()
    {
        StartCoroutine(CreateMonster());
    }

    IEnumerator CreateMonster()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Finish");
        while (true)
        {
            foreach (GameObject go in _spawnPositions)
            {
                GameObject monster = MainManager.Game.Spawn(Define.GameObjects.Monster, "Monster", go.transform);
                monster.transform.localPosition = Vector3.zero;
                NavMeshAgent nma = monster.GetOrAddComponent<NavMeshAgent>();
                
                nma.SetDestination(target.transform.position);
            }

            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
