using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;
    public PopupController _popupController;
    public void Init()
    {
        Instance = this;
        _popupController.Init();
    }
    public void StartGame()
    {
        _popupController.ShowPopupChoice(true);
        _popupController.ShowPopupHome(false);
    }
    public void PlayGame()
    {
        _popupController.ShowPopupChoice(false);
        _popupController.ShowPopupGamePlay(true);
        GameManager.Instance.StartGame();
    }
}
