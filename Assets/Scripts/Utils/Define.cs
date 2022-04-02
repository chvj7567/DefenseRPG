using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum Tank
    {
        Green,
        Yellow,
        Blue,
        Red,
    }

    public enum Scenes
    {
        Unknown,
        Lobby,
        Game,
    }

    public enum GameObjects
    {
        Unknown,
        Background,
        Map,
        Monster,
        Player,
        Tank,
        MainCamera,
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
        Skill,
        Stage,
    }

    public enum UIEvent
    {
        Update,
        Click,
        Down,
        Up,
        BeginDrag,
        Drag,
        EndDrag,
        Drop,
    }

    public enum Audio
    {
        Bgm,
        Effect,
        MaxCount,
    }

    public enum AreaSkill
    {
        Snow,
        Laser,
        MaxCount
    }

    public enum BuffSkill
    {
        Strong,
        FastAttack,
        MaxCount
    }
}
