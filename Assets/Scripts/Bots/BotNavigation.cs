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

    private void Start()
    {
        _initialTarget = FindObjectOfType<InitialTarget>().transform;
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _detectCollider = GetComponent<SphereCollider>();


        _agent.SetDestination(_initialTarget.position);
        if (_characteristics != null)
        {
            UnitSpeed(_characteristics.UnitSpeed);
        }
    }
    private void LateUpdate()
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
    }
    
    private void OnTriggerStay(Collider other)
    {
        //если нет актуальной цели, если это не часть карты и если это не твой союзник
        if (_currentTarget == null &&
            other.gameObject.layer != 9 &&
            other.gameObject.layer != this.gameObject.layer)
        {//записываем цель в переменную и отключаем коллайдер
            _currentTarget = other.gameObject;
        }
    }

    private void UnitSpeed(float speed)
    {
        _agent.speed = speed;
    }

}

