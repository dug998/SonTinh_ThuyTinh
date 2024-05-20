using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPack : MonoBehaviour
{
    public TypeCurrency _typeCurrency;
    public string _namePack;
    public int _amount;
    public float _price;
    public ButtonUi btnBuy;
    public GameObject _iconItem;
    public TextMeshProUGUI _txtValues;
    
    public List<Reward> _items;
    private void Awake()
    {
        btnBuy.AddEvent(OnClickBuy);
        _txtValues.text = _amount.ToString();
    }
    void OnClickBuy()
    {
        if (_typeCurrency == TypeCurrency.Gold)
        {
            UserData.GoldGame += _amount;
            CurrencyVFX.Instance.InitGolds(_iconItem.GetComponent<RectTransform>(), _amount);
        }
        else
        {
            UserData.GemGame += _amount;
            CurrencyVFX.Instance.InitGems(_iconItem.GetComponent<RectTransform>(), _amount);
        }
    }
}
