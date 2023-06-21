using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitCharacteristics : MonoBehaviour
{
    [SerializeField]
    private int _unitHealth = 100;
    private int _damageFastAttack = 20;
    private int _damageStrongAttack = 50;
    private int _actualDamage;
    private float _unitSpeed = 5;


    private bool _unitDead = false;
    [SerializeField]
    private TeamColor _teamColor;


    private int _fastAttackChance = 50;

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

    public TeamColor Color
    { get { return _teamColor; } }
}
