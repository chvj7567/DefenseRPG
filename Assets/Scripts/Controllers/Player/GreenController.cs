using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenController : PlayerController
{
    string[] _enemys = Enum.GetNames(typeof(Define.Enemys));

    protected override IEnumerator CreateBullet()
    {
        _check = true;
        bullet = MainManager.Resource.Instantiate("Bullet/GreenBullet", _tankTower.transform).GetOrAddComponent<BulletController>();
        bullet.gameObject.GetOrAddComponent<GreenStat>();
        bullet.SetPosition(new Vector3(0f, 0.3f, 1.7f));
        bullet.Target = _target;

        yield return new WaitForSeconds(_bulletDelay);

        _check = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (string name in _enemys)
        {
            if (collision.collider.name == name)
            {
                GetComponent<GreenStat>().OnDamage(collision.gameObject.GetComponent<MonsterStat>());
            }
        }
    }
}