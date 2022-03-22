using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    public override void Init()
    {
        _maxSpeed = 10f;
        _rb.GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if (horizontal != 0)
            transform.Translate(Vector3.forward * _maxSpeed * horizontal * Time.deltaTime);

        if (vertical != 0)
            transform.Translate(Vector3.right * _maxSpeed * vertical * Time.deltaTime);
    }
}