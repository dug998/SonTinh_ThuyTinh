using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeSubMenu : MonoBehaviour
{
    public Button _btnRanking;
    public Button _btnMission;
    public Button _btnReward;
    public Button _btnDaily;
    private void Awake()
    {
        _btnRanking.onClick.AddListener(() => PopupController.Instance.ShowPopup(TypePopup.PopupShop));
        _btnMission.onClick.AddListener(() => PopupController.Instance.ShowPopup(TypePopup.PopupMission));
        _btnReward.onClick.AddListener(() => PopupController.Instance.ShowPopup(TypePopup.PopupShop));
        _btnDaily.onClick.AddListener(() => PopupController.Instance.ShowPopup(TypePopup.PopupDailyMonth));

    }
}
