using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : BaseController
{
    PlayerStat _playerStat;
    Transform _target;
    LayerMask _targetMask;
    float _attackAngle;
    float _attackRange;
    GameObject _tankTower;
    float _tankTowerSpeed;
    BulletController _bullet;
    bool _bulletCoroutineCheck;

    public string TankColor { get; private set; }
    public override void Init()
    {
        _playerStat = MainManager.Game.Player.GetComponent<PlayerStat>();
        _targetMask = LayerMask.GetMask("Monster");
        _attackAngle = 90f;
        _attackRange = 10f;
        _tankTower = Util.FindChild(gameObject, "Tank_Tower");
        _tankTowerSpeed = 3f;
        _bulletCoroutineCheck = false;
        GameObjectType = Define.GameObjects.Player;
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
        Attack();
    }

    Vector3 Angle(float angle)
    {
        angle += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0f, Mathf.Cos(angle * Mathf.Deg2Rad));
    }

    Transform SearchTarget()
    {
        Transform mainTarget = null;

        // 범위에 걸린 타겟들
        Collider[] targets = Physics.OverlapSphere(transform.position, _attackRange, _targetMask);

        if (targets.Length > 0)
        {
            float minDistance = Mathf.Infinity;

            foreach (Collider target in targets)
            {
                Vector3 direction = target.transform.position - transform.position;

                // 시야각에 걸리는지 확인
                if (Vector3.Angle(transform.forward, direction.normalized) < _attackAngle / 2)
                {
                    float distance = direction.magnitude;
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        mainTarget = target.transform;
                    }
                }
            }
        }

        return mainTarget;
    }

    bool IsAttackRange(Transform target)
    {
        if (target == null || !target.gameObject.activeSelf)
            return false;

        Vector3 direction = target.position - transform.position;
        if (direction.magnitude > _attackRange)
            return false;
        if (Vector3.Angle(transform.forward, direction.normalized) >= _attackAngle / 2)
            return false;
        return true;
    }

    void Attack()
    {
        // 시야각의 경계선
        Vector3 left = Angle(-_attackAngle * 0.5f);
        Vector3 right = Angle(_attackAngle * 0.5f);

        Debug.DrawRay(transform.position, left * _attackRange, Color.green);
        Debug.DrawRay(transform.position, right * _attackRange, Color.green);

        if (_target == null)
        {
            _target = SearchTarget();
            _tankTower.transform.rotation = Quaternion.Lerp(_tankTower.transform.rotation, Quaternion.LookRotation(transform.forward - transform.position), _tankTowerSpeed * Time.deltaTime);
        }
        else
        {
            Debug.DrawRay(transform.position, _target.transform.position - transform.position, Color.red);
            _tankTower.transform.rotation = Quaternion.Lerp(_tankTower.transform.rotation, Quaternion.LookRotation(_target.position - transform.position), _tankTowerSpeed * Time.deltaTime);
        }

        if (!IsAttackRange(_target))
        {
            _target = null;
        }
        else
        {
            if (!_bulletCoroutineCheck)
                StartCoroutine(CreateBullet());
        }
    }

    

    IEnumerator CreateBullet()
    {
        _bulletCoroutineCheck = true;
        _bullet = MainManager.Resource.Instantiate($"Bullet/{TankColor}Bullet", _tankTower.transform).GetOrAddComponent<BulletController>();
        _bullet.gameObject.GetOrAddComponent<PlayerStat>();
        _bullet.SetPosition(new Vector3(0f, 0.3f, 1.7f));
        _bullet.Target = _target.gameObject;
        _bullet.Color = TankColor;
        yield return new WaitForSeconds(_playerStat.AttackSpeed);
        _bulletCoroutineCheck = false;
    }
}
