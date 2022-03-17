using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    protected GameObject _target;
    protected GameObject _tankTower;
    protected bool _check;
    protected float _bulletDelay;
    protected BulletController bullet;
    public override void Init()
    {
        _target = null;
        _tankTower = Util.FindChild(gameObject, "Tank_Tower");
        _check = false;
        _bulletDelay = 1f;

        MainManager.UI.MakeWorldSpaceUI<UI_HpBar>(transform);
    }

    void Update()
    {
        if (_target == null)
        {
            _target = GameObject.FindGameObjectWithTag("Enemy");
        }

        if (_target == null)
            return;

        _tankTower.transform.LookAt(_target.transform.position);

        StartCoroutine(CreateBullet(_check));
    }

    protected virtual IEnumerator CreateBullet(bool check) { yield return -1; }
}