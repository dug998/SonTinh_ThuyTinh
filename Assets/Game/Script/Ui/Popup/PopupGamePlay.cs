using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupGamePlay : PopupBase
{
    public static Vector2 _posCoin = Vector2.zero;
    [Header(" ____ Coin ____ ")]
    public Text _txtCoin;
    public GameObject _parentCoin;
    [Header("___ Card Battle ____ "), Space(30)]
    public List<ButtonBattleCardUi> _listBattleCardUi;
    public override void Show(object data = null)
    {
        _posCoin = _parentCoin.transform.position;
        CanvasManager.Instance._Bg.SetActive(false);
        base.Show(data);
        UpdateTextCoin(GameManager.curCoin);
        GameManager._targetCoin = _parentCoin.transform;
        LoadBattleCard();
    }
    public override void Hide()
    {
        CanvasManager.Instance._Bg.SetActive(true);
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
    public void LoadBattleCard()
    {
        DataCard[] dataCards = GameManager._CardChoiseBattle.ToArray();
        foreach (var cardUi in _listBattleCardUi)
        {
            cardUi.Hide();
        }
        for (int i = 0; i < dataCards.Length; i++)
        {
            ButtonBattleCardUi ui = _listBattleCardUi[i];
            DataCard data = dataCards[i];
            ui.Show();
            ui.Init(data);
        }
    }
}
