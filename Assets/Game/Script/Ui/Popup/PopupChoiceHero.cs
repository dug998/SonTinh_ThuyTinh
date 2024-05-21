using Sirenix.OdinInspector;
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

    public List<ButtonHeroUi> _listCardUi;

    [Header(" ____ Slot ____ "), Space(30)]
    public List<HeroSlotUi> _listHeroSlotUi;
    [Header(" ____ Hero ____ ")]
    public HeroesInfoUi _heroesInfo;
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
        _maxCurrentSlot = UserData.maxNumberHeroBattle;
        base.Show(data);
        if (_HeroChoiseBattle.Count > 0)
            _HeroChoiseBattle.Clear();
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
        PopupController.Instance.ShowPopup(TypePopup.PopupGamePlay);
        GameManager.Instance.StartLevelGame();
    }
    void OnClickButonBackHome()
    {
        _canPlay = false;
        Hide();
        PopupController.Instance.ShowPopup(TypePopup.PopupHome);
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
        List<HeroProfile> dataHeroProfile = HeroManager.Instance._heroProfiles;
        foreach (var ui in _listCardUi)
        {
            ui.Hide();
        }
        for (int i = 0; i < dataHeroProfile.Count; i++)
        {
            ButtonHeroUi ui = _listCardUi[i];
            HeroProfile data = dataHeroProfile[i];
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
            HeroProfile _heroProfile = dataCards[i]._heroProfile;
            if (_heroProfile != null && _currentSlot < _maxCurrentSlot)
            {
                _currentSlot += 1;
            }
            HeroSlotUi card = _listHeroSlotUi[i];
            card.UpdateData(_heroProfile.dataHero);
            card.Show();
        }
        if (_currentSlot == _maxCurrentSlot)
        {
            Debug.Log(" Full Slot" + _currentSlot + "_" + _maxCurrentSlot);

            _canPlay = true;
            _btnPlay.Activity(_canPlay);
        }
        Debug.Log(" Slot" + _currentSlot + "_" + _maxCurrentSlot);
    }
    #endregion


    public void AddCardBattle(ButtonHeroUi card)
    {
        if (_HeroChoiseBattle.Count >= _maxCurrentSlot)
        {
            Debug.Log("remove card");
            ButtonHeroUi btnCard = _HeroChoiseBattle.Dequeue();
            btnCard.SetSelected(false);

        }
        _HeroChoiseBattle.Enqueue(card);

    }
}
