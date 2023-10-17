using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static Queue<DataCard> _CardChoiseBattle = new Queue<DataCard>();
    public static ButtonBattleCardUi _curBattleCard;
    public static GameState _gameState;
    public static Transform _targetCoin;
    public int _maxNumberCardBattle = 3;
    public static int curCoin;

    public Grounds _grounds;
    public FactoryCoin _factoryCoin;
    [SerializeField] SpawnThuyTinh _pawnThuyTinh;
    public void Awake()
    {
        Instance = this;
    }
    public void StartGame()
    {
        _gameState = GameState.PLAYING;
        _grounds.SpawnBlocks();
        _factoryCoin.SpawnCoins();
        StartCoroutine(_pawnThuyTinh.CreateArmyList());

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