using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    public static WeatherManager Instance;
    public bool _isRain;
    [Header(" Rain ")]
    public ParticleSystem _parRain;

    [Header(" Sun ")]
    public ParticleSystem parSun;
    [Button]
    public void ChangeWeather()
    {
        _isRain = !_isRain;
        EventGame.OnNotifyWeather.Invoke(_isRain);
        _parRain.gameObject.SetActive(_isRain);
        if (_isRain)
        {
            _parRain.Play();
        }
        else
        {

        }
    }
}
