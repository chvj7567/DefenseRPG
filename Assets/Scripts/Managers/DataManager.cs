using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
    List<Value> MakeList(Dictionary<Key, Value> dict);
}

public class DataManager
{
    public Dictionary<string, Data.Info> StageInfo = new Dictionary<string, Data.Info>();
    public Dictionary<string, Data.Info> PlayerInfo = new Dictionary<string, Data.Info>();
    public Dictionary<string, Data.Stat> PlayerStat = new Dictionary<string, Data.Stat>();
    public Dictionary<string, Data.Info> MonsterInfo = new Dictionary<string, Data.Info>();
    public Dictionary<string, Data.Stat> MonsterStat = new Dictionary<string, Data.Stat>();

    public void Init()
    {
        StageInfo = LoadJson<Data.ExtractData<Data.Info>, string, Data.Info>("Stage").MakeDict();
        PlayerInfo = LoadJson<Data.ExtractData<Data.Info>, string, Data.Info>(Enum.GetName(typeof(Define.GameObjects), (int)Define.GameObjects.Player)).MakeDict();
        PlayerStat = LoadJson<Data.ExtractData<Data.Stat>, string, Data.Stat>(Enum.GetName(typeof(Define.GameObjects), (int)Define.GameObjects.Player)).MakeDict();
        MonsterInfo = LoadJson<Data.ExtractData<Data.Info>, string, Data.Info>(Enum.GetName(typeof(Define.GameObjects), (int)Define.GameObjects.Monster)).MakeDict();
        MonsterStat = LoadJson<Data.ExtractData<Data.Stat>, string, Data.Stat>(Enum.GetName(typeof(Define.GameObjects), (int)Define.GameObjects.Monster)).MakeDict();
    }

    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = MainManager.Resource.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }

    /*public void ChangeLevel()
    {
        Data.ExtractData statData = new Data.ExtractData();
        statData.stats = statData.MakeList(PlayerStat);
        string json = JsonUtility.ToJson(statData);
        string path = $"{Application.dataPath}/Resources/Data/Player.json";
        File.WriteAllText(path, json);

        Init();
    }*/
}