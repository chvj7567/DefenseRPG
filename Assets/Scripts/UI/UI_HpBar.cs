using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_HpBar : UI_Base
{
    enum GameObjects
    {
        HpBar,
    }
    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
    }

    void Update()
    {
        Transform parent = transform.parent;
        transform.position = parent.position + Vector3.up * (parent.GetComponent<Collider>().bounds.size.y);

        Vector3 dir = transform.position - Camera.main.transform.position;
        transform.forward = dir.normalized;

        transform.rotation = Camera.main.transform.rotation;
    }
}
