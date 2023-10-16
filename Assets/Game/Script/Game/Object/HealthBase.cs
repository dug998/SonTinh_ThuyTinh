using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    [SerializeField] ObjectBase _objectBase;
    [SerializeField] protected int _maxHealth;
    [SerializeField] protected int _currentHealth;
    public void SetMaxHealth()
    {
        _currentHealth = _maxHealth;
    }
    public void TakeDame(int dame)
    {
        _currentHealth += dame;
        if (_currentHealth < 0)
        {
            _currentHealth = 0;
            Die();
        }
    }
    public void Die()
    {
        _objectBase.Die();
    }
}
