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
    }

    void Update()
    {
        _target = GameObject.FindGameObjectWithTag("Enemy");
        if (_target == null)
            return;

        _tankTower.transform.LookAt(_target.transform.position);

        if (!_check)
            StartCoroutine(CreateBullet());
    }

    protected virtual IEnumerator CreateBullet() { yield return null; }
}