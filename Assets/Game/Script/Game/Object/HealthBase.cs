using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBase : MonoBehaviour
{
    [SerializeField] ObjectBase _objectBase;
    [SerializeField] protected int _maxHealth;
    protected int _currentHealth;
    public Slider _sliderHealth;
    
    public TextMeshProUGUI _txtHealth;
    Tween _tween;
    public void SetMaxHealth(int values)
    {
        _maxHealth = values;
    }
    public void Init()
    {
        _currentHealth = _maxHealth;
        UpdateSliderHealth();
    }
    public void ReceiveDame(int dame)
    {
        _currentHealth += dame;
        if (_currentHealth <= 0)
        {
            UpdateSliderHealth();
            _currentHealth = 0;
            Die();
        }
        UpdateSliderHealth();
    }
    public void Die()
    {
        if (_tween != null)
        {
            _tween.Kill();
        }
        if (_sliderHealth != null || _txtHealth != null)
        {
            _sliderHealth.gameObject.SetActive(false);
            _txtHealth.gameObject.SetActive(false);
        }

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
    public void UpdateSliderHealth()
    {
        if (_sliderHealth == null|| _txtHealth == null)
        {
            return;
        }
        float valuesCurr = (float)_currentHealth / _maxHealth; ;
        if (_tween != null)
        {
            _tween.Kill();
        }
        _tween = DOTween.To(() => 0, x => _sliderHealth.value = x, valuesCurr, 0.1f);
        _txtHealth.text = _currentHealth.ToString();
    }
}
