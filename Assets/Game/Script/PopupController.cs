using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    public static PopupController Instance;
    public PopupLoading _popupLoading;
    public PopupHome _popupHome;


    public PopupChoice _popupChoice;
    public PopupGamePlay _popupGamePlay;
    public PopupWinGame _popupWinGame;

    public void ShowHome()
    {

    }
    public void ShowGame()
    {

    }
    public void Init()
    {
        Instance = this;
        gameObject.SetActive(true);
    }
    public void ShowPopupLoading(bool _show = true, object data = null)
    {
        if (_show)
        {
            _popupLoading.Show(data);
        }
        else
        {
            _popupLoading.Hide();
        }

    }
    public void ShowPopupChoice(bool _show = true, object data = null)
    {
        if (_show)
        {
            _popupChoice.Show(data);
        }
        else
        {
            _popupChoice.Hide();
        }
    }
    public void ShowPopupHome(bool _show = true, object data = null)
    {
        if (_show)
        {
            _popupHome.Show(data);
        }
        else
        {
            _popupHome.Hide();
        }
    }
    public void ShowPopupGamePlay(bool _show = true, object data = null)
    {
        if (_show)
        {
            _popupGamePlay.Show(data);
        }
        else
        {
            _popupGamePlay.Hide();
        }
    }
    public void ShowPopupWinGame(bool _show = true, object data = null)
    {
        if (_show)
        {
            _popupWinGame.Show(data);
        }
        else
        {
            _popupWinGame.Hide();
        }
    }
}
