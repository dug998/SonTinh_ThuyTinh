using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHeroInfoUi : ButtonBase
{
    [SerializeField] int _id;
    [SerializeField] TextMeshProUGUI _txtTitle, txtName;
    [SerializeField] Image _spriteIcon;
    [HideInInspector] public HeroProfile _heroProfile;
    protected bool _selected = true;

    protected override void Awake()
    {
        base.Awake();
        _btn.onClick.AddListener(() =>
        {
            ChooseHero();
        });
    }
    public override void Init(object data)
    {
        _heroProfile = (HeroProfile)data;
        DataHeroSo _data = _heroProfile.dataHero;
        _id = _data.so_id;
        txtName.text = _data.so_name;
        _spriteIcon.sprite = _data.so_spriteAvatar;

    }
    public void ChooseHero()
    {
        PopupController.Instance.ShowPopup(TypePopup.PopupInfoHeros, _heroProfile);
    }

}
