using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    private CustomInput _customInput;
    private Vector3 _moveVector = Vector3.zero;
    private Rigidbody _rb;
    private float _moveSpeed = 10f;

    public float _sensitivity = 5.0f; // Скорость вращения камеры
    private bool _isRotating = false; // Флаг, указывающий, включено ли вращение
    private Vector2 _mouseDelta; // Дельта позиции мыши
    public float _maxYAngle = 80.0f;  // Максимальный угол наклона вверх и вниз
    private float rotationX = 0;

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
        _mouseDelta = context.ReadValue<Vector2>();
        

        if (Mouse.current.rightButton.isPressed)
        {
            _isRotating = true;
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

            transform.Rotate(Vector3.up * _mouseDelta.x * _sensitivity);

            // Вычисляем угол наклона камеры по вертикали
            rotationX -= _mouseDelta.y * _sensitivity;
            rotationX = Mathf.Clamp(rotationX, -_maxYAngle, _maxYAngle);

            // Поворачиваем камеру по вертикали вокруг оси X
            transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        }
    }
}
