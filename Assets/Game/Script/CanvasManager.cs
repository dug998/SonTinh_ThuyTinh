using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;
    public PopupController _popupController;
    public GameObject _Bg;
    public void Init()
    {
        Instance = this;
        _popupController.Init();
        LoadingGame();
    }
    public void LoadingGame()
    {
        PopupController.Instance.ShowPopup(TypePopup.PopupLoading);

    }



}
