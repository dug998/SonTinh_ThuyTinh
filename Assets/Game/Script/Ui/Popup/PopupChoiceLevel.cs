﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupChoiceLevel : PopupBase
{

    [Header(" ____ Button ___ "), Space(20)]

    public ButtonBase _btnBackHome;
    public ButtonBase _btnPlay;

    [Header(" ____ Level ____"), Space(30)]

    public List<ButtonLevelUi> _listLevelUi;

    bool _canPlay;
    protected override void Awake()
    {
        base.Awake();
        _btnPlay.AddEvent(OnClickButtonPlay);
        _btnBackHome.AddEvent(OnClickButonBackHome);
    }
    public override void Show(object data = null)
    {
        base.Show(data);
        Init();
    }
    public void Init()
    {
        LoadDataLevel();
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
        PopupController.Instance.ShowPopup(TypePopup.PopupChoiceHero);

    }
    void OnClickButonBackHome()
    {
        _canPlay = false;
        Hide();
        PopupController.Instance.ShowPopup(TypePopup.PopupHome);
    }
    #endregion

    #region Level Button
    public void LoadDataLevel()
    {
        List<DataLevel> dataLevel = GameManager.Instance._dataLevels.dataLevels;
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
        Debug.Log(" chọn level ");
        _canPlay = true;
        _btnPlay.Activity(_canPlay);
        GameManager._dataCurLevel = Data;
        //  _backButton.SetActive(true);
        Debug.Log("Level: " + Data._id);
    }
    #endregion
}
