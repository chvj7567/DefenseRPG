using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
    List<Data.Stat> MakeList(Dictionary<string, Data.Stat> dict);
}

public class DataManager
{
    public Dictionary<string, Data.Stat> PlayerStat = new Dictionary<string, Data.Stat>();
    public Dictionary<string, Data.Stat> MonsterStat = new Dictionary<string, Data.Stat>();

    public void Init()
    {
        PlayerStat = LoadJson<Data.StatData, string, Data.Stat>(Enum.GetName(typeof(Define.GameObjects), (int)Define.GameObjects.Player)).MakeDict();
        MonsterStat = LoadJson<Data.StatData, string, Data.Stat>(Enum.GetName(typeof(Define.GameObjects), (int)Define.GameObjects.Monster)).MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = MainManager.Resource.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }

    public void ChangeLevel()
    {
        Data.StatData statData = new Data.StatData();
        statData.stats = statData.MakeList(PlayerStat);

        string json = JsonUtility.ToJson(statData);
        string path = $"{Application.dataPath}/Resources/Data/Player.json";
        File.WriteAllText(path, json);

        Init();
    }
}