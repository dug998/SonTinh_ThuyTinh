using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupDailyMonth : PopupBase
{
    List<DataRewardDay> dataRewardDailys;
    public GameObject _parentReward;
    public RewardDay _prefabRewardDay;
    List<RewardDay> rewardDays;

    RewardDay _currRewardDay;
    public Button _btnClaim;
    protected override void Awake()
    {

        base.Awake();
        dataRewardDailys = AssetSO.Instance._dataRewardDailyMonth._dataRewardDays;
        LoadData();
        _btnClaim.onClick.AddListener(OnClickClam);
    }
    public override void Show(object data = null)
    {
        base.Show(data);
        UpdateDataReward();
    }
    public void LoadData()
    {
        DataRewardDay day;
        for (int i = 0; i < dataRewardDailys.Count; i++)
        {
            RewardDay rewardUi=Instantiate(_prefabRewardDay, _parentReward.transform);
            day = dataRewardDailys[i];
            rewardUi.Init(i, day);
            rewardDays.Add(rewardUi);
        }
    }
    public void UpdateDataReward()
    {
        int index = 0;
        RewardDay day;
        for (int i = 0; i < rewardDays.Count; i++)
        {
            day = rewardDays[i];
            if (i < index)
            {
                day.UpdateStatus(statusReward.Claimed);
            }
            else if (i == index)
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
    public void OnClickClam()
    {
        if (_currRewardDay == null)
        {
            Debug.Log("There are no reward to receive ");
            return;
        }
        _currRewardDay.UpdateStatus(statusReward.Claimed);
        _currRewardDay = null;
    }
}
