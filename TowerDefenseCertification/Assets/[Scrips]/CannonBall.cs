using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] private float _cannonBallSpeed = 10;
    void Update()
    {
        transform.position += transform.forward * (Time.deltaTime * _cannonBallSpeed);
    }
}
