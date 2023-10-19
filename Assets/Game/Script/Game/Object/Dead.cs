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
        _mat = new Material(_material);
        _icon.material = _mat;
        _mat.SetFloat(variable, 0);
    }
    public void PixelGravityDie(int duration = 3)
    {
        float values = 0;
        DOTween.To(() => 0, x => _mat.SetFloat(variable, x), 1f, duration).SetEase(Ease.Linear).OnUpdate(() =>
        {
           // _mat.SetFloat(variable, values);
        });
    }
    //void Start()
    //{
    //    float giaTriBanDau = 0.0f;
    //    float giaTriCuoi = 1.0f;
    //    float thoiGian = 2.0f;

    //    S? d?ng DOTween.To ?? t?o ho?t ?nh t?ng giá tr? t? 0 ??n 1
    //    DOTween.To(() => giaTriBanDau, x => giaTriBanDau = x, giaTriCuoi, thoiGian)
    //        .OnUpdate(() => Debug.Log("Giá tr? hi?n t?i: " + giaTriBanDau))
    //        .OnComplete(() => Debug.Log("Hoàn thành ho?t ?nh"));
    //}
}
