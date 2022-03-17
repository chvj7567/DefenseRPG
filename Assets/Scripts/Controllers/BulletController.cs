using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject Target { get; set; }
    Vector3 _direction;
    float _speed;
    Rigidbody _rb;

    private void Awake()
    {
        _speed = 10f;
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Target == null)
        {
            MainManager.Game.Despawn(gameObject);
            return;
        }

        transform.SetParent(null);
        _direction = (Target.transform.position - transform.position).normalized;
        transform.position += _direction * Time.deltaTime * _speed;
    }

    public void SetPosition(Vector3 pos)
    {
        transform.localPosition = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        MainManager.Resource.Destroy(gameObject);
    }
}
