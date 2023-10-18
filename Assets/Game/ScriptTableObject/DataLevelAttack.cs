using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelAttack", menuName = "Game/DataLevelAttack")]
public class DataLevelAttack : ScriptableObject
{
    public int _level;
    public int _numberMonter;
    public List<GameObject> _monsters;
    public GameObject GetObjRandom()
    {
        return _monsters[Random.Range(0, _monsters.Count)];
    }
    private void OnValidate()
    {
        int numberMonter = _numberMonter;
        int numberGameObject = _monsters.Count;

        if (_level < 0)
        {
            _level = 1;
        }
        numberMonter = _level;
        numberGameObject = _level;
        //if (_level < 5)
        //{
        //    numberMonter = Mathf.Clamp(numberMonter, 1, 5);
        //    numberGameObject = Mathf.Clamp(numberGameObject, 1, 2);
        //}
        //else if (_level < 10)
        //{
        //    numberMonter = Mathf.Clamp(numberMonter, 4, 10);
        //    numberGameObject = Mathf.Clamp(numberGameObject, 2, 4);
        //}

        _numberMonter = numberMonter;
        _monsters.RemoveRange(numberGameObject, _monsters.Count - numberGameObject);

    }
}