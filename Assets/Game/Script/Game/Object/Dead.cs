using DG.Tweening;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    [SerializeField] public SpriteRenderer _icon;
    [SerializeField] Material _material;
    string variable = "Pixel_Fade";
    Material _mat;
    private void Awake()
    {
        if (_icon == null)
            return;
        _mat = new Material(_material);
        _icon.material = _mat;
        _mat.SetFloat(variable, 0);
    }
    public void PixelGravityDie(int duration = 3)
    {
        if (_icon == null)
            return;
        DOTween.To(() => 0, x => _mat.SetFloat(variable, x), 1f, duration).SetEase(Ease.Linear);
    }

}
