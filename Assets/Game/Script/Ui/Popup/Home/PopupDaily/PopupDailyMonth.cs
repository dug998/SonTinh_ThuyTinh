using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupDailyMonth : PopupBase
{

    List<Reward> dataRewardDailys;
    public GameObject _parentReward;
    public RewardDay _prefabRewardDay;
    List<RewardDay> rewardDays;

    RewardDay _currRewardDay;
    public ButtonUi _btnClaim;
    protected override void Awake()
    {
        base.Awake();
        rewardDays = new List<RewardDay>();
        dataRewardDailys = AssetSO.Instance._dataRewardDailyMonth._dataRewardDays;
        LoadData();
        _btnClaim.AddEvent(OnClickClaim);
    }
    public override void Show(object data = null)
    {
        base.Show(data);
        _btnClaim.Activity(!DailyGameManager.ReceivedDailyPrize);
        UpdateDataReward();
    }
    public void LoadData()
    {
        Reward day;
        int numberDayMonth = DateTimeManager.GetDaysInCurrentMonth();
        for (int i = 0; i < numberDayMonth; i++)
        {
            RewardDay rewardUi = Instantiate(_prefabRewardDay, _parentReward.transform);
            day = dataRewardDailys[i];
            rewardUi.Init(i, day);
            rewardDays.Add(rewardUi);
        }
    }
    public void UpdateDataReward()
    {
        int pos = DailyGameManager.DailyPrizePosition;
        RewardDay day;
        for (int i = 0; i < rewardDays.Count; i++)
        {
            day = rewardDays[i];
            if (i < pos)
            {
                day.UpdateStatus(statusReward.Claimed);
            }
            else if (i == pos)
            {
                day.UpdateStatus(statusReward.Available);
                _currRewardDay = day;
            }
            else
            {
                day.UpdateStatus(statusReward.Locked);
            }
        }
    }

    public void OnClickClaim()
    {
        if (_currRewardDay == null)
        {
            Debug.Log("There are no reward to receive ");
            return;
        }
        if (DailyGameManager.ReceivedDailyPrize)
        {
            _currRewardDay = null;
            Debug.Log("Received prize today ");
            return;
        }

        DailyGameManager.ReceivedDailyPrize = true;
        _currRewardDay.UpdateStatus(statusReward.Claimed);
        _currRewardDay.GetReward();
        _currRewardDay = null;
        _btnClaim.Activity(!DailyGameManager.ReceivedDailyPrize);
    }

}
