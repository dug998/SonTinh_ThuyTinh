using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeMenu : MonoBehaviour
{
    public Button _btnShop;
    public Button _btnHero;
    public Button _btnInventory;
    private void Awake()
    {
        _btnShop.onClick.AddListener(() => PopupController.Instance.ShowPopup(TypePopup.PopupShop));
        _btnHero.onClick.AddListener(() => PopupController.Instance.ShowPopup(TypePopup.PopupListHeros));
        _btnInventory.onClick.AddListener(() => PopupController.Instance.ShowPopup(TypePopup.PopupInventory));

    }
}
