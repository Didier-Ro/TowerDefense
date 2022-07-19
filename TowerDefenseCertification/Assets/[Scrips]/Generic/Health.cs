using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _currentHealth = 100;
    [SerializeField] private UnityEvent OnReceiveDamage;
    [SerializeField] private UnityEvent OnZeroHealth;

    public int CurrentHealth
    {
        get => _currentHealth;
        set => _currentHealth = value;
    }

    public void ReceiveDamage(int damageAmount)
    {
        CurrentHealth -= damageAmount;
        OnReceiveDamage?.Invoke();
        if(CurrentHealth <= 0)
        {
            OnZeroHealth?.Invoke();
        }
    }
}