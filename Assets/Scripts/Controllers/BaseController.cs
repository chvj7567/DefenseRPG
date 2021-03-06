using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    public Define.GameObjects GameObjectType { get; protected set; } = Define.GameObjects.Unknown;

    void Start()
    {
        Init();
    }
    
    public abstract void Init();
}
