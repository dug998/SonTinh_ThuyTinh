using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopupHome : PopupBase
{
    [Header(" ---- Button ---- "), Space(30)]
    public ButtonBase _btnPlay;
    public ButtonBase _btnBoss;
    public Button _btnSetting;

    [Header(" ---- Home --- "), Space(20)]
    public HomeMissionInfo _homeMissionInfo;
    public HomeMenu _homeMenu;
    public HomePackage _homePackage;

    protected override void Awake()
    {
        base.Awake();
        _btnPlay.AddEvent(OnClickButtonStartGame);
        _btnSetting.onClick.AddListener(() => PopupController.Instance.ShowPopup(TypePopup.PopupSetting));

    }
    public void OnClickButtonStartGame()
    {
        Hide();
        PopupController.Instance.ShowPopup(TypePopup.PopupChoiceLevel);
    }
    public override void Show(object data = null)
    {
        base.Show(data);
        PopupCurrencyStatus.Instance.Show();
    }
    public override void Hide()
    {
        PopupCurrencyStatus.Instance.Hide();
        base.Hide();
    }
}
