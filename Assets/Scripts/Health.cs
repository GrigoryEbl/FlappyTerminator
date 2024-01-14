using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void ApplyDamage(int damage)
    {
        int targetHealth = _currentHealth -= damage;

        _currentHealth = Mathf.Clamp(targetHealth, 0, _maxHealth);

        HealthChanged?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
            Died?.Invoke();
    }

    public void Heal(int addedHealth)
    {
        int targetHealth = _currentHealth += addedHealth;

        _currentHealth = Mathf.Clamp(targetHealth, 0, _maxHealth);

        HealthChanged?.Invoke(_currentHealth);
    }
}