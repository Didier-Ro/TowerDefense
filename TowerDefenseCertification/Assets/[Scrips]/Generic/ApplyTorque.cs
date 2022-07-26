using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ApplyTorque : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody = default;
    private Vector3 _forceVector = default;
    [SerializeField] private ForceMode _forceMode = default;
    [SerializeField] private float _xForce = 1;
    [SerializeField] private float _minYFoce = 5;
    [SerializeField] private float _maxYForce = 10;
    [SerializeField] private float _zForce = 1;
    [SerializeField] private bool _applyForceOnAwake = default;

    private void Awake()
    {
        _forceVector.x = Random.Range(-_xForce, _xForce);
        _forceVector.y = Random.Range(_minYFoce, _maxYForce);
        _forceVector.z = Random.Range(-_zForce, _zForce);
        if ( _applyForceOnAwake)
        {
            ApplyTorqueVector();
        }
    }

    public void ApplyTorqueVector()
    {
        _rigidbody.AddTorque(_forceVector, _forceMode);
    }
}
