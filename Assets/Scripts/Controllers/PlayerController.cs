using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    [SerializeField]
    float _mouseSensitivity;
    [SerializeField]
    float _cameraUpdownLimit;

    Camera _playerCamera;
    Rigidbody _rb;
    float _currentCameraRotationX;
    
    public override void Init()
    {
        _mouseSensitivity = 3f;
        _cameraUpdownLimit = 90f;
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
            transform.Translate(Vector3.right * _maxSpeed * horizontal * Time.deltaTime);
        if (vertical != 0)
            transform.Translate(Vector3.forward * _maxSpeed * vertical * Time.deltaTime);
    }

    void Look()
    {
        float upDown = Input.GetAxisRaw("Mouse Y");
        float leftRight = Input.GetAxisRaw("Mouse X");

        if (upDown != 0)
        {
            float _cameraUpdownX = 0f;
            _cameraUpdownX = upDown * _mouseSensitivity;
            _currentCameraRotationX -= _cameraUpdownX;
            _currentCameraRotationX = Mathf.Clamp(_currentCameraRotationX, -_cameraUpdownLimit, _cameraUpdownLimit);
            _playerCamera.transform.localEulerAngles = new Vector3(_currentCameraRotationX, 0f, 0f);
        }
        if (leftRight != 0)
        {
            float playerLeftRightY = 0f;
            playerLeftRightY += leftRight * _mouseSensitivity;
            _rb.MoveRotation(_rb.rotation * Quaternion.Euler(new Vector3(0f, playerLeftRightY, 0f)));
        }
    }
}