using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupChoiceHero : PopupBase
{
    public Queue<DataCard> _CardChoiseBattle = new Queue<DataCard>();
    [Header("")]
    int _currentSlot = 0;
    int _maxCurrentSlot = 6;
    [Header(" ____ Button ___ "), Space(20)]

    public ButtonBase _btnBackHome;
    public ButtonBase _btnPlay;

    [Header(" ____ Card ____ "), Space(30)]

    public DataCardGame _dataCards;
    List<DataCard> dataCard;
    public List<ButtonCardUi> _listCardUi;

    [Header(" ____ Slot ____ "), Space(30)]
    public List<CardSlotUi> _listCardSlotUi;
    [Header(" ____ Hero ____ ")]
    public HeroesInfo _heroesInfo;
    bool _canPlay;
    public void Awake()
    {
        _btnPlay.AddEvent(OnClickButtonPlay);
        _btnBackHome.AddEvent(OnClickButonBackHome);
    }
    public override void Show(object data = null)
    {
        _maxCurrentSlot = GameManager.Instance._maxNumberCardBattle;
        GameManager._CardChoiseBattle.Clear();
        _currentSlot = 0;
        base.Show(data);
        Init();
    }
    public void Init()
    {
        CloseDataCardSlotUi();
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
    #region Slot Card
    public void CloseDataCardSlotUi()
    {
        _currentSlot = 0;
        for (int i = 0; i < _listCardSlotUi.Count; i++)
        {
            _listCardSlotUi[i].Init(i >= _maxCurrentSlot);

        }
    }
    #endregion

    #region Card Button
    public void LoadDataCard()
    {
        dataCard = _dataCards.dataCards;
        foreach (var ui in _listCardUi)
        {
            ui.Hide();
        }
        for (int i = 0; i < dataCard.Count; i++)
        {
            ButtonCardUi ui = _listCardUi[i];
            DataCard data = dataCard[i];
            ui.Show();
            ui.Init(data);
            ui.RemoveAll();
            ui.AddEvent(() => ui.ChooseCard());

        }

    }
    public void ChooseCard(ButtonCardUi btnUi)
    {
        GameManager.Instance.AddCardBattle(btnUi);

        ButtonCardUi[] dataCards = GameManager._CardChoiseBattle.ToArray();
        for (int i = 0; i < dataCards.Length; i++)
        {
            DataCard data = dataCards[i]._data;
            if (data != null && _currentSlot < _maxCurrentSlot)
            {
                _currentSlot++;
            }
            CardSlotUi card = _listCardSlotUi[i];
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

    public void AddCardBattle(DataCard card)
    {
        if (_CardChoiseBattle.Count > _maxCurrentSlot)
        {
            _CardChoiseBattle.Dequeue();

        }
        _CardChoiseBattle.Enqueue(card);
    }
}
