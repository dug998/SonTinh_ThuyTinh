using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupGamePlay : PopupBase
{
    [Header(" ____ Coin ____ ")]
    public Text _txtCoin;
    public GameObject _parentCoin;
    [Header("___ Card Battle ____ "), Space(30)]
    public List<ButtonBattleCardUi> _listBattleCardUi;
    public override void Show(object data = null)
    {
        base.Show(data);
        GameManager._targetCoin = _parentCoin.transform;
        LoadBattleCard();
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
