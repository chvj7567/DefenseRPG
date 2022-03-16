using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager
{
    public GameObject Background { get; private set; }
    public GameObject Map { get; private set; }
    public GameObject Player { get; private set; }
    public GameObject MiniMapCamera { get; private set; }

    public bool IsGamimg { get; private set; }

    GameObject Spawning;

    int _sortOrder = 0;

    public GameObject Spawn(Define.GameObjects type, string path, Transform parent = null)
    {
        GameObject go = MainManager.Resource.Instantiate(path, parent);

        if (go == null)
            return null;

        switch (type)
        {
            case Define.GameObjects.Background:
                if (Background != null)
                    return Background;
                Background = go;
                go.GetComponent<SpriteRenderer>().sortingOrder = _sortOrder++;
                break;
            case Define.GameObjects.Map:
                Map = go;
                go.GetComponentInChildren<TilemapRenderer>().sortingOrder = _sortOrder;
                break;
            case Define.GameObjects.Monster:
                Util.FindChild(go, "Square").GetComponent<SpriteRenderer>().sortingOrder = go.GetComponent<SpriteRenderer>().sortingOrder = _sortOrder++;
                break;
            case Define.GameObjects.Player:
                Player = go;
                Util.FindChild(go, "Square").GetComponent<SpriteRenderer>().sortingOrder = go.GetComponent<SpriteRenderer>().sortingOrder = _sortOrder++;
                break;
            case Define.GameObjects.MiniMapCamera:
                MiniMapCamera = go;
                break;
        }

        return go;
    }

    public void Despawn(GameObject go)
    {
        MainManager.Resource.Destroy(go);
    }

    public void Despawn(Define.GameObjects type, GameObject go)
    {
        switch (type)
        {
            case Define.GameObjects.Background:
                Background = null;
                break;
            case Define.GameObjects.Player:
                Player = null;
                break;
            case Define.GameObjects.Map:
                Map = null;
                break;
            case Define.GameObjects.MiniMapCamera:
                MiniMapCamera = null;
                break;
        }

        MainManager.Resource.Destroy(go);
    }

    public void StartGame()
    {
        IsGamimg = true;
        MainManager.Game.Spawn(Define.GameObjects.Map, "Map");
        MainManager.Game.Spawn(Define.GameObjects.MiniMapCamera, "MiniMapCamera");
        MainManager.Game.Spawn(Define.GameObjects.Player, "Player");

        Spawning = new GameObject("@SpawnMonster");
        Util.GetOrAddComponent<SpawnMonster>(Spawning);

        MainManager.UI.ShowUI("MiniMapUI", Define.UI.MiniMap);
        MainManager.UI.ShowUI("ScoreUI", Define.UI.Score);
    }

    public void EndGame()
    {
        IsGamimg = false;
        Despawn(Define.GameObjects.Map, Map);
        Despawn(Define.GameObjects.MiniMapCamera, MiniMapCamera);
        Despawn(Define.GameObjects.Player, Player);
        Despawn(Spawning);
        Spawning = null;

        MainManager.UI.HideUI(MainManager.UI.MiniMap, Define.UI.MiniMap);
        MainManager.UI.HideUI(MainManager.UI.Move, Define.UI.Move);
        //MainManager.UI.HideUI(MainManager.UI.Score, Define.UI.Score);
        MainManager.UI.ShowUI("EndUI", Define.UI.End);
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
