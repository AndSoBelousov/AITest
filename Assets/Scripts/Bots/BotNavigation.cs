using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class BotNavigation : MonoBehaviour
{
    protected NavMeshAgent _agent;
    protected Animator _animator;
    protected UnitCharacteristics _characteristics;
    protected SphereCollider _detectCollider;

    private Transform _initialTarget;
    protected GameObject _currentTarget;

    private void Awake()
    {
        _characteristics = new UnitCharacteristics();
        
    }
    private void Start()
    {
        _initialTarget = FindObjectOfType<InitialTarget>().transform;
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _detectCollider = GetComponent<SphereCollider>();


        _agent.SetDestination(_initialTarget.position);
        UnitSpeed(_characteristics.UnitSpeed);
    }
    
    private void FixedUpdate()
    {
        Aggression();
        CheckTheTargetsPulse();
        TurningTowardsTheEnemy();
        
    }

    private void CheckTheTargetsPulse()
    {   //если есть тукущая цель и он мертв 
        if (_currentTarget != null) 
        {
            if(_currentTarget.GetComponent<UnitCharacteristics>().UnitDead == true)
            {
                _currentTarget = null;
            }
        }    
    }

    private void Aggression()
    { 
        if (_currentTarget != null)
        {
            _agent.SetDestination(_currentTarget.transform.position);
        }
    }

    private void TurningTowardsTheEnemy()
    {
        if (_currentTarget != null)
        {
            Vector3 targetDirection = (_currentTarget.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }

        //if (_currentTarget != null && _agent.velocity.magnitude <= 0.1)
        //{
        //    _agent.transform.LookAt(_currentTarget.transform);
        //}
    }
    private void OnCollisionEnter(Collision other)
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //если нет актуальной цели, если это не часть карты и если это не твой союзник
        if (_currentTarget == null &&
            other.gameObject.layer != 9 &&
            other.gameObject.layer != this.gameObject.layer)
        {
            _currentTarget = other.gameObject;
            this.gameObject.GetComponent<SphereCollider>().enabled = false;
        }
    }
    
    private void UnitSpeed(float speed)
    {
        _agent.speed = speed;
    }

}

