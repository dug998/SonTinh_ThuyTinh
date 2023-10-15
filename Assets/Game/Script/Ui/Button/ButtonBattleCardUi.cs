using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBattleCardUi : ButtonBase
{
    public Image _iconCard;
    public int _price;
    bool _active = false;
    [Header("__")]
    public Image _activeImgFill;
    public Image _ImgOff;
    DataCard _data;
    protected override void Awake()
    {
        AddEvent(OnClick);
    }
    public override void Init(object data)
    {
        _data = (DataCard)data;
        _iconCard.sprite = _data._spriteiIcon;
        _price = _data._price;

    }
    public void UpdateStatusCard(int CurCoin)
    {

        if (CurCoin >= _price)
        {
            _btn.enabled = _active;
            _ImgOff.gameObject.SetActive(false);
        }
        else
        {
            _btn.enabled = false;
            _ImgOff.gameObject.SetActive(true);
        }
    }
    public void OnClick()
    {
        print(_data._id + " : " + _data._title);
        GameManager._CardSelect = _data;
    }
}
