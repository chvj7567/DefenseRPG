using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager
{
    public GameObject Background { get; private set; }
    public GameObject Map { get; private set; }
    public GameObject Player { get; private set; }
    public HashSet<GameObject> Tank { get; private set; } = new HashSet<GameObject>();
    public Camera MainCamera { get; private set; }

    public bool IsGamimg { get; private set; }

    public int GreenNum { get; private set; }
    public int YellowNum { get; private set; }
    public int BlueNum { get; private set; }
    public int RedNum { get; private set; }

    public GameObject Spawn(Define.GameObjects type, string path, Transform parent = null)
    {
        GameObject go = null;

        switch (type)
        {
            case Define.GameObjects.Background:
                Background = go = MainManager.Resource.Instantiate(path, parent);
                break;
            case Define.GameObjects.Map:
                Map = go = MainManager.Resource.Instantiate($"Map/{path}", parent);
                break;
            case Define.GameObjects.Monster:
                go = MainManager.Resource.Instantiate($"Monster/{path}", parent);
                break; 
            case Define.GameObjects.Player:
                Player = go = MainManager.Resource.Instantiate(path, parent);
                break;
            case Define.GameObjects.Tank:
                go = MainManager.Resource.Instantiate($"Tank/{path}", parent);
                Tank.Add(go);
                if (go.name.Contains(Enum.GetName(typeof(Define.Tank), (int)Define.Tank.Green)))
                    GreenNum += 1;
                else if (go.name.Contains(Enum.GetName(typeof(Define.Tank), (int)Define.Tank.Yellow)))
                    YellowNum += 1;
                else if (go.name.Contains(Enum.GetName(typeof(Define.Tank), (int)Define.Tank.Blue)))
                    BlueNum += 1;
                else if (go.name.Contains(Enum.GetName(typeof(Define.Tank), (int)Define.Tank.Red)))
                    RedNum += 1;
                break;
            case Define.GameObjects.MainCamera:
                go = GameObject.Find(path);
                MainCamera = go.GetComponentInChildren<Camera>();
                break;
        }

        return go;
    }

    public Define.GameObjects GetWorldObjectType(GameObject go)
    {
        BaseController bc = go.GetComponent<BaseController>();
        if (bc == null)
            return Define.GameObjects.Unknown;

        return bc.GameObjectType;
    }

    public void Despawn(GameObject go)
    {
        Define.GameObjects type = GetWorldObjectType(go);

        switch (type)
        {
            case Define.GameObjects.Background:
                Background = null;
                break;
            case Define.GameObjects.Map:
                Map = null;
                break;
            case Define.GameObjects.Player:
                Player = null;
                break;
            case Define.GameObjects.Tank:
                Tank.Remove(go);
                break;
        }

        MainManager.Resource.Destroy(go);
    }

    public void ChangeCamera(Camera camera)
    {
        MainCamera.enabled = false;
        camera.enabled = true;
        MainCamera = camera;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
