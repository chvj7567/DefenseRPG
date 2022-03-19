using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HpBar : UI_Base
{
    Slider _hpBar;
    enum GameObjects
    {
        HpBar,
    }

    BaseStat _stat;
    public override void Init()
    {
        Bind<Slider>(typeof(GameObjects));
        _hpBar = Get<Slider>((int)GameObjects.HpBar);
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
        _hpBar.value = ratio;
    }
}