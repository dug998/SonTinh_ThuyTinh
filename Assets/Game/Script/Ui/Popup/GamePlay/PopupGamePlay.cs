using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopupGamePlay : PopupBase
{

    public static Vector2 _posCoin = Vector2.zero;
    public static ButtonBattleHeroUi _curBattleCard;
    [Header(" ____ Coin ____ ")]

    public Text _txtCoin;
    public static int _curCoins;
    [SerializeField] GameObject _parentCoin;

    [Header("___ Card Battle ____ "), Space(30)]

    public List<ButtonBattleHeroUi> _listBattleCardUi;

    public StageInfoCurrent _stageInfoCurrent;
    protected override void Awake()
    {
        base.Awake();


    }
    public override void Show(object data = null)
    {
        _posCoin = _parentCoin.transform.position;
        CanvasManager.Instance._Bg.SetActive(false);
        base.Show(data);
        _curCoins = 0;

        // GameManager._targetCoin = _parentCoin.transform;
        LoadBattleCard();
        HomeTower.Instance.Born();
        UpdateCoin(0);
    }
    public override void Hide()
    {
        base.Hide();
    }
    public void OnEnable()
    {
        GameEvent.changeCoin += UpdateTextCoin;
    }
    public void OnDisable()
    {
        GameEvent.changeCoin -= UpdateTextCoin;
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null && hit.collider.CompareTag("Gold"))
        {
            hit.collider.GetComponent<Coin>()?.TakeCoin(_posCoin);
        }




    }
    public void UpdateTextCoin(int values)
    {
        _txtCoin.text = values.ToString();
    }
    public static void UpdateCoin(int values)
    {
        _curCoins += values;

        GameEvent.changeCoin?.Invoke(_curCoins);
    }
    public static bool CheckEnoughCoin(int values)
    {
        return _curCoins >= values;
    }
    public void LoadBattleCard()
    {
        ButtonHeroUi[] dataCards = PopupChoiceHero._HeroChoiseBattle.ToArray();
        foreach (var cardUi in _listBattleCardUi)
        {
            cardUi.Hide();
        }
        for (int i = 0; i < dataCards.Length; i++)
        {
            ButtonBattleHeroUi ui = _listBattleCardUi[i];
            DataHero data = dataCards[i]._data;
            ui.Show();
            ui.Init(data);
        }
    }
}
