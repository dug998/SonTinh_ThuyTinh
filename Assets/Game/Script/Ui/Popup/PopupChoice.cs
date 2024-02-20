using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Popup allows level and card selection
/// </summary>
public class PopupChoice : PopupBase
{
    public Queue<DataCard> _CardChoiseBattle = new Queue<DataCard>();
    [Header("")]
    int _currentSlot = 0;
    int _maxSlot = 6;
    [Header(" ____ Button ___ "), Space(20)]

    public ButtonBase _btnBackHome;
    public ButtonBase _btnPlay;

    [Header(" ___ Parrent ___ "), Space(20)]
    public GameObject _levelParent;
    public GameObject _cardParent;
    public GameObject _SlotParent;

    [Header(" ____ Level ____"), Space(30)]

    public DataLevelGame _dataLevels;
    List<DataLevel> dataLevel;
    public List<ButtonLevelUi> _listLevelUi;

    [Header(" ____ Card ____"), Space(30)]

    public DataCardGame _dataCards;
    List<DataCard> dataCard;
    public List<ButtonCardUi> _listCardUi;

    [Header(" ___ Slot ___"), Space(30)]
    public List<CardSlotUi> _listCardSlotUi;

    public void Awake()
    {
        _btnPlay.AddEvent(OnClickButtonPlay);
        _btnBackHome.AddEvent(OnClickButonBackHome);
    }
    public override void Show(object data = null)
    {
        _maxSlot = GameManager.Instance._maxNumberCardBattle;
        base.Show(data);
        Init();
    }
    public void Init()
    {
        _levelParent.SetActive(true);
        _cardParent.SetActive(false);
        _SlotParent.SetActive(false);
        CloseDataCardSlotUi();
        LoadDataLevel();
        LoadDataCard();
    }

    #region On Click

    void OnClickButtonPlay()
    {
        Hide();
        PopupController.Instance.ShowPopupGamePlay(true);
        GameManager.Instance.StartLevelGame();
    }
    void OnClickButonBackHome()
    {
        Hide();
        PopupController.Instance.ShowPopupHome(true);
    }
    #endregion
    #region Slot Card
    public void CloseDataCardSlotUi()
    {
        _currentSlot = 0;
        foreach (var slot in _listCardSlotUi)
        {
            slot.Init();
        }
    }
    #endregion
    #region Level Button
    public void LoadDataLevel()
    {
        dataLevel = _dataLevels.dataLevels;
        foreach (var ui in _listLevelUi)
        {
            ui.Hide();
        }
        for (int i = 0; i < dataLevel.Count; i++)
        {
            ButtonLevelUi ui = _listLevelUi[i];
            DataLevel data = dataLevel[i];
            ui.Show();
            ui.Init(data);
            ui.AddEvent(() => ChooseLevel(data));

        }

    }
    public void ChooseLevel(DataLevel Data)
    {
        _levelParent.SetActive(false);
        _cardParent.SetActive(true);
        _SlotParent.SetActive(true);

        GameManager._dataLevelGame = Data;
        //  _backButton.SetActive(true);
        Debug.Log("Level: " + Data._id);
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
            ui.AddEvent(() => ChooseCard(data._id));

        }

    }
    public void ChooseCard(int chooseCard)
    {

        if (_currentSlot < _maxSlot)
        {
            CardSlotUi card = _listCardSlotUi[_currentSlot];
            DataCard data = dataCard.Find(x => x._id == chooseCard);
            card.UpdateData(data);
            GameManager.Instance.AddCardBattle(data);
            card.Show();
            _currentSlot++;
        }
        else
        {
            Debug.Log(" Full Slot");
        }

    }
    #endregion

    public void AddCardBattle(DataCard card)
    {
        if (_CardChoiseBattle.Count > _maxSlot)
        {
            _CardChoiseBattle.Dequeue();

        }
        _CardChoiseBattle.Enqueue(card);
    }
}
