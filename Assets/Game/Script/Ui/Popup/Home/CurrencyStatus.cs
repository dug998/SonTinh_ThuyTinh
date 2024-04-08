using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyStatus : MonoBehaviour
{
    public Button _btnAdd;
    private void Awake()
    {
        _btnAdd.onClick.AddListener(() =>
        {
            PopupController.Instance.ShowPopup(TypePopup.PopupShop);
        });
    }
}
