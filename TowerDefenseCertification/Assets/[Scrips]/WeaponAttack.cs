using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class WeaponAttack : MonoBehaviour
{
    [SerializeField] private Transform _weaponBarrel = default;
    [SerializeField] private float _maxRayDistance = 20;
    [SerializeField] private int _damagePower = 10;
    [SerializeField] private float _shootCoolDown = 1;
    [SerializeField] private UnityEvent OnShoot = default;

    enum ShootTypeEnum
    {
        Ray,
        Instantiate,
    }

    [SerializeField] private ShootTypeEnum _shootType = default;
    [SerializeField] private GameObject _cannonBallPrefab = default;
    [SerializeField] private Transform _cannonBallSpawn = default;
    
    public void StartWeaponAttack()
    {
        StartCoroutine(FireRoutine());
    }

    IEnumerator FireRoutine()
    {
        while (GameManager.Instance.CurrentGameState == GameManager.GameState.Playing)
        {
            Ray ray = new Ray(_weaponBarrel.position, _weaponBarrel.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, _maxRayDistance))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    if (_shootType == ShootTypeEnum.Instantiate)
                    {
                        Instantiate(_cannonBallPrefab, _cannonBallSpawn.position, _cannonBallSpawn.rotation);
                    }
                    else
                    {
                        Health enemyHealth = hit.collider.GetComponent<Health>();
                        if (enemyHealth != null)
                        {
                            enemyHealth.ReceiveDamage(_damagePower);
                        }
                    }
                    OnShoot?.Invoke();
                }
                yield return new WaitForSeconds(_shootCoolDown);
            }
            else
            {
                yield return null;
            }
        }
    }
}
