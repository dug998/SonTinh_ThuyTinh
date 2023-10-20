using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThuyTinh : MonoBehaviour
{
    public static SpawnThuyTinh Instance;
    [SerializeField] GameObject _parrent;
    List<Vector2> _location;
    DataLevel _dataLevel;
    public List<ObjectBase> _listMonter;

    private void Awake()
    {
        Instance = this;
    }


    public IEnumerator CreateArmyList()
    {
        _location = Grounds._rowLocation;
        _dataLevel = GameManager._dataLevelGame;
        DataLevelAttack _dataLevelAttack;
        int count = 0;
        yield return new WaitForSeconds(5);
        _listMonter.Clear();
        while (count < _dataLevel._numberLevelAttack)
        {
            count++;
            _dataLevelAttack = _dataLevel._dataLevelAttacks[Random.Range(0, _dataLevel._dataLevelAttacks.Count)];
            for (int i = 0; i < _dataLevelAttack._numberMonter; i++)
            {
                SpawnObj(_dataLevelAttack.GetObjRandom());
                yield return new WaitForSeconds(Random.Range(0, 1));
            }
            yield return new WaitForSeconds(5);
        }

    }
    public void SpawnObj(GameObject mob1)
    {
        int check = Random.Range(0, 5);
        GameObject obj = Instantiate(mob1, new Vector2(_location[check].x, _location[check].y + .5f), Quaternion.identity, _parrent.transform);
        obj.GetComponent<ObjectAttackTT>().Born();
        _listMonter.Add(obj.GetComponent<ObjectBase>());
    }
    public void RemoveMonster(ObjectBase obj)
    {
        _listMonter.Remove(obj);
        CheckWin();
    }
    public void CheckWin()
    {
        if (_listMonter.Count <= 0)
        {
            GameManager.Instance.WinGame();
        }
    }
}
