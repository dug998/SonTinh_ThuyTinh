using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DailyRewardSO", menuName = "Game/DailyRewardSO")]
public class DailyRewardSO : ScriptableObject
{
    public List<Reward> _dataRewardDays;
    public Sprite _iconGold, _iconGem;
    private void OnValidate()
    {
        int dem = 5;
        foreach (Reward reward in _dataRewardDays)
        {
            if (reward.typeReward == TypeReward.gold)
            {
                reward._spIcon = _iconGold;
            }
            else if (reward.typeReward == TypeReward.gem)
            {
                reward._spIcon = _iconGem;
            }
            reward.valuesRw = 40 + dem;
            dem += 5;
        }
    }
}
