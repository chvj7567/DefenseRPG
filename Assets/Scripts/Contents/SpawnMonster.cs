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
        public SpawnPosition(Vector3 position)
        {
            X = position.x; Y = position.y; Z = position.z;
        }
    }

    void Awake()
    {
        GameObject[] positions = GameObject.FindGameObjectsWithTag("Respawn");
        _spawnTime = 3f;
        _pos = new List<SpawnPosition>();
        
        foreach (GameObject go in positions)
        {
            _pos.Add(new SpawnPosition(go.transform.position));
        }
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
                GameObject monster = MainManager.Game.Spawn(Define.GameObjects.Monster, "Mummy");
                monster.transform.position = new Vector3(pos.X, pos.Y, pos.Z);
            }

            yield return new WaitForSeconds(_spawnTime);
        }
    }
}
