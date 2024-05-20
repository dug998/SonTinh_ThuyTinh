using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupPause : PopupBase
{
    public ButtonBase _btnSetting;
    public ButtonBase _btnContinue;
    public ButtonBase _btnReplay;
    public ButtonBase _btnGiveUp;

    protected override void Awake()
    {
        base.Awake();
        _btnSetting.AddEvent(() =>
        {
            PopupController.Instance.ShowPopup(TypePopup.PopupSetting);
        });
        _btnContinue.AddEvent(() =>
        {
            Hide();
        });

        _btnReplay.AddEvent(() =>
        {
            Hide();
            PopupController.Instance.ShowPopup(TypePopup.PopupGamePlay);
            GameManager.Instance.StartLevelGame();
        });

        _btnGiveUp.AddEvent(() =>
        {
            Hide();
            PopupController.Instance.ShowPopup(TypePopup.PopupHome);
            CanvasManager.Instance._Bg.SetActive(true);
        });
    }
    public override void Show(object data = null)
    {
        GameManager.Instance.PauseGame();
        base.Show(data);
    }
    public override void Hide()
    {
        GameManager.Instance.ContinueGame();
        base.Hide();
    }
}
