using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotAttack : BotNavigation
{
    private const string _fast = "Fast";
    private const string _strong = "Strong";

    private float nextAttackTime; // Время следующей атаки


    private UnitCharacteristics _char;
    [SerializeField]
    private Collider _collider;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _char = GetComponent<UnitCharacteristics>();  
    }
    private void FixedUpdate()
    {
        Attack();

    }

    private void Attack()
    {       
        if (_currentTarget != null && _agent.remainingDistance < _agent.stoppingDistance 
            && _agent.remainingDistance !=0)
        {
            if (Time.time >= nextAttackTime)
            {
                QuickAttackChance();

                nextAttackTime = Time.time + _char.AttackCooldown;
            }
        }        
    }
   
    private void QuickAttackChance() // Выбираем тип атаки на основе вероятности
    {
        int randomFastOrStrong = Random.Range(0, 100);
        
        if (randomFastOrStrong <= _char.FastAttackChance)
        {
            _animator.SetTrigger(_fast);
            _char.SetActualDamage(_char.DamageFastAttack);            
        }
        else
        {
            _animator.SetTrigger(_strong);
            _char.SetActualDamage(_char.DamageStrongAttack);
        }

        ChanceCritOrMiss();
    }
    private void ChanceCritOrMiss()
    {
        int randomCrite = Random.Range(0, 100);
        int randomMiss = Random.Range(0, 100);
        if (randomCrite <= _char.ChanceOfCrite)
        {
            _char.SetActualDamage(_char.ActualDamage * 2);
        }
        if (randomMiss <= _char.ChanceOfMiss)
        {
            _char.SetActualDamage(0);
        }

    }

    private void EnableSwordCollider(int isActivity)
    {
        _collider.enabled = (isActivity != 0);
    }

    private void DisableSwordCollider(int isPassivity)
    {
        _collider.enabled = !(isPassivity == 0);
    }



}
