using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCardUi : ButtonBase
{
    [SerializeField] int _id;
    [SerializeField] Text _textTitle;
    [SerializeField] Image _spriteIcon;


    public override void Init(object data)
    {
        DataCard _data = (DataCard)data;
        _id = _data._id;
        _textTitle.text = _data._title;
        _spriteIcon.sprite = _data._spriteiIcon;
    }
}
