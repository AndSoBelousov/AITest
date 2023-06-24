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
    
    private Camera _camera;

    private void Awake()
    {
        _customInput = new();
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _moveVector * _moveSpeed; 
    }

    private void OnEnable()
    {
        _customInput.Enable();
        _customInput.CamActionMap.Movement.performed += OnMovementPerformed;
        _customInput.CamActionMap.Movement.canceled += OnMovementCancelled;
    }

    private void OnDisable()
    {
        _customInput.Disable();
        _customInput.CamActionMap.Movement.performed -= OnMovementPerformed;
        _customInput.CamActionMap.Movement.canceled -= OnMovementCancelled;
    }

    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
        _moveVector = context.ReadValue<Vector3>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext context)
    {
        _moveVector = Vector3.zero;
    }
}
