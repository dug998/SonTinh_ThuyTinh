using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupHome : PopupBase
{
    [Header(" ---- Button ---- "), Space(30)]
    public ButtonBase _btnPlay;
    public ButtonBase _btnBoss;
    public ButtonBase _btnSetting;

    [Header("---- Package --- ")]

    [Header("---- Menu --- ")]
    public ButtonBase _btnShop;

    private void Awake()
    {
        _btnPlay.AddEvent(OnClickButtonStartGame);
    }
    public void OnClickButtonStartGame()
    {
        Hide();
        PopupController.Instance.ShowPopupChoiceLevel(true);
    }
}
