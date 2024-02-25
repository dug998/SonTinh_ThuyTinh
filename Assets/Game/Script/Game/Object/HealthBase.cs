using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    [SerializeField] ObjectBase _objectBase;
    [SerializeField] protected int _maxHealth;
    [SerializeField] protected int _currentHealth;
    public void SetMaxHealth(int values)
    {
        _maxHealth = values;
    }
    public void Init()
    {
        _currentHealth = _maxHealth;
    }
    public void TakeDame(int dame)
    {
        _currentHealth += dame;
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Die();
        }
    }
    public void Die()
    {
        _objectBase.Died();
    }
    public int GetCurrentHealth()
    {
        return _currentHealth;
    }
    public int GetMaxHealth()
    {
        return _maxHealth;
    }
}
