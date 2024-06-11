using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupWinGame : PopupBase
{

    [Header(" ______ Button  _____ "), Space(20)]

    public ButtonBase _btnHome;
    public ButtonBase _btnContinue;
    public ButtonBase _btnReplay;

    [Header(" ______ Data  _____ "), Space(20)]

    public GameObject _parentItemsReward;
    public GameObject _PrefItemUi;
    List<ItemUi> _ListItemUi = new List<ItemUi>();
    List<Reward> rewards;

    protected override void Awake()
    {
        base.Awake();
        _btnHome.AddEvent(OnClickButtonHome);
        _btnContinue.AddEvent(OnClickButtonContinue);
        _btnReplay.AddEvent(OnClickButtonReplay);

        InstantiateItems();
    }
    public override void Show(object data = null)
    {
        base.Show(data);
        _isShow = true;
        rewards = (List<Reward>)data;
        LoadReward();
    }
    public override void Hide()
    {
        _isShow = false;
        base.Hide();

    }
    void InstantiateItems()
    {
        for (int i = 0; i < 6; i++)
        {
            ItemUi obj = Instantiate(_PrefItemUi, _parentItemsReward.transform).GetComponent<ItemUi>();
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(_parentItemsReward.transform);
            obj.transform.localScale = Vector3.one;
            _ListItemUi.Add(obj);
        }
    }
    public void LoadReward()
    {
        if (_ListItemUi.Count < 0)
            InstantiateItems();

        foreach (var itemUi in _ListItemUi)
        {
            itemUi.gameObject.SetActive(false);
        }
        for (int i = 0; i < rewards.Count; i++)
        {
            _ListItemUi[i].gameObject.SetActive(true);
            _ListItemUi[i].Init(rewards[i]._ItemSO, rewards[i]._valuesRw);
        }
    }
    public void OnClickTakeReward()
    {
        foreach (Reward reward in rewards)
        {
            TakeReward(reward);
        }
    }
    void TakeReward(Reward reward)
    {
        switch (reward._ItemSO.so_typeItem)
        {
            case TypeItem.gold:
                UserData.GoldGame += reward._valuesRw;
                break;
            case TypeItem.gem:
                UserData.GemGame += reward._valuesRw;
                break;
            case TypeItem.none:
                InventoreManager.Instance.AddItem(reward._ItemSO, reward._valuesRw);
                break;

        }
    }
    public void OnClickButtonHome()
    {
        if (!_isShow)
        {
            return;
        }
        OnClickTakeReward();
        Hide();
        PopupController.Instance.ShowPopup(TypePopup.PopupHome);
        CanvasManager.Instance._Bg.SetActive(true);
    }
    public void OnClickButtonContinue()
    {
        if (!_isShow)
        {
            return;
        }
        OnClickTakeReward();
        Hide();
        GameManager.Instance.UpdateLevelGame(1);
        // lấy level tiếp theo
        GameManager._dataCurLevel = GameManager.Instance.GetDataLevel(GameManager.Instance._currentLevel);
        PopupController.Instance.ShowPopup(TypePopup.PopupGamePlay);
        GameManager.Instance.StartLevelGame();

    }
    public void OnClickButtonReplay()
    {
        if (!_isShow)
        {
            return;
        }
        OnClickTakeReward();
        Hide();
        PopupController.Instance.ShowPopup(TypePopup.PopupGamePlay);

        GameManager.Instance.StartLevelGame();

    }


}
