using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopChest : MonoBehaviour
{
    public int _price;
    public ButtonUi btnBuy;
    public List<Reward> _itemsRewards;
    private void Awake()
    {
        btnBuy.AddEvent(OnClickBuy);
        btnBuy._txtName.text = _price.ToString();
    }
    void OnClickBuy()
    {
        if (UserData.GemGame < _price)
        {
            LogGame.Log(" Not enough gem !");
            return;
        }
        UserData.GemGame -= _price;
        PopupController.Instance.ShowPopup(TypePopup.PopupReward, _itemsRewards);
    }
}
