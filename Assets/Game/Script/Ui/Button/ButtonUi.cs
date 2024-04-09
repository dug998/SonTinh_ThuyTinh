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
    public GameObject _maskActiviy;
    [HideIf("justClick")]
    public TextMeshProUGUI _txtDesc;
    [HideIf("justClick")]
    public Image _icon;
    [HideIf("justClick")]
    public Image _bg;
    //   public GameObject _BgActiviy;
    public override void Init(object data)
    {

    }
    public override void Activity(bool values)
    {
        base.Activity(values);
        _maskActiviy.SetActive(!values);
    }
    protected override void Awake()
    {
        base.Awake();
        //_maskActiviy.transform.localScale = _BgActiviy.transform.localScale + Vector3.one * 0.1f;
    }
}
