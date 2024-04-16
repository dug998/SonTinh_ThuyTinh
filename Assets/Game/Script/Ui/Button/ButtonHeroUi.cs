using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHeroUi : ButtonBase
{
    [SerializeField] int _id;
    [SerializeField] TextMeshProUGUI _textTitle;
    [SerializeField] Image _spriteIcon;
    [HideInInspector] public DataHero _data;
    protected bool _selected = true;
    public GameObject _maskSelected;
    public override void Init(object data)
    {
        _data = (DataHero)data;
        _id = _data._id;
        _textTitle.text = _data._title;
        _spriteIcon.sprite = _data._spriteCard;
        SetSelected(false);
    }
    public void ChooseHero()
    {
        PopupController.Instance._popupChoiceHero._heroesInfo.Init(_data);
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
