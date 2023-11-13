using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class UnitCharacteristics : MonoBehaviour
{
    [SerializeField]
    private int _unitHealth = 250;
    private int _damageFastAttack = 15;
    private int _damageStrongAttack = 40;
    private int _actualDamage;
    private float _unitSpeed = 5;
    private int _fastAttackChance = 50;
    private int _chanceOfCrite;
    private int _chanceOfMiss;


    [SerializeField, Range(2f, 5f)]
    private float _attackCooldown = 2f; 

    private bool _unitDead = false;
    private TeamColor _teamColor;


    public int UnitHealth
    { get { return _unitHealth; } private set { _unitHealth = value; } }
    public void SetUnitHealth(int value) => UnitHealth = value;

    public int DamageFastAttack
    { get { return _damageFastAttack; } private set { _damageFastAttack = value; } }
    public void SetDamageFastAttack(int value) => DamageFastAttack = value;

    public int DamageStrongAttack
    { get { return _damageStrongAttack; } private set { _damageStrongAttack = value; } }
    public void SetDamageStrongAttack(int value) => DamageStrongAttack = value;

    public int ActualDamage
    { get { return _actualDamage; } private set { _actualDamage = value; } }
    public void SetActualDamage(int value) => ActualDamage = value;

    public float UnitSpeed
    { get { return _unitSpeed; }private set { _unitSpeed = value; } }
    public void SetUnitSpeed(float value) => UnitSpeed = value;

    public bool UnitDead
    { get { return _unitDead; }private set { _unitDead = value; } }
    public void SetUnitDead(bool value) => UnitDead = value;

    public int FastAttackChance
    { get { return _fastAttackChance; }private set { _fastAttackChance = value; } }
    public void SetFastAttackChance(int value) => FastAttackChance = value;

    public int ChanceOfCrite
    { get { return _chanceOfCrite; } private set { _chanceOfCrite = value; } }
    public void SetCanceOfCrite(int value) => ChanceOfCrite = value;

    public int ChanceOfMiss
    { get { return _chanceOfMiss; } private set { _chanceOfMiss = value; } }
    public void SetChanceOfMiss(int value) => ChanceOfMiss = value;

    public float AttackCooldown
    { get { return _attackCooldown; } }

    public TeamColor Color
    { get { return _teamColor; } }
}
