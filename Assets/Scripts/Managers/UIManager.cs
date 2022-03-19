using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    public GameObject Start { get; private set; }
    public GameObject Setting { get; private set; }
    public GameObject How { get; private set; }
    public GameObject Move { get; private set; }
    public GameObject MiniMap { get; private set; }
    public GameObject Score { get; private set; }
    public GameObject End { get; private set; }
    public GameObject Loading { get; private set; }
    public GameObject Game { get; private set; }
    public GameObject Research { get; private set; }
    public GameObject Gold { get; private set; }
    public GameObject Crystal { get; private set; }
    public GameObject Inventory { get; private set; }

    public GameObject CurrentSubUI { get; set; }

    int _order = 1;
    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");

            if (root == null)
            {
                root = new GameObject { name = "@UI_Root" };

            }
            return root;
        }
    }

    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        canvas.worldCamera = Camera.main;
        canvas.overrideSorting = true;

        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
        {
            canvas.sortingOrder = 0;

        }
    }

    public T MakeWorldSpaceUI<T>(Transform parent) where T : UI_Base
    {
        GameObject go = MainManager.Resource.Instantiate($"UI/WorldSpace/{typeof(T).Name}");

        go.transform.SetParent(parent);

        Canvas canvas = go.GetOrAddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.worldCamera = Camera.main;

        return go.GetOrAddComponent<T>();
    }

    public GameObject ShowUI(string name, Define.UI type)
    {
        GameObject go = null;

        switch (type)
        {
            case Define.UI.Start:
                if (Start != null)
                {
                    Start.SetActive(true);
                    return Start;
                }
                Start = go = MainManager.Resource.Instantiate($"UI/{name}");
                break;
            case Define.UI.Setting:
                if (Setting != null)
                {
                    Setting.SetActive(true);
                    return Setting;
                }
                Setting = go = MainManager.Resource.Instantiate($"UI/{name}");
                break;
            case Define.UI.How:
                if (How != null)
                {
                    How.SetActive(true);
                    return How;
                }
                How = go = MainManager.Resource.Instantiate($"UI/{name}");
                break;
            case Define.UI.Move:
                if (Move != null)
                {
                    Move.SetActive(true);
                    return Move;
                }
                Move = go = MainManager.Resource.Instantiate($"UI/{name}");
                break;
            case Define.UI.MiniMap:
                if (MiniMap != null)
                {
                    MiniMap.SetActive(true);
                    return MiniMap;
                }
                MiniMap = go = MainManager.Resource.Instantiate($"UI/{name}");
                break;
            case Define.UI.Score:
                if (Score != null)
                {
                    Score.SetActive(true);
                    return Score;
                }
                Score = go = MainManager.Resource.Instantiate($"UI/{name}");
                break;
            case Define.UI.End:
                if (End != null)
                {
                    End.SetActive(true);
                    return End;
                }
                End = go = MainManager.Resource.Instantiate($"UI/{name}");
                break;
            case Define.UI.Loading:
                if (Loading != null)
                {
                    Loading.SetActive(true);
                    return Loading;
                }
                Loading = go = MainManager.Resource.Instantiate($"UI/{name}");
                break;
            case Define.UI.Game:
                if (Game != null)
                {
                    Loading.SetActive(true);
                    return Game;
                }
                Game = go = MainManager.Resource.Instantiate($"UI/{name}");
                break;
            case Define.UI.Research:
                if (Research != null)
                {
                    Research.SetActive(true);
                    return Research;
                }
                Research = go = MainManager.Resource.Instantiate($"UI/{name}");
                break;
            case Define.UI.Gold:
                if (Gold != null)
                {
                    Gold.SetActive(true);
                    return Gold;
                }
                Gold = go = MainManager.Resource.Instantiate($"UI/{name}");
                break;
            case Define.UI.Crystal:
                if (Crystal != null)
                {
                    Crystal.SetActive(true);
                    return Crystal;
                }
                Crystal = go = MainManager.Resource.Instantiate($"UI/{name}");
                break;
            case Define.UI.Inventory:
                if (Inventory != null)
                {
                    Inventory.SetActive(true);
                    return Inventory;
                }
                Inventory = go = MainManager.Resource.Instantiate($"UI/{name}");
                break;
        }

        go.transform.SetParent(Root.transform);
        SetCanvas(go);

        return go;
    }

    public void HideUI(GameObject ui)
    {
        if (ui != null)
            ui.SetActive(false);
    }
}