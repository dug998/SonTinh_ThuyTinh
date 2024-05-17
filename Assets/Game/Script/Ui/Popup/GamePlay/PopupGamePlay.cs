using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopupGamePlay : PopupBase
{

    public static Vector2 _posCoin = Vector2.zero;
    public static ButtonBattleHeroUi _curBattleCard;
    public GameObject _objFocus;
    [Header(" ____ Coin ____ ")]

    public TextMeshProUGUI _txtCoin;
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
        _curBattleCard = null;
        SetFocus();
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
        EventGame.changeCoin += UpdateTextCoin;
    }
    public void OnDisable()
    {
        EventGame.changeCoin -= UpdateTextCoin;
    }
   
    public void SetFocus()
    {
        _objFocus.SetActive(_curBattleCard != null);
        if (_curBattleCard != null)
        {
            _curBattleCard.SetFocus(_objFocus);
        }

    }
    public void UpdateTextCoin(int values)
    {
        _txtCoin.text = values.ToString();
    }
    public static void UpdateCoin(int values)
    {
        _curCoins += values;

        EventGame.changeCoin?.Invoke(_curCoins);
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
            HeroProfile data = dataCards[i]._heroProfile;
            ui.Show();
            ui.Init(data);
        }
    }
}
