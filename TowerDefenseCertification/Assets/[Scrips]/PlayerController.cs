using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _gunPrefab = default;
    [SerializeField] private GameObject _cannonPrefab = default;
    [SerializeField] private GameObject _laserTurretPrefab = default;
    [SerializeField] private GameObject _heldWeapon = default;
    [SerializeField] private Camera _mainCamera = default;
    [SerializeField] private float _maxRayDistance = 20;
    [SerializeField] private LayerMask _layerMaskGround = default;
    [SerializeField] private UnityEvent<string> OnWeaponPurchased = default;

    private void Start()
    {
        StartCoroutine(HeldWeaponRoutine());
    }

    public void CreateWeapon(string weaponType)
    {
        if (_heldWeapon != null)
            return;
        
        switch (weaponType)
        {
            case "Gun":
                _heldWeapon = Instantiate(_gunPrefab);
                break;
            case "Cannon":
                _heldWeapon = Instantiate(_cannonPrefab);
                break;
            case "LaserTurret":
                _heldWeapon = Instantiate(_laserTurretPrefab);
                break;
            default:
                Debug.LogError($"Weapon type {weaponType} is not valid");
                break;
        }
        
        OnWeaponPurchased?.Invoke(weaponType);
    }

    IEnumerator HeldWeaponRoutine()
    {
        while (GameManager.Instance.CurrentGameState == GameManager.GameState.Playing)
        {
            if (_heldWeapon != null)
            {
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, _maxRayDistance, _layerMaskGround))
                {
                    _heldWeapon.transform.position = hit.point;
                    if (Input.GetMouseButton(0) && hit.collider.CompareTag("WeaponSlot") && hit.transform.childCount == 0)
                    {
                        _heldWeapon.transform.position = hit.transform.position;
                        _heldWeapon.transform.SetParent(hit.transform);
                        _heldWeapon.GetComponent<WeaponAttack>().StartWeaponAttack();
                        _heldWeapon = null;
                    }
                }
            }

            if (Input.GetMouseButton(1))
            {
                Destroy(_heldWeapon);
                _heldWeapon = null;
            }

            yield return null;
        }
    }
}