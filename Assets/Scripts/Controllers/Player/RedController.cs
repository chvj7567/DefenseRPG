using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedController : PlayerController
{
    protected override IEnumerator CreateBullet()
    {
        _check = true;
        bullet = MainManager.Resource.Instantiate("Bullet/RedBullet", _tankTower.transform).GetOrAddComponent<BulletController>();
        bullet.gameObject.GetOrAddComponent<RedStat>();
        bullet.SetPosition(new Vector3(0f, 0.3f, 1.7f));
        bullet.Target = _target;

        yield return new WaitForSeconds(_bulletDelay);

        _check = false;
    }
}
