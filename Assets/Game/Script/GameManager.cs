using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public CanvasManager _canvasManager;
    [Header(" ____  Static ___ ")]
    public static Queue<ButtonCardUi> _CardChoiseBattle;
    public static ButtonBattleCardUi _curBattleCard;
    [Header(" ----  DATA --- ")]
    public DataLevelGame _dataLevels;
    public int _maxNumberCardBattle
    {
        get { return PrefData.maxNumberCardBattle; }
        set { PrefData.maxNumberCardBattle = value; }

    }

    public static DataLevel _dataCurLevel;
    public static GameState _gameState;

    [Header(" ___ Pref __ "), Space(20)]
    public GameObject _prefLeveGame;
    GameObject _curLevelGame;
    public void Awake()
    {
        Instance = this;
        _CardChoiseBattle = new Queue<ButtonCardUi>();
        _canvasManager.Init();
        _gameState = GameState.MENU;
    }
    public void StartLevelGame()
    {
        _gameState = GameState.PLAYING;
        if (_curLevelGame != null)
            Destroy(_curLevelGame);
        _curLevelGame = Instantiate(_prefLeveGame, transform);

        _curLevelGame.GetComponent<GameLevel>().Init(_dataCurLevel);

    }
    public void AddCardBattle(ButtonCardUi card)
    {
        if (_CardChoiseBattle.Count >= _maxNumberCardBattle)
        {
            Debug.Log("remove card");
            ButtonCardUi btnCard = _CardChoiseBattle.Dequeue();
            btnCard.SetSelected(false);

        }
        _CardChoiseBattle.Enqueue(card);

    }
    void Update()
    {

        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);

                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                if (hit.collider != null && hit.collider.CompareTag("Gold"))
                {
                    hit.collider.GetComponent<Coin>()?.TakeCoin(PopupGamePlay._posCoin);
                }

            }
        }

    }
    public void EndGame(GameState state)
    {
        _gameState = state;
        PopupController.Instance.ShowPopupGamePlay(false);
        if (state == GameState.WIN_GAME)
        {

            PopupController.Instance.ShowPopupWinGame(true);
        }
        else if (state == GameState.LOSE_GAME)
        {
            PopupController.Instance.ShowPopupLose(true);
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