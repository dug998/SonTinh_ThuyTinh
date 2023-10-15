using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static Queue<DataCard> _CardChoiseBattle = new Queue<DataCard>();
    public static DataCard _CardSelect;
    public static GameState _gameState;
    public static Transform _targetCoin;
    public int _maxNumberCardBattle = 3;
    public static int curCoin;

    public Grounds _grounds;
    public FactoryCoin _factoryCoin;
    public void Awake()
    {
        Instance = this;
    }
    public void StartGame()
    {
        _gameState = GameState.PLAYING;
        _grounds.SpawnBlocks();
        _factoryCoin.SpawnCoins();
    }
    public void UpdateCoin(int values)
    {
        curCoin += values;
        GameEvent.changeCoin?.Invoke(curCoin);
    }
    public void AddCardBattle(DataCard card)
    {
        if (_CardChoiseBattle.Count > _maxNumberCardBattle)
        {
            _CardChoiseBattle.Dequeue();

        }
        _CardChoiseBattle.Enqueue(card);
    }
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Coin obj = hit.collider.GetComponent<Coin>();
            if (obj != null)
            {
                obj.TakeCoin(_targetCoin.position);
            }

        }

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
}