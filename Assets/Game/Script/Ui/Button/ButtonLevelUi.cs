using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLevelUi : ButtonBase
{
    [SerializeField] int _id;
    [SerializeField] TextMeshProUGUI _textTitle;
    [SerializeField] Image _spriteIcon;

    public override void Init(object data)
    {
        DataLevel _data = (DataLevel)data;
        _textTitle.text = _data._title;
        _id = _data._id;
        _spriteIcon.sprite = _data._spriteiIcon;
    }
}
