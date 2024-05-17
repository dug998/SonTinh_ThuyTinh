using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroSlotUi : MonoBehaviour
{
    [SerializeField] Text _txtName;
    [SerializeField] Text _txtPrice;
    [SerializeField] Image _icon;
    [SerializeField] GameObject _maskAdd, _maskLock;
    bool _locked = false;
    public void Init(bool _locked)
    {
        this._locked = _locked;
        _maskAdd.SetActive(!_locked);
        _maskLock.SetActive(_locked);

        _txtName.text = "";
        _txtPrice.text = "";
        // _spIcon.sprite = null;
    }
    public void Show()
    {
        if (_locked)
        {
            return;
        }
        _maskAdd.SetActive(false);
    }
    public void UpdateData(DataHeroSo data)
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
        _txtName.text = data.so_title;
        _txtPrice.text = data.so_price.ToString();
        _icon.sprite = data.so_spriteCard;
    }
}
