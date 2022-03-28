using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : BaseController
{
    Camera _playerCamera;
    Rigidbody _rb;
    float _mouseSensitivity;
    float _rotationY;
    float _rotationX;
    float _limitY;

    public override void Init()
    {
        _mouseSensitivity = 3f;
        _limitY = 45f;
        _playerCamera = GetComponentInChildren<Camera>();
        _rb = gameObject.GetOrAddComponent<Rigidbody>();
        _maxSpeed = 10f;
        GameObjectType = Define.GameObjects.Player;
    }

    void Update()
    {
        Move();
        Look();
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0)
        {
            //transform.position += transform.right * _maxSpeed * horizontal * Time.deltaTime;
            //transform.Translate(Vector3.right * _maxSpeed * horizontal * Time.deltaTime);
            //_rb.position += transform.right * _maxSpeed * horizontal * Time.deltaTime;
            _rb.MovePosition(_rb.position + transform.right * _maxSpeed * horizontal * Time.deltaTime);
        }

        if (vertical != 0)
        {
            //transform.position += transform.forward * _maxSpeed * vertical * Time.deltaTime;
            //transform.Translate(Vector3.forward * _maxSpeed * vertical * Time.deltaTime);
            //_rb.position += transform.forward * _maxSpeed * vertical * Time.deltaTime;
            _rb.MovePosition(_rb.position + transform.forward * _maxSpeed * vertical * Time.deltaTime);
        }
    }
    
    void Look()
    {
        float lookY = Input.GetAxisRaw("Mouse Y");
        float lookX = Input.GetAxisRaw("Mouse X");

        _rotationX = 0f;

        _rotationY += lookY * _mouseSensitivity;
        _rotationX += lookX * _mouseSensitivity;

        _rotationY = Mathf.Clamp(_rotationY, -_limitY, _limitY);

        if (lookY != 0)
        {
            _playerCamera.transform.localEulerAngles = new Vector3(-_rotationY, 0f, 0f);
        }
        if (lookX != 0)
        {
            //transform.rotation *= Quaternion.Euler(new Vector3(0f, _rotationX, 0f));
            //transform.Rotate(new Vector3(0f, _rotationX, 0f));
            //_rb.rotation *= Quaternion.Euler(new Vector3(0f, _rotationX, 0f));
            _rb.MoveRotation(_rb.rotation * Quaternion.Euler(new Vector3(0f, _rotationX, 0f)));
        }
    }
}