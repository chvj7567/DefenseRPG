using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTank : MonoBehaviour
{
    PlayerStat _playerStat;
    Transform[] _greenSpawnPositions, _yellowSpawnPositions, _blueSpawnPositions, _redSpawnPositiones;

    void Awake()
    {
        Transform tankSpawn = null;
        for (int i = 0; i < MainManager.Game.Map.transform.childCount; i++)
        {
            tankSpawn = MainManager.Game.Map.transform.GetChild(i);
            if (tankSpawn.name == "TankSpawn")
                break;
        }

        if (tankSpawn == null)
            Debug.Log("TankSpawn Missing");

        Transform green = tankSpawn.GetChild(0);
        _greenSpawnPositions = green.GetComponentsInChildren<Transform>();

        Transform yellow = tankSpawn.GetChild(1);
        _yellowSpawnPositions = yellow.GetComponentsInChildren<Transform>();

        Transform blue = tankSpawn.GetChild(2);
        _blueSpawnPositions = blue.GetComponentsInChildren<Transform>();

        Transform red = tankSpawn.GetChild(3);
        _redSpawnPositiones = red.GetComponentsInChildren<Transform>();
    }

    public void CreateTank(Define.Tank type, int num)
    {
        switch (type)
        {
            case Define.Tank.Green:
                MainManager.Game.Spawn(Define.GameObjects.Tank, "Tank_Green", _greenSpawnPositions[num].transform).transform.localPosition = Vector3.zero;
                break;
            case Define.Tank.Yellow:
                MainManager.Game.Spawn(Define.GameObjects.Tank, "Tank_Yellow", _yellowSpawnPositions[num].transform).transform.localPosition = Vector3.zero;
                break;
            case Define.Tank.Blue:
                MainManager.Game.Spawn(Define.GameObjects.Tank, "Tank_Blue", _blueSpawnPositions[num].transform).transform.localPosition = Vector3.zero;
                break;
            case Define.Tank.Red:
                MainManager.Game.Spawn(Define.GameObjects.Tank, "Tank_Red", _redSpawnPositiones[num].transform).transform.localPosition = Vector3.zero;
                break;
        }
    }

    public void CreateAllTank()
    {
        _playerStat = MainManager.Game.Player.GetComponent<PlayerStat>();
        int green = _playerStat.GreenTank;
        int yellow = _playerStat.YellowTank;
        int blue = _playerStat.BlueTank;
        int red = _playerStat.RedTank;

        for (int i = 1; i <= green; i++)
        {
            MainManager.Game.Spawn(Define.GameObjects.Tank, "Tank_Green", _greenSpawnPositions[i].transform).transform.localPosition = Vector3.zero;
        }

        for (int i = 1; i <= yellow; i++)
        {
            MainManager.Game.Spawn(Define.GameObjects.Tank, "Tank_Yellow", _yellowSpawnPositions[i].transform).transform.localPosition = Vector3.zero;
        }

        for (int i = 1; i <= blue; i++)
        {
            MainManager.Game.Spawn(Define.GameObjects.Tank, "Tank_Blue", _blueSpawnPositions[i].transform).transform.localPosition = Vector3.zero;
        }

        for (int i = 1; i <= red; i++)
        {
            MainManager.Game.Spawn(Define.GameObjects.Tank, "Tank_Red", _redSpawnPositiones[i].transform).transform.localPosition = Vector3.zero;
        }
    }
}
