using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] Button _btnStart;
    [SerializeField] Button _btnPlay;

    public void Init()
    {
        GameManager._gameState = GameState.MENU;
        gameObject.SetActive(true);
        _btnPlay.onClick.AddListener(OnClickPlay);
        _btnStart.onClick.AddListener(OnClickStart);
        _btnStart.gameObject.SetActive(true);
        _btnPlay.gameObject.SetActive(false);
    }
    public void OnClickPlay()
    {
        CanvasManager.Instance.PlayGame();
        _btnPlay.gameObject.SetActive(false);
    }
    public void OnClickStart()
    {
        CanvasManager.Instance.StartGame();
        _btnStart.gameObject.SetActive(false);
        _btnPlay.gameObject.SetActive(true);
    }
}
