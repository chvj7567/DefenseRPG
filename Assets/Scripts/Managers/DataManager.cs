using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
    enum List
    {
        Player,
        Monster,
    }

    public Dictionary<string, Data.Stat> PlayerStat = new Dictionary<string, Data.Stat>();
    public Dictionary<string, Data.Stat> MonsterStat = new Dictionary<string, Data.Stat>();

    public void init()
    {
        PlayerStat = LoadJson<Data.StatData, string, Data.Stat>(Enum.GetName(typeof(List), (int)List.Player)).MakeDict();
        MonsterStat = LoadJson<Data.StatData, string, Data.Stat>(Enum.GetName(typeof(List), (int)List.Monster)).MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = MainManager.Resource.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}