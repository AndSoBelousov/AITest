using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotNavigation : MonoBehaviour
{
    protected NavMeshAgent _agent;
    protected Animator _animator;
    protected UnitCharacteristics _characteristics;

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

        _agent.SetDestination(_initialTarget.position);
        UnitSpeed(_characteristics.UnitSpeed);
    }
    
    private void FixedUpdate()
    {
        Aggression();
        
        TurningTowardsTheEnemy();
        
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
        if (_currentTarget != null && _agent.velocity.magnitude >= 0.1)
        {
            _agent.transform.LookAt(_currentTarget.transform) ;
        }
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
        }
    }
    
    private void UnitSpeed(float speed)
    {
        _agent.speed = speed;
    }

}

