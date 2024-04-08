using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataReward", menuName = "Game/DataReward")]
public class DataRewardDaily : ScriptableObject
{
    public List<DataRewardDay> _dataRewardDays;
}
[System.Serializable]
public class DataRewardDay
{
    public TypeReward typeReward;   
    public int valuesRw;
}
public enum TypeReward
{
    coin,

}
