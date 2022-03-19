using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum Scenes
    {
        Unknown,
        Lobby,
        Game,
    }
    public enum Players
    {
        Tank_Green,
        Tank_Yellow,
        Tank_Blue,
        Tank_Red
    }

    public enum Enemys
    {
        Mummy,
    }
    public enum GameObjects
    {
        Unknown,
        Background,
        Map,
        Monster,
        Player,
        MiniMapCamera,
    }
    public enum State
    {
        Idle,
        Run,
        Jump,
        Die,
    }

    public enum UI
    {
        Start,
        Setting,
        How,
        Move,
        MiniMap,
        Score,
        End,
        Loading,
        Game,
        Research,
        Gold,
        Crystal,
        Inventory,
    }

    public enum UIEvent
    {
        Update,
        Click,
        Down,
        Up,
    }

    public enum Audio
    {
        Bgm,
        Shoot,
        Die,
        MaxCount,
    }
}
