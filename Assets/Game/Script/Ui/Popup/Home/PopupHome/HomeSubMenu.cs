using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeSubMenu : MonoBehaviour
{
    public ButtonUi _btnRanking;
    public ButtonUi _btnMission;
    public ButtonUi _btnReward;
    public ButtonUi _btnDaily;
    private void Awake()
    {
        _btnRanking.AddEvent(() => InventoreManager.Instance.AddItemsRandom());
        _btnMission.AddEvent(() => PopupController.Instance.ShowPopup(TypePopup.PopupMission));
        _btnReward.AddEvent(() => PopupController.Instance.ShowPopup(TypePopup.PopupShop));
        _btnDaily.AddEvent(() => PopupController.Instance.ShowPopup(TypePopup.PopupDailyMonth));

    }
    public void OnEnable()
    {
        EventGame.OnNotifyQuest += NotifyMission;
        EventGame.OnNotifyDaily += NotifyDaily;
    }
    private void OnDisable()
    {

    }
    public void NotifyMission(bool values)
    {
        _btnMission._objNotify.gameObject.SetActive(values);
    }
    public void NotifyDaily(bool values)
    {
        _btnDaily._objNotify.gameObject.SetActive(values);
    }
}
