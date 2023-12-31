using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitCondition : BotNavigation
{


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _characteristics = GetComponent<UnitCharacteristics>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        MovementAnimation(_agent.velocity.magnitude);
        DeathCheck();   
    }

    private void DeathCheck()
    {
        if (_characteristics != null && _characteristics.UnitHealth <= 0)
        {
            _characteristics.SetUnitDead(true);
            
            _animator.SetTrigger("Die");
        }
    }

    public void RemoveTheBody()
    {

        Destroy(gameObject);
    }

    private void MovementAnimation(float speed)
    {
        _animator.SetFloat("Movement", speed);
    }
}
