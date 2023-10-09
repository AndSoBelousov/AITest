using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    UnitCharacteristics _unitCharacteristics;
    private Camera mainCamera;

    private float _maxHealth;


    [SerializeField]
    private GameObject _healthBar;
    [SerializeField]
    private GameObject _healthBarPrefab;

    void Start()
    {
        mainCamera = Camera.main;
        _unitCharacteristics = GetComponent<UnitCharacteristics>();


        //_maxHealth = _unitCharacteristics.UnitHealth;

        if (_unitCharacteristics != null)
        {
            _maxHealth = _unitCharacteristics.UnitHealth;
            Debug.Log(_maxHealth);
        }
        else
        {
            Debug.Log("ошибка");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AlignCamera();
        CulculateHealth();
    }

    private void CulculateHealth()
    {
        var delta = _unitCharacteristics.UnitHealth / _maxHealth;
        Debug.Log(delta);
        if(delta <= 0 )
        {
            _healthBar.transform.localScale = new Vector3(0, 0.3f, 0.2f);
            return;
        }
        _healthBar.transform.localScale =new Vector3(3f * (float)delta,0.3f , 0.2f);

    }
    private void AlignCamera()
    {
        if (mainCamera != null)
        {
            var camXform = mainCamera.transform;
            var forward = transform.position - camXform.position;
            forward.Normalize();
            var up = Vector3.Cross(forward, camXform.right);
            _healthBarPrefab.transform.rotation = Quaternion.LookRotation(forward, up);
        }
    }

}
