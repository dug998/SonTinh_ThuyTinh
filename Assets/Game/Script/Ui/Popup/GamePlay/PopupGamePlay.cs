using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupGamePlay : PopupBase
{
    public static Vector2 _posCoin = Vector2.zero;

    [Header(" ____ Coin ____ ")]

    public Text _txtCoin;
    public static int _curCoins;
    [SerializeField] GameObject _parentCoin;

    [Header("___ Card Battle ____ "), Space(30)]

    public List<ButtonBattleCardUi> _listBattleCardUi;

    public StageInfoCurrent _stageInfoCurrent;

    public override void Show(object data = null)
    {
        _posCoin = _parentCoin.transform.position;
        CanvasManager.Instance._Bg.SetActive(false);
        base.Show(data);
        _curCoins = 0;
        UpdateTextCoin(_curCoins);
        // GameManager._targetCoin = _parentCoin.transform;
        LoadBattleCard();
        HomeTower.Instance.Born();
    }
    public override void Hide()
    {
        base.Hide();
    }
    private void OnEnable()
    {
        GameEvent.changeCoin += UpdateTextCoin;
    }
    private void OnDisable()
    {
        GameEvent.changeCoin -= UpdateTextCoin;
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
        ButtonCardUi[] dataCards = GameManager._CardChoiseBattle.ToArray();
        foreach (var cardUi in _listBattleCardUi)
        {
            cardUi.Hide();
        }
        for (int i = 0; i < dataCards.Length; i++)
        {
            ButtonBattleCardUi ui = _listBattleCardUi[i];
            DataCard data = dataCards[i]._data;
            ui.Show();
            ui.Init(data);
        }
    }
}
