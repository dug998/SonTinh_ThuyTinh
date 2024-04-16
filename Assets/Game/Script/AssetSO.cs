using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetSO : MonoBehaviour
{
    public static AssetSO Instance;
    public DailyRewardSO _dataRewardDailyMonth;
    public DataHeroGames _dataHeroGames;
    public List<EquipItemSO> _dataEquipItems;
    private void Awake()
    {
        Instance = this;
    }
}
