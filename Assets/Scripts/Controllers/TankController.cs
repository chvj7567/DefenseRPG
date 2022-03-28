using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : BaseController
{
    PlayerStat _playerStat;
    protected GameObject _target;
    protected LayerMask _targetMask;
    protected float _attackAngle;
    protected float _attackRange;
    protected GameObject _tankTower;
    protected bool _check;
    protected BulletController _bullet;
    IEnumerator _bulletCoroutine;
    public string TankColor { get; private set; }

    public override void Init()
    {
        _playerStat = MainManager.Game.Player.GetComponent<PlayerStat>();
        _targetMask = LayerMask.GetMask("Monster");
        _attackAngle = 90f;
        _attackRange = 10f;
        _tankTower = Util.FindChild(gameObject, "Tank_Tower");
        _check = false;
        GameObjectType = Define.GameObjects.Player;
        _bulletCoroutine = CreateBullet();
        TankColor = GetTankColor();
    }

    public string GetTankColor()
    {
        string[] tanks = Enum.GetNames(typeof(Define.Tank));

        foreach (string tank in tanks)
        {
            if (name.Contains(tank))
                return tank;
        }

        return null;
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

        if (targets.Length <= 0)
        {
            _target = null;

            if (_check)
            {
                _check = false;
                StopCoroutine(_bulletCoroutine);
            }

            return;
        }

        foreach (Collider target in targets)
        {
            Vector3 dirTarget = (target.transform.position - transform.position).normalized;

            // 시야각에 걸리는지 확인
            if (Vector3.Angle(transform.forward, dirTarget) < _attackAngle / 2)
            {
                if (_target == target.gameObject)
                    return;
            }
        }

        if (_check)
        {
            _check = false;
            _target = null;
            StopCoroutine(_bulletCoroutine);
        }

        foreach (Collider target in targets)
        {
            Vector3 dirTarget = (target.transform.position - transform.position).normalized;

            // 시야각에 걸리는지 확인
            if (Vector3.Angle(transform.forward, dirTarget) < _attackAngle / 2)
            {
                _target = target.gameObject;

                Vector3 dir = _target.transform.position - transform.position;
                _tankTower.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir.normalized), 0.5f);

                if (!_check)
                {
                    _check = true;
                    StartCoroutine(_bulletCoroutine);
                }
            }
            else
            {
                if (_target == target)
                {
                    _target = null;
                    return;
                }
            }
        }
    }

    Vector3 Angle(float angle)
    {
        angle += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0f, Mathf.Cos(angle * Mathf.Deg2Rad));
    }

    IEnumerator CreateBullet()
    {
        while (true)
        {
            _bullet = MainManager.Resource.Instantiate($"Bullet/{TankColor}Bullet", _tankTower.transform).GetOrAddComponent<BulletController>();
            _bullet.gameObject.GetOrAddComponent<PlayerStat>();
            _bullet.SetPosition(new Vector3(0f, 0.3f, 1.7f));
            _bullet.Target = _target;
            _bullet.Color = TankColor;
            Debug.Log(_playerStat.AttackSpeed);
            yield return new WaitForSeconds(_playerStat.AttackSpeed);
        }
    }
}
