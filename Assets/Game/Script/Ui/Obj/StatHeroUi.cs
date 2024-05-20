using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatHeroUi : MonoBehaviour
{
    Tweener _tween;
    public Slider _sliderStat;
    public TextMeshProUGUI _txtCurrentStat;
    [ReadOnly] public float curr;
    [ReadOnly] public float max;

    public void UpdateStat(float cur, float max)
    {
        curr = cur;
        this.max = max;
        float valuesCurr = ValuesSlider(cur, max);
        if (_tween != null)
        {
            _tween.Kill();
        }
        _tween = DOTween.To(() => 0, x => _sliderStat.value = x, valuesCurr, 0.5f);
        _txtCurrentStat.text = cur.ToString();
    }
    public float ValuesSlider(float cur, float max)
    {
        return cur / max;
    }
}
