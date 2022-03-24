using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour
{
    public Define.Scenes SceneType { get; protected set; } = Define.Scenes.Unknown;
    public GameObject Sun { get; private set; }

    void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        Object obj = FindObjectOfType(typeof(EventSystem));
        if (obj == null)
            MainManager.Resource.Instantiate("EventSystem").name = "@EventSystem";
        MainManager.Game.Spawn(Define.GameObjects.MainCamera, "Main Camera");
        Sun = GameObject.Find("Directional Light");
    }

    public abstract void Clear();
}