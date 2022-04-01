using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : BaseController
{
    public GameObject Target { get; set; }
    public string Color { get; set; }
    Vector3 _direction;
    float _speed;

    public override void Init()
    {
        _speed = 10f;
    }

    void Update()
    {
        if (Target == null || !Target.activeSelf)
        {
            Target = null;
            MainManager.Game.Despawn(gameObject);
            return;
        }

        _direction = (Target.transform.position + Vector3.up - transform.position).normalized;
        transform.position += _direction * Time.unscaledDeltaTime * _speed;
    }

    public void SetPosition(Vector3 pos)
    {
        transform.localPosition = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Monster"))
            MainManager.Game.Despawn(gameObject);
    }
}
