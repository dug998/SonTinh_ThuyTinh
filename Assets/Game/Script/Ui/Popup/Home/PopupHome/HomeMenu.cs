using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeMenu : MonoBehaviour
{
    public Button _btnShop;
    public Button _btnHero;
    public Button _btnInventory;
    public Button _btnUpgrade;
    private void Awake()
    {
        _btnShop.onClick.AddListener(() => PopupController.Instance.ShowPopup(TypePopup.PopupShop));
        _btnHero.onClick.AddListener(() => PopupController.Instance.ShowPopup(TypePopup.PopupListHeros));
        _btnInventory.onClick.AddListener(() => PopupController.Instance.ShowPopup(TypePopup.PopupInventory));
      //  _btnUpgrade.onClick.AddListener(() => PopupController.Instance.ShowPopup(TypePopup.PopupUpgradeHero, HeroManager.Instance.GetHeroProfile()));
    }
}
