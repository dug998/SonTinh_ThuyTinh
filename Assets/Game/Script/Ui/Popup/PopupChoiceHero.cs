using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupChoiceHero : PopupBase
{
    public static Queue<ButtonHeroUi> _HeroChoiseBattle = new Queue<ButtonHeroUi>();

    [Header("")]
    int _currentSlot = 0;
    int _maxCurrentSlot = 6;
    [Header(" ____ Button ___ "), Space(20)]

    public ButtonBase _btnBackHome;
    public ButtonBase _btnPlay;

    [Header(" ____ Card Hero ____ "), Space(30)]

    public DataHeroGames _dataHeros;
    public List<ButtonHeroUi> _listCardUi;

    [Header(" ____ Slot ____ "), Space(30)]
    public List<HeroSlotUi> _listHeroSlotUi;
    [Header(" ____ Hero ____ ")]
    public HeroesInfo _heroesInfo;
    bool _canPlay;
    protected override void Awake()
    {
        base.Awake();
        _HeroChoiseBattle = new Queue<ButtonHeroUi>();

        _btnPlay.AddEvent(OnClickButtonPlay);
        _btnBackHome.AddEvent(OnClickButonBackHome);
    }
    public override void Show(object data = null)
    {
        _maxCurrentSlot = PrefData.maxNumberHeroBattle;
        base.Show(data);
        if (_HeroChoiseBattle.Count > 0)
            _HeroChoiseBattle.Clear();
        _currentSlot = 0;
        Init();
    }
    public void Init()
    {
        CloseDataHeroSlotUi();
        LoadDataCard();
        _canPlay = false;
        _btnPlay.Activity(_canPlay);
    }

    #region On Click

    void OnClickButtonPlay()
    {
        if (!_canPlay)
        {
            return;
        }
        Hide();
        PopupController.Instance.ShowPopupGamePlay(true);
        GameManager.Instance.StartLevelGame();
    }
    void OnClickButonBackHome()
    {
        _canPlay = false;
        Hide();
        PopupController.Instance.ShowPopupHome(true);
    }
    #endregion
    #region Slot Hero

    public void CloseDataHeroSlotUi()
    {
        _currentSlot = 0;
        for (int i = 0; i < _listHeroSlotUi.Count; i++)
        {
            _listHeroSlotUi[i].Init(i >= _maxCurrentSlot);

        }
    }
    #endregion

    #region Hero Button
    public void LoadDataCard()
    {
        List<DataHero> dataHero = _dataHeros.dataHeros;
        foreach (var ui in _listCardUi)
        {
            ui.Hide();
        }
        for (int i = 0; i < dataHero.Count; i++)
        {
            ButtonHeroUi ui = _listCardUi[i];
            DataHero data = dataHero[i];
            ui.Show();
            ui.Init(data);
            ui.RemoveAll();
            ui.AddEvent(() => ui.ChooseHero());

        }

    }
    public void ChooseHero(ButtonHeroUi btnUi)
    {
        AddCardBattle(btnUi);

        ButtonHeroUi[] dataCards = _HeroChoiseBattle.ToArray();
        for (int i = 0; i < dataCards.Length; i++)
        {
            DataHero data = dataCards[i]._data;
            if (data != null && _currentSlot < _maxCurrentSlot)
            {
                _currentSlot++;
            }
            HeroSlotUi card = _listHeroSlotUi[i];
            card.UpdateData(data);
            card.Show();
        }
        if (_currentSlot == _maxCurrentSlot)
        {
            Debug.Log(" Full Slot");

            _canPlay = true;
            _btnPlay.Activity(_canPlay);
        }

    }
    #endregion


    public void AddCardBattle(ButtonHeroUi card)
    {
        if (_HeroChoiseBattle.Count >= PrefData.maxNumberHeroBattle)
        {
            Debug.Log("remove card");
            ButtonHeroUi btnCard = _HeroChoiseBattle.Dequeue();
            btnCard.SetSelected(false);

        }
        _HeroChoiseBattle.Enqueue(card);

    }
}
