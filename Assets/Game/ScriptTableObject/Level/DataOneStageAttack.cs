using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DataOneStage", menuName = "Game/DataOneStageAttack")]
public class DataOneStageAttack : ScriptableObject
{
    public int _level;
    public int _numberMonter;
    public int _nextTime = 10;
    public List<ObjectBase> _typeMonsters;
    public GameObject GetTypeObjRandom()
    {
        return _typeMonsters[Random.Range(0, _typeMonsters.Count)].gameObject;
    }
    //private void OnValidate()
    //{
    //    int numberMonter = _numberMonter;
    //    int numberGameObject = _monsters.Count;

    //    if (_level < 0)
    //    {
    //        _level = 1;
    //    }
    //    numberMonter = _level;
    //    numberGameObject = _level;
    //    //if (_level < 5)
    //    //{
    //    //    numberMonter = Mathf.Clamp(numberMonter, 1, 5);
    //    //    numberGameObject = Mathf.Clamp(numberGameObject, 1, 2);
    //    //}
    //    //else if (_level < 10)
    //    //{
    //    //    numberMonter = Mathf.Clamp(numberMonter, 4, 10);
    //    //    numberGameObject = Mathf.Clamp(numberGameObject, 2, 4);
    //    //}

    //    _numberMonter = numberMonter;
    //    _monsters.RemoveRange(numberGameObject, _monsters.Count - numberGameObject);

    //}
}