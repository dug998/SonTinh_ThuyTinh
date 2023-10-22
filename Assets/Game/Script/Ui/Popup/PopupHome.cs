using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupHome : PopupBase
{
    [Header(" ____ Button ___ "), Space(30)]
    public ButtonBase _btnPlay;
    private void Awake()
    {
        _btnPlay.AddEvent(OnClickButtonStartGame);
    }
    public void OnClickButtonStartGame()
    {
        Hide();
        PopupController.Instance.ShowPopupChoice(true);
    }
}
