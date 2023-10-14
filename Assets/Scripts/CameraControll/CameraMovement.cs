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
    [SerializeField]
    public float _sensitivity = 70.0f; // Скорость вращения камеры
    private bool _isRotating = false; // Флаг, указывающий, включено ли вращение
    private Vector2 _mouseDelta; // Дельта позиции мыши
    public float _maxYAngle = 80.0f;  // Максимальный угол наклона вверх и вниз
    

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
            Vector3 rotation = new(-_mouseDelta.y, _mouseDelta.x, 0);
            rotation = transform.eulerAngles + _sensitivity * Time.deltaTime * rotation.normalized;
            rotation.x = Mathf.Clamp(rotation.x, -_maxYAngle, _maxYAngle);
            transform.rotation = Quaternion.Euler(rotation);
        }
    }
}
