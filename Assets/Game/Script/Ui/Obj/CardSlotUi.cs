using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSlotUi : MonoBehaviour
{
    [SerializeField] Text _txtTitle;
    [SerializeField] Text _txtPrice;
    [SerializeField] Image _icon;
    [SerializeField] GameObject _maskAdd, _maskLock;
    bool _locked = false;
    public void Init(bool _locked)
    {
        this._locked = _locked;
        _maskAdd.SetActive(!_locked);
        _maskLock.SetActive(_locked);

        _txtTitle.text = "";
        _txtPrice.text = "";
        // _icon.sprite = null;
    }
    public void Show()
    {
        if (_locked)
        {
            return;
        }
        _maskAdd.SetActive(false);
    }
    public void UpdateData(DataCard data)
    {
        if (_locked)
        {
            _maskLock.SetActive(_locked);
            return;
        }
        if (data == null)
        {
            _maskAdd.SetActive(true);
        }
        _txtTitle.text = data._title;
        _txtPrice.text = data._price.ToString();
        _icon.sprite = data._spriteCard;
    }
}
