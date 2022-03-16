using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    GameObject _target;
    GameObject _tankTower;
    bool _check;
    float _bulletDelay;

    public override void Init()
    {
        _target = null;
        _tankTower = Util.FindChild(gameObject, "Tank_Tower");
        _check = false;
        _bulletDelay = 1f;
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

    IEnumerator CreateBullet(bool check)
    {
        if (!check)
        {
            _check = true;
            BulletController bullet = MainManager.Resource.Instantiate("Bullet", _tankTower.transform).GetOrAddComponent<BulletController>();

            bullet.SetPosition(new Vector3(0f, 0.3f, 1.7f));
            bullet.Target = _target;
            //bullet.Shoot();
            yield return new WaitForSeconds(_bulletDelay);

            _check = false;
        }
    }
}