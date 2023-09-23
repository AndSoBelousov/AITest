using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    private CustomInput _customInput;
    private Vector3 _moveVector = Vector3.zero;
    private Rigidbody _rb;
    private float _moveSpeed = 10f;

    public float _rotationSpeed = 5.0f; // Скорость вращения камеры

    private bool _isRotating = false; // Флаг, указывающий, включено ли вращение
    private Vector2 _mouseDelta; // Дельта позиции мыши



    private Camera _camera;

    private void Awake()
    {
        _customInput = new();
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _moveVector * _moveSpeed;
        RotateCharacter();
    }

    private void OnEnable()
    {
        _customInput.Enable();
        _customInput.CamActionMap.Movement.performed += OnMovementPerformed;
        _customInput.CamActionMap.Movement.canceled += OnMovementCancelled;
        _customInput.CamActionMap.Mouse.performed += OnMouseRotate;
        _customInput.CamActionMap.Mouse.canceled += OnMouseRotateCancel;
        
    }

    private void OnDisable()
    {
        _customInput.Disable();
        _customInput.CamActionMap.Movement.performed -= OnMovementPerformed;
        _customInput.CamActionMap.Movement.canceled -= OnMovementCancelled;
        _customInput.CamActionMap.Mouse.performed += OnMouseRotate;
        _customInput.CamActionMap.Mouse.canceled += OnMouseRotateCancel;
        
    }

    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
        _moveVector = context.ReadValue<Vector3>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext context)
    {
        _moveVector = Vector3.zero;
    }
    private void OnMouseRotate(InputAction.CallbackContext context)
    {
        if (Mouse.current.rightButton.isPressed)
        {
            _isRotating = true;
            _mouseDelta = context.ReadValue<Vector2>();
        }
    }

    private void OnMouseRotateCancel(InputAction.CallbackContext context)
    {
        _isRotating = false;
    }

    private void RotateCharacter()
    {
        // Если включено вращение
        if (_isRotating)
        {
            // Вычисляем угол поворота камеры на основе дельты позиции мыши
            float rotationX = _mouseDelta.x * _rotationSpeed;
            float rotationY = -_mouseDelta.y * _rotationSpeed;

            // Вращаем камеру вокруг своих осей, исключая вращение по оси Z
            //transform.rotation *= Quaternion.Euler(Vector3.up * rotationX);
            //transform.rotation *= Quaternion.Euler(Vector3.right * rotationY);
            // Вращаем камеру вокруг своих осей
            //transform.Rotate(Vector3.up * rotationX);
            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
    }
}
