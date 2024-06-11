using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHeroUi : ButtonBase
{
    [SerializeField] int _id;
    [SerializeField] bool _isLock;
    [SerializeField] TextMeshProUGUI _textTitle;
    [SerializeField] Image _spriteIcon;
    [HideInInspector] public HeroProfile _heroProfile;
    protected bool _selected = true;
    public GameObject _maskSelected;
    public GameObject _ObjLock;
    
    public override void Init(object data)
    {
        _heroProfile = (HeroProfile)data;

        _isLock = !_heroProfile._own;
        _ObjLock.SetActive(_isLock);
        DataHeroSo _data = _heroProfile.dataHero;
        _id = _data.so_id;
        _textTitle.text = _data.so_title;
        _spriteIcon.sprite = _data.so_spriteCard;
        SetSelected(false);
    }
    public void ChooseHero()
    {
        if (_isLock)
        {
            return;
        }
        PopupController.Instance._popupChoiceHero._heroesInfo.Init(_heroProfile);
        if (_selected)
        {
            return;
        }
        SetSelected(true);
        PopupController.Instance._popupChoiceHero.ChooseHero(this);
    }
    public void SetSelected(bool values)
    {

        if (_selected == values)
        {
            return;
        }
        _selected = values;
        _maskSelected.SetActive(values);
    }
}
