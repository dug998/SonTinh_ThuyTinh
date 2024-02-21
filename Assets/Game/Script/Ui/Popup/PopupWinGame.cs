using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupWinGame : PopupBase
{
    [Header(" ______ Button  _____ "), Space(20)]

    public ButtonBase _btnHome;
    public ButtonBase _btnContinue;
    public ButtonBase _btnReplay;

    private void Awake()
    {
        _btnHome.AddEvent(OnClickButtonHome);
        _btnContinue.AddEvent(OnClickButtonContinue);
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

    }
    public void OnClickButtonContinue()
    {
        if (!_isShow)
        {
            return;
        }
        Hide();
        PopupController.Instance.ShowPopupChoiceLevel(true);

    }
    public void OnClickButtonReplay()
    {
        if (!_isShow)
        {
            return;
        }
        Hide();
        GameManager.Instance.StartLevelGame();

    }


}
