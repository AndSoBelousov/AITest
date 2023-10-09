using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBlade : MonoBehaviour
{
    private UnitCharacteristics _unitChar;

    private void Start()
    {
        _unitChar = GetComponentInParent<UnitCharacteristics>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.layer != this.gameObject.layer)
        {
            UnitCharacteristics characteristics = other.GetComponent<UnitCharacteristics>();
            if (characteristics != null)
            {
                characteristics.UnitHealth -= _unitChar.ActualDamage;
            }
            Debug.Log("Нанесен урон");
        }
    }
}
