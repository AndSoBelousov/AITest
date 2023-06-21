using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBlade : MonoBehaviour
{
    //private Animator _animator;
    private UnitCharacteristics _thisChar;

    //private void Start()
    //{
    //    _animator = GetComponent<Animator>();   
    //}

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.layer != this.gameObject.layer)
        {
            UnitCharacteristics enemyChar = other.GetComponent<UnitCharacteristics>();
            if (enemyChar != null && _thisChar != null )
            { 
                enemyChar.UnitHealth -= _thisChar.ActualDamage; 
            }
            
            
        }
    }

    //private void CheckActualDamage()
    //{
    //    if(_animator.na)
    //}

}
