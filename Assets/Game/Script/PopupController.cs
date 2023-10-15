using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    public static PopupController Instance;
    public PopupHome _popupHome;
    public PopupGamePlay _popupGamePlay;
    public PopupChoice _popupChoice;
    public void Init()
    {
        Instance = this;
        gameObject.SetActive(true);
    }
    public void ShowPopupChoice(bool _show = true)
    {
        if (_show)
        {
            _popupChoice.Show();
        }
        else
        {
            _popupChoice.Hide();
        }
    }
    public void ShowPopupHome(bool _show = true)
    {
        if (_show)
        {
            _popupHome.Show();
        }
        else
        {
            _popupHome.Hide();
        }
    }
    public void ShowPopupGamePlay(bool _show = true)
    {
        if (_show)
        {
            _popupGamePlay.Show();
        }
        else
        {
            _popupGamePlay.Hide();
        }
    }
}
