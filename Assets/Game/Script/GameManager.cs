using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public CanvasManager _canvasManager;
    [Header(" ----  DATA --- ")]
    public DataLevelGame _dataLevels;

    public static DataLevel _dataCurLevel;
    public static GameState _gameState;

    [Header(" ___ Pref __ "), Space(20)]
    public GameObject _prefLeveGame;
    public GameLevel _curLevelGame;
    public void Awake()
    {
        Instance = this;

        _canvasManager.Init();
        _gameState = GameState.MENU;
    }
    public void StartLevelGame()
    {
        _gameState = GameState.PLAYING;
        if (_curLevelGame != null)
            Destroy(_curLevelGame.gameObject);
        _curLevelGame = Instantiate(_prefLeveGame, transform).GetComponent<GameLevel>();

        _curLevelGame.GetComponent<GameLevel>().Init(_dataCurLevel);

    }


    public void EndGame(GameState state)
    {
        _gameState = state;
        PopupController.Instance.HidePopup(TypePopup.PopupWinGame);
        if (state == GameState.WIN_GAME)
        {

            PopupController.Instance.ShowPopup(TypePopup.PopupWinGame);
        }
        else if (state == GameState.LOSE_GAME)
        {
            PopupController.Instance.ShowPopup(TypePopup.PopupLose);
        }

    }
}
public enum GameState
{
    MENU,
    PLAYING,
    PAUSED,
    GAME_OVER,
    WIN_GAME,
    LOSE_GAME
}
public class ObjTag
{
    public const string sonTinh = "sonTinh";
    public const string thuyTinh = "thuyTinh";
    public const string deadZone = "DeadZone";
}
#if UNITY_EDITOR


public static class Pref
{
    [MenuItem("player_pref/clear_all")]
    public static void clear_all()
    {
        PlayerPrefs.DeleteAll();
    }

    [MenuItem("player_pref/add_coin")]
    public static void AddCoin()
    {
        PopupGamePlay.UpdateCoin(200);
    }

}
#endif