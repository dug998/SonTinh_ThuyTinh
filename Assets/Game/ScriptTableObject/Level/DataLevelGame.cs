using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "DataLevelGame", menuName = "Game/DataLevelGame")]
public class DataLevelGame : ScriptableObject
{

    public List<DataLevel> dataLevels = new List<DataLevel>();

    public DataLevel GetDataLevel(int index)
    {
        if (index > dataLevels.Count)
        {
            Debug.Log(" null level index");
            return null;
        }
        return dataLevels[index];
    }
    public int GetIndexLevel(DataLevel level)
    {
        return dataLevels.IndexOf(level);
    }
    public void OnValidate()
    {

        foreach (DataLevel level in dataLevels)
        {
            level.OnValuesChange();
        }
    }

}
[System.Serializable]
public class DataLevel
{
    public int _id;
    public string _title;
    public string _description;

    [PreviewField()]
    public Sprite _spriteiIcon;
    [Header(" ___ data Monter ___ "), Space(30)]
    public int _timeWait = 3;
    public int _numberStageAttack = 1;
    [HideInInspector] public int _numberMaxObj;
    public List<DataOneStageAttack> _dataLevelAttacks;

    [ReadOnly] public List<float> _dataStageInfos;
    public List<Reward> _itemsRewards;
#if UNITY_EDITOR
    public void OnValuesChange()
    {
        if (_numberStageAttack > 5)
        {
            _numberStageAttack = 5;
        }
        if (_dataLevelAttacks.Count < 0)
        {
            _dataLevelAttacks = new List<DataOneStageAttack>(_numberStageAttack);
        }
        else if (_dataLevelAttacks.Count < _numberStageAttack)
        {
            _numberStageAttack = _dataLevelAttacks.Count;

            Debug.Log(" check level " + _id);
        }
        else if (_dataLevelAttacks.Count > _numberStageAttack)
        {
            _numberStageAttack = _dataLevelAttacks.Count;

            Debug.Log(" check level " + _id);
        }
        _dataStageInfos = new List<float>(_numberStageAttack);
        for (int i = 0; i < _dataLevelAttacks.Count; i++)
        {
            _dataStageInfos.Add(0);
        }
        _numberMaxObj = 0;
        foreach (var x in _dataLevelAttacks)
        {
            _numberMaxObj += x._numberMonter;
        }
        float _cur = 0;
        for (int i = 0; i < _dataLevelAttacks.Count; i++)
        {
            _dataStageInfos[i] = ((float)_dataLevelAttacks[i]._numberMonter / _numberMaxObj) + _cur;
            _cur = _dataStageInfos[i];

        }
    }
}
#endif
