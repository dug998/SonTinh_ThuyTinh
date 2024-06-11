using Sirenix.OdinInspector;
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

    [Header(" ___  __ "), Space(20)]
    public GameObject _prefLeveGame;

    public int _currentLevel
    {
        get { return UserData.CurrentLevel; }
        set
        {
            if (value <= 0)
            {
                value = 1;
            }
            UserData.CurrentLevel = value;
        }
    }
    public int _maxLevelUnlock
    {
        get { return UserData.MaxLevelUnlock; }
        set
        {
            if (value <= 0)
            {
                value = 1;
            }
            UserData.MaxLevelUnlock = value;
        }
    }
    public static int _maxLevelGame = 20;
    [ReadOnly] public GameLevel _curGameLevel { get; private set; }
    public void Awake()
    {
        Instance = this;

        _canvasManager.Init();
        _gameState = GameState.MENU;
    }
    public void StartLevelGame()
    {
        _gameState = GameState.PLAYING;
        if (_curGameLevel != null)
            Destroy(_curGameLevel.gameObject);
        _curGameLevel = Instantiate(_prefLeveGame, transform).GetComponent<GameLevel>();

        _curGameLevel.GetComponent<GameLevel>().Init(_dataCurLevel);

    }


    public void EndGame(GameState state)
    {
        _gameState = state;

        if (state == GameState.WIN_GAME)
        {

            PopupController.Instance.ShowPopup(TypePopup.PopupWinGame, _dataCurLevel._itemsRewards);
        }
        else if (state == GameState.LOSE_GAME)
        {
            PopupController.Instance.ShowPopup(TypePopup.PopupLose);
        }

    }
    public void UpdateLevelGame(int add)
    {
        _currentLevel += add;

        if (_currentLevel > _maxLevelUnlock)
        {
            _maxLevelUnlock = _currentLevel;
        }
        if (_currentLevel > _maxLevelGame || _maxLevelUnlock > _maxLevelGame)
        {

            _maxLevelUnlock = _maxLevelGame;
            _currentLevel = _maxLevelGame;
        }
        Debug.Log(_currentLevel + " _ " + _maxLevelUnlock);
    }
    public DataLevel GetDataLevel(int index)
    {
        Debug.Log("eve :" + index);
        return _dataLevels.GetDataLevel(index - 1);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
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


public static class Cheat
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