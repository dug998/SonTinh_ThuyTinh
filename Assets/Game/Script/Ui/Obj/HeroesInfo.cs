using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroesInfo : MonoBehaviour
{
    public static DataHero _curData;
    public Image _avatarHero;
    public TextMeshProUGUI _txtName;
    [Header(" -- stat --")]
    public Slider _sliderStatHp;
    public Slider _sliderStatDamage;
    public Slider _sliderStatDefense;
    public void Init(DataHero dataHero)
    {
        if (_curData == dataHero)
        {
            return;
        }
        _curData = dataHero;
        _avatarHero.sprite = dataHero._spriteAvatar;
        _avatarHero.SetNativeSize();
        _txtName.text = dataHero._name;
        DOTween.To(() => 0, x => _sliderStatHp.value = x, ValuesSlider(dataHero._statHp, ConstStatHero._maxHp), 0.5f);
        DOTween.To(() => 0, x => _sliderStatDamage.value = x, ValuesSlider(dataHero._statDamage, ConstStatHero._maxDamage), 0.5f);
        DOTween.To(() => 0, x => _sliderStatDefense.value = x, ValuesSlider(dataHero._statDefense, ConstStatHero._maxDefense), 0.5f);
    }
    public float ValuesSlider(float cur, float max)
    {
        return cur / max;
    }
}
