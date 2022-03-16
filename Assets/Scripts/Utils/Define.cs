using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
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
