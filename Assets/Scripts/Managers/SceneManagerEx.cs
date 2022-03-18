using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    public BaseScene CurrentScene { get { return GameObject.FindObjectOfType<BaseScene>(); } }

    public void LoadScene(Define.Scenes type)
    {
        SceneManager.LoadScene(GetSceneName(type));
    }

    public string GetSceneName(Define.Scenes type)
    {
        string name = Enum.GetName(typeof(Define.Scenes), type);
        return name;
    }

    public void Clear()
    {
        
    }
}
