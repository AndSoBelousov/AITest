using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBlade : MonoBehaviour
{
    

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.layer != this.gameObject.layer)
        {
            UnitCharacteristics characteristics = other.GetComponent<UnitCharacteristics>();
            if (characteristics != null)
            {
            characteristics.UnitHealth -= 20;//todo 
            }
            Debug.Log("Нанесен урон");
        }
    }
}
