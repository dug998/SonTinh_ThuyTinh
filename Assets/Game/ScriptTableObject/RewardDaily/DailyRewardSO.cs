using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DailyRewardSO", menuName = "Game/DailyRewardSO")]
public class DailyRewardSO : ScriptableObject
{
    public List<Reward> _dataRewardDays;
    public Sprite _iconGold, _iconGem;
    public List<ItemSO> _listItemsSo;
    private void OnValidate()
    {
        int dem = 5;
        foreach (Reward reward in _dataRewardDays)
        {
            ItemSO item = _listItemsSo[Random.Range(0, _listItemsSo.Count)];
            reward._ItemSO = item;
            reward._valuesRw = 40 + dem;
            dem += 5;
        }
    }
}
