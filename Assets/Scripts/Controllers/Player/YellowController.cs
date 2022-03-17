using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowController : PlayerController
{
    protected override IEnumerator CreateBullet(bool check)
    {
        if (!check)
        {
            _check = true;
            bullet = MainManager.Resource.Instantiate("Bullet/YellowBullet", _tankTower.transform).GetOrAddComponent<BulletController>();
            bullet.gameObject.GetOrAddComponent<YellowStat>();
            bullet.SetPosition(new Vector3(0f, 0.3f, 1.7f));
            bullet.Target = _target;

            yield return new WaitForSeconds(_bulletDelay);

            _check = false;
        }
    }
}
