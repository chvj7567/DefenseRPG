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
    public Dictionary<string, Data.Game> PlayerGame = new Dictionary<string, Data.Game>();
    public Dictionary<string, Data.Info> PlayerInfo = new Dictionary<string, Data.Info>();
    public Dictionary<string, Data.Stat> PlayerStat = new Dictionary<string, Data.Stat>();
    public Dictionary<string, Data.Info> MonsterInfo = new Dictionary<string, Data.Info>();
    public Dictionary<string, Data.Stat> MonsterStat = new Dictionary<string, Data.Stat>();

    public void Init()
    {
        PlayerGame = LoadJson<Data.ExtractData<Data.Game>, string, Data.Game>(Enum.GetName(typeof(Define.GameObjects), (int)Define.GameObjects.Player)).MakeDict();
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

    public void SaveData()
    {
        Data.ExtractData<Data.Game> gamePlayerData = new Data.ExtractData<Data.Game>();
        Data.ExtractData<Data.Stat> statPlayerData = new Data.ExtractData<Data.Stat>();
        Data.ExtractData<Data.Info> infoPlayerData = new Data.ExtractData<Data.Info>();
        Data.ExtractData<Data.Stat> statMonsterData = new Data.ExtractData<Data.Stat>();
        Data.ExtractData<Data.Info> infoMonsterData = new Data.ExtractData<Data.Info>();

        gamePlayerData.games = gamePlayerData.MakeList(PlayerGame);
        statPlayerData.stats = statPlayerData.MakeList(PlayerStat);
        infoPlayerData.infos = infoPlayerData.MakeList(PlayerInfo);
        gamePlayerData.stats = statPlayerData.stats;
        gamePlayerData.infos = infoPlayerData.infos;

        statMonsterData.stats = statMonsterData.MakeList(MonsterStat);
        infoMonsterData.infos = infoMonsterData.MakeList(MonsterInfo);
        statMonsterData.infos = infoMonsterData.infos;

        string json = JsonUtility.ToJson(gamePlayerData);
        string path = $"{Application.dataPath}/Resources/Data/Player.json";
        File.WriteAllText(path, json);

        json = JsonUtility.ToJson(statMonsterData);
        path = $"{Application.dataPath}/Resources/Data/Monster.json";
        File.WriteAllText(path, json);
    }
}