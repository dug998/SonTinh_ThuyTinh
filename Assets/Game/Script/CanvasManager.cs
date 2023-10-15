using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;
    public ButtonController _buttonController;
    public PopupController _popupController;
    private void Awake()
    {
        Instance = this;
        _buttonController.Init();
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
