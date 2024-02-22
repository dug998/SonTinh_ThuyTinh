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
    public int _maxNumberCardBattle
    {
        get { return PrefData.maxNumberCardBattle; }
        set { PrefData.maxNumberCardBattle = value; }

    }

    public static DataLevel _dataLevelGame;
    public static GameState _gameState;
    public static Transform _targetCoin;
    public static int curCoin;


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

        _curLevelGame.GetComponent<GameLevel>().Init();

    }
    public void UpdateCoin(int values)
    {
        curCoin += values;
        GameEvent.changeCoin?.Invoke(curCoin);
    }
    public bool CheckEnoughCoin(int values)
    {
        return curCoin >= values;
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

                if (touch.phase == TouchPhase.Began)
                {

                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                    Collider2D hitCollider = Physics2D.OverlapPoint(touchPosition);

                    if (hitCollider != null && hitCollider.gameObject.CompareTag("Gold"))
                    {
                        hitCollider.GetComponent<Coin>()?.TakeCoin(PopupGamePlay._posCoin);
                    }
                }
            }
        }

    }
    public void WinGame()
    {
        _gameState = GameState.GAME_OVER;

        PopupController.Instance.ShowPopupGamePlay(false);
        PopupController.Instance.ShowPopupWinGame(true);
    }
}
public enum GameState
{
    MENU,
    PLAYING,
    PAUSED,
    GAME_OVER,
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
        GameManager.Instance.UpdateCoin(200);
    }

}
#endif