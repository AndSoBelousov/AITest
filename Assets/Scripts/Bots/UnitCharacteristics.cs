using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitCharacteristics : MonoBehaviour
{
    [SerializeField, Range (0, 500)]
    private int _unitHealth = 250;
    private int _damageFastAttack = 15;
    private int _damageStrongAttack = 40;
    [SerializeField]
    private int _actualDamage;
    [SerializeField]
    private float _unitSpeed = 5;
    [SerializeField, Range(1, 100)]
    private int _fastAttackChance = 50;
    [SerializeField, Range(2f, 5f)]
    private float _attackCooldown = 2f; 

    private bool _unitDead = false;
    [SerializeField]
    private TeamColor _teamColor;


    public int UnitHealth
    { get { return _unitHealth; } set { _unitHealth = value; } }

    public int DamageFastAttack
    { get { return _damageFastAttack; } set { _damageFastAttack = value; } }

    public int DamageStrongAttack
    { get { return _damageStrongAttack; } set { _damageStrongAttack = value; } }

    public int ActualDamage
    { get { return _actualDamage; } set { _actualDamage = value; } }

    public float UnitSpeed
    { get { return _unitSpeed; } set { _unitSpeed = value; } }

    public bool UnitDead
    { get { return _unitDead; } set { _unitDead = value; } }

    public int FastAttackChance
    { get { return _fastAttackChance; } set { _fastAttackChance = value; } }

    public float AttackCooldown
    { get { return _attackCooldown; } set { _attackCooldown = value; } }

    public TeamColor Color
    { get { return _teamColor; } }
}
