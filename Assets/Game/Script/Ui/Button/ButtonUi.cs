using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUi : ButtonBase
{
    public GameObject _maskActiviy;
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
