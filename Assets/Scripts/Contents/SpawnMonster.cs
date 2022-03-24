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
        while (true)
        {
            foreach (GameObject go in _spawnPositions)
            {
                MainManager.Game.Spawn(Define.GameObjects.Monster, "Monster", go.transform);
            }

            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
