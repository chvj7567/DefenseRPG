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
                break;
            case Define.GameObjects.MainCamera:
                MainCamera = GameObject.Find(path).GetComponent<Camera>();
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

    public void ChangeCamera()
    {
        if (MainCamera == Camera.main)
            MainCamera = Player.GetComponentInChildren<Camera>();
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
