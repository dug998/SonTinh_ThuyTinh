using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupDailyMonth : PopupBase
{
    public string keyDailyMonth = "KeyLastLoginTime";

    List<DataRewardDay> dataRewardDailys;
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
        UpdateDataReward();
    }
    public void LoadData()
    {
        DataRewardDay day;
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
        int pos = UserData.DailyPrizePosition;
        UpdateButtonClaim();
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
    public void UpdateButtonClaim()
    {
        bool hasOneDay = HasOneDayPassed();
        if (hasOneDay)
        {
            UserData.ReceivedDailyPrize = false;
        }
        _btnClaim.Activity(hasOneDay);
        Debug.Log(hasOneDay);
    }
    public void OnClickClaim()
    {
        if (_currRewardDay == null)
        {
            Debug.Log("There are no reward to receive ");
            return;
        }
        if (UserData.ReceivedDailyPrize)
        {
            _currRewardDay = null;
            Debug.Log("Received prize today ");
            return;
        }

        UserData.ReceivedDailyPrize = true;
        UpdateButtonClaim();
        _currRewardDay.UpdateStatus(statusReward.Claimed);
        _currRewardDay = null;
        UserData.DailyPrizePosition += 1;
    }
    public bool HasOneDayPassed()
    {
        if (!PlayerPrefs.HasKey(keyDailyMonth))
        {
            DateTimeManager.SaveTime(keyDailyMonth, DateTime.Now);
            return true;
        }
        if ((DateTime.Now - DateTimeManager.LoadTime(keyDailyMonth)).TotalMinutes >= 10)
        {
            DateTimeManager.SaveTime(keyDailyMonth, DateTime.Now);
            return true;
        }
        return false;
    }
}
