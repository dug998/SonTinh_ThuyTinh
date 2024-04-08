using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupInfoHeros : PopupBase
{

    public Image _iconAvatarHero;
    [Header(" --- ChracterInfo ---")]
    [Header(" --- Star ---")]
    public GameObject _start;
    [Header(" ---- Right_Panel --- ")]
    [Header(" SelectCharacterInfo "), Space(20)]
    public Image _imgRoleIcon;
    public TextMeshProUGUI _txtName, _txtDesc, _txtRole;

    [Header(" CharacterLevel "), Space(20)]
    public Slider _sliderExp;
    public TextMeshProUGUI _txtLevelNum, _txtExp;

    [Header(" Stat "), Space(20)]
    public Slider _sliderStatHp;
    public Slider _sliderStatDamage;
    public Slider _sliderStatDefense;
    public override void Show(object data = null)
    {
        base.Show(data);
        Init((DataHero)data);
    }
    public void Init(DataHero dataHero)
    {
        _txtName.text = dataHero._name;
        _iconAvatarHero.sprite = dataHero._spriteAvatar;
        _iconAvatarHero.SetNativeSize();

        _txtDesc.text = dataHero._description;

        DOTween.To(() => 0, x => _sliderStatHp.value = x, ValuesSlider(dataHero._statHp, ConstStatHero._maxHp), 0.5f);
        DOTween.To(() => 0, x => _sliderStatDamage.value = x, ValuesSlider(dataHero._statDamage, ConstStatHero._maxDamage), 0.5f);
        DOTween.To(() => 0, x => _sliderStatDefense.value = x, ValuesSlider(dataHero._statDefense, ConstStatHero._maxDefense), 0.5f);
    }
    float ValuesSlider(float cur, float max)
    {
        return cur / max;
    }

}
