using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupReward : PopupBase
{
    public ButtonUi _btnClaim;
    public GameObject _parentItemsReward;
    public GameObject _PrefItemUi;
    List<ItemUi> _ListItemUi;
    List<Reward> rewards;
    protected override void Awake()
    {
        base.Awake();
        _btnClaim.AddEvent(() =>
        {
            OnClickTakeReward();
            Hide();
        });
        for (int i = 0; i < 6; i++)
        {
            ItemUi obj = Instantiate(_PrefItemUi, _parentItemsReward.transform).GetComponent<ItemUi>();
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(_parentItemsReward.transform);
            obj.transform.localScale = Vector3.one;
            _ListItemUi.Add(obj);
        }
    }

    public override void Show(object data = null)
    {
        rewards = (List<Reward>)data;
        if (rewards == null)
        {
            LogGame.LogError("Null rewards !");
            PopupController.Instance.ShowPopup(TypePopup.PopupNotife, new DataMessage(TypeMessage.Error, "", " Null rewards !"));
            return;
        }
        base.Show(data);
        _btnClaim.Hide();
        DOVirtual.DelayedCall(2, () =>
        {
            _btnClaim.Show();
        });
        LoadReward();
    }
    public void LoadReward()
    {
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
}
