using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : BaseController
{
    protected GameObject _target;
    protected LayerMask _targetMask;
    protected float _attackAngle;
    protected float _attackRange;
    protected GameObject _tankTower;
    protected bool _check;
    protected float _bulletDelay;
    protected BulletController bullet;

    public override void Init()
    {
        _targetMask = LayerMask.GetMask("Monster");
        _attackAngle = 90f;
        _attackRange = 10f;
        _tankTower = Util.FindChild(gameObject, "Tank_Tower");
        _check = false;
        _bulletDelay = 1f;
        GameObjectType = Define.GameObjects.Player;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }

    void Update()
    {
        AttackAble();
    }

    void AttackAble()
    {
        // 시야각의 경계선
        Vector3 left = Angle(-_attackAngle * 0.5f);
        Vector3 right = Angle(_attackAngle * 0.5f);

        Debug.DrawRay(transform.position, left * _attackRange, Color.green);
        Debug.DrawRay(transform.position, right * _attackRange, Color.green);

        // 범위에 걸린 타겟들
        Collider[] targets = Physics.OverlapSphere(transform.position, _attackRange, _targetMask);

        if (_target == null || !_target.activeSelf)
        {
            if (targets.Length > 0)
                _target = targets[0].gameObject;
            else
                _target = null;
        }

        if (_target == null)
            return;

        Vector3 dirTarget = (_target.transform.position - transform.position).normalized;

        // 시야각에 걸리는지 확인
        if (Vector3.Angle(transform.forward, dirTarget) < _attackAngle / 2)
        {
            Vector3 dir = _target.transform.position - transform.position;
            _tankTower.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir.normalized), 0.5f);

            if (!_check)
                StartCoroutine(CreateBullet());
        }
    }

    Vector3 Angle(float angle)
    {
        angle += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0f, Mathf.Cos(angle * Mathf.Deg2Rad));
    }


    protected virtual IEnumerator CreateBullet() { yield return null; }
}
