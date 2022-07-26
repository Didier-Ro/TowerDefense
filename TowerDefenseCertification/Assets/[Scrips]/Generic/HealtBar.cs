using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    [SerializeField] private Transform _lookAtCamera = default;
    [SerializeField] private Canvas _canvas = default;
    [SerializeField] private Slider _slider = default;
    [SerializeField] private Health _health = default;

    private void Awake()
    {
        _lookAtCamera = Camera.main.transform;
        _canvas.worldCamera = Camera.main;
        _slider.maxValue = _health.CurrentHealth;
        _slider.value = _health.CurrentHealth;
    }

    public void UpdateSliderValue(int newValue)
    {
        _slider.value = newValue;
    }

    private void Update()
    {
        transform.LookAt(_lookAtCamera);
    }
}
