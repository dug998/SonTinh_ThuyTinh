using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSlotUi : MonoBehaviour
{
    [SerializeField] Text _txtTitle;
    [SerializeField] Text _txtPrice;
    [SerializeField] Image _icon;
    [SerializeField] GameObject _mask;
    public void Init()
    {
        _mask.SetActive(true);
        _txtTitle.text = "";
        _txtPrice.text = "";
       // _icon.sprite = null;
    }
    public void Show()
    {
        _mask.SetActive(false);
    }
    public void UpdateData(DataCard data)
    {
        _txtTitle.text = data._title;
        _txtPrice.text = data._price.ToString();
        _icon.sprite = data._spriteiIcon;
    }
}
