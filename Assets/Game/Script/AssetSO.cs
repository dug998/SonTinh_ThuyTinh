using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetSO : MonoBehaviour
{
    public static AssetSO Instance;
    public DataRewardDaily _dataRewardDailyMonth;
    public DataHeroGames _dataHeroGames;
    public List<DataEquipItem> _dataEquipItems;
    private void Awake()
    {
        Instance = this;
    }
}
