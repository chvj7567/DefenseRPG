using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    float _spawnTime;
    List<SpawnPosition> _pos;
    class SpawnPosition
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }
        public SpawnPosition(float x, float y, float z)
        {
            X = x; Y = y; Z = z;
        }
    }

    void Awake()
    {
        _spawnTime = 3f;
        _pos = new List<SpawnPosition>();
        _pos.Add(new SpawnPosition(-10f, 1f, 10f));
    }

    void Start()
    {
        StartCoroutine(CreateMonster());
    }

    IEnumerator CreateMonster()
    {
        while (true)
        {
            foreach (SpawnPosition pos in _pos)
            {
                GameObject monster = MainManager.Game.Spawn(Define.GameObjects.Monster, "Monster");
                monster.transform.position = new Vector3(pos.X, pos.Y, pos.Z);
            }

            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
