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
    public DataLevel _data;
    public GameObject _objFocus;
    public override void Init(object data)
    {
        _data = (DataLevel)data;
        _textTitle.text = _data._title;
        _id = _data._id;
        _spriteIcon.sprite = _data._spriteiIcon;
    }
    public void onSelect(bool select)
    {
        _objFocus.SetActive(select);
    }
}
