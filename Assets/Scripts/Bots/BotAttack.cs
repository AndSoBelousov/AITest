using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotAttack : BotNavigation
{
    private const string _fast = "Fast";
    private const string _strong = "Strong";

    [SerializeField]
    private string _deltaString ;

    private UnitCharacteristics _char;
    [SerializeField]
    private Collider _collider;

    //[SerializeField, Range(0,100), Tooltip("Шанс быстрой атаки по отношению к сильной")]




    private void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _char = GetComponentInParent<UnitCharacteristics>(); //todo 
    }

    private void Update()
    {
        QuickAttackChance();
        Attack(_deltaString);
    }
    private void Attack(string result)
    {
        if (_currentTarget != null && _agent.remainingDistance < _agent.stoppingDistance && _agent.remainingDistance !=0)
        {
            _animator.SetTrigger(result);
        }
    }

    private void QuickAttackChance()
    {
        int random = Random.Range(0, 100);
        if (random <= _char.FastAttackChance)//todo неправильно работает
        {
            _deltaString = _fast;
        }
        else 
        {
            _deltaString = _strong;
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
