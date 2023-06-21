using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BotAttack : BotNavigation
{
    private const string _fast = "Fast";
    private const string _strong = "Strong";

    [SerializeField]
    private string _deltaString ;
    [SerializeField]
    private int random;


    [SerializeField]
    private Collider _collider;

    //[SerializeField, Range(0,100), Tooltip("Шанс быстрой атаки по отношению к сильной")]




    private void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _characteristics = GetComponent<UnitCharacteristics>();

        StartCoroutine(QuickAttackChance());
    }
    
    private void FixedUpdate()
    {
        //QuickAttackChance();
        Attack(_deltaString);
    }
    private void Attack(string result)
    {
        if (_currentTarget != null && _agent.remainingDistance < _agent.stoppingDistance && _agent.remainingDistance !=0)
        {
            _animator.SetTrigger(result);

            
        }
    }
    private IEnumerator QuickAttackChance()
    {
        while (true) 
        {
            random = Random.Range(0, 100);
            if (random <= _characteristics.FastAttackChance)
            {
                _deltaString = _fast;
                _characteristics.ActualDamage = _characteristics.DamageFastAttack;
            }
            else
            {
                _deltaString = _strong;
                _characteristics.ActualDamage = _characteristics.DamageStrongAttack;
            }
            yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
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
