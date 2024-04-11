using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUi : ButtonBase
{
    public bool justClick = true;
    [HideIf("justClick")]
    public Image _imgBg;
    public Sprite _spBgSelect, _spBgUnSelect;

    public TextMeshProUGUI _txtName;
    public Color _colorNameSelect, _colorNameUnSelect;

    public Image _icon;
    public Sprite _spIconSelect, _spIconUnSelect;
    [HideIf("justClick")]
    public TextMeshProUGUI _txtDesc;
    [HideIf("justClick")]
    public Image _bg;
    //   public GameObject _BgActiviy;
    public override void Init(object data)
    {

    }
    public override void Activity(bool values)
    {
        base.Activity(values);
        if (_imgBg != null)
        {
            _imgBg.sprite = values ? _spBgSelect : _spBgUnSelect;
        }
        if (_txtName != null)
        {
            _txtName.color = values ? _colorNameSelect : _colorNameUnSelect;
        }
        if (_icon != null)
        {
            _icon.sprite = values ? _spIconSelect : _spIconUnSelect;
        }

    }
    protected override void Awake()
    {
        base.Awake();
        //_maskActiviy.transform.localScale = _BgActiviy.transform.localScale + Vector3.one * 0.1f;
    }
}
