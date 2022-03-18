using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    protected float _maxSpeed;
    protected Rigidbody _rb;
    protected Define.State _state;

    public Define.GameObjects GameObjectType { get; protected set; } = Define.GameObjects.Unknown;

    void Start()
    {
        Init();
        MainManager.UI.MakeWorldSpaceUI<UI_HpBar>(transform);
    }

    void FixedUpdate()
    {
        Run();
    }

    public abstract void Init();
    protected virtual void UpdateIdle() { }
    protected virtual void UpdateRun() { }
    protected virtual void Run() { }
    protected virtual void UpdateJump() { }
    protected virtual void UpdateDie() { }
}
