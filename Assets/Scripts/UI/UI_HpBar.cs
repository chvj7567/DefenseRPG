using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HpBar : UI_Base
{
    enum GameObjects
    {
        HpBar,
    }

    BaseStat _stat;
    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        _stat = transform.parent.GetComponent<BaseStat>();
    }

    void Update()
    {
        Transform parent = transform.parent;
        transform.position = parent.position + Vector3.up * (parent.GetComponent<Collider>().bounds.size.y);

        Vector3 dir = transform.position - Camera.main.transform.position;
        transform.forward = dir.normalized;

        transform.rotation = Camera.main.transform.rotation;

        float ratio = _stat.Hp / (float) _stat.MaxHp;
        SetHp(ratio);
    }

    public void SetHp(float ratio)
    {
        GetObject((int)GameObjects.HpBar).GetComponent<Slider>().value = ratio;
    }
}