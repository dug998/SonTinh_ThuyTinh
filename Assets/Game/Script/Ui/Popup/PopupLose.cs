using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupLose : PopupBase
{
    [Header(" ______ Button  _____ "), Space(20)]

    public ButtonBase _btnHome;
    public ButtonBase _btnReplay;

    private void Awake()
    {
        _btnHome.AddEvent(OnClickButtonHome);
        _btnReplay.AddEvent(OnClickButtonReplay);
    }
    public override void Show(object data = null)
    {
        base.Show(data);
        _isShow = true;

    }
    public override void Hide()
    {
        _isShow = false;
        base.Hide();

    }
    public void OnClickButtonHome()
    {
        if (!_isShow)
        {
            return;
        }
        Hide();
        PopupController.Instance.ShowPopupHome(true);
        CanvasManager.Instance._Bg.SetActive(true);
    }
   
    public void OnClickButtonReplay()
    {
        if (!_isShow)
        {
            return;
        }
        Hide();
        PopupController.Instance.ShowPopupGamePlay(true);
        GameManager.Instance.StartLevelGame();

    }

}
