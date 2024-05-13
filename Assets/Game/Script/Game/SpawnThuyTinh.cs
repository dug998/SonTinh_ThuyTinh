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

    StageInfoCurrent _stageInfoCurrent;

    bool _completeOneStage;
    int _numberCurObj = 0;
    private void Awake()
    {
        Instance = this;
        _stageInfoCurrent = PopupController.Instance._popupGamePlay._stageInfoCurrent;
    }

    /// <summary>
    /// Tạo các giai đoạn trong 1 level
    /// Tiêu diệt hết quái sẽ hoàn thành game 
    /// </summary>
    /// <param name="dataLevel"></param>
    /// <returns></returns>
    public IEnumerator CreateArmyList(DataLevel dataLevel)
    {
        _location = Grounds._rowLocation;
        _dataLevel = dataLevel;
        _stageInfoCurrent.Init(dataLevel._dataStageInfos);
        _stageInfoCurrent.StartLevelNew();
        yield return new WaitForSeconds(_dataLevel._timeWait);

        DataOneStageAttack _dataStage;
        int _indexTurn = 0;
        _numberCurObj = 0;
        _listMonter.Clear();


        while (_indexTurn < _dataLevel._numberStageAttack)
        {
            _stageInfoCurrent.StartOneStage(_indexTurn);
            yield return new WaitForSeconds(4);
            _completeOneStage = false;
            _dataStage = _dataLevel._dataLevelAttacks[_indexTurn];
            StartCoroutine(OneStageAttack(_dataStage, _dataLevel._numberMaxObj));

            yield return new WaitUntil(() => _completeOneStage);
            _stageInfoCurrent.EndOneStage(_indexTurn);

            _indexTurn++;

            yield return new WaitForSeconds(4);
        }
        CompleteLevel();

    }
    public IEnumerator OneStageAttack(DataOneStageAttack data, int _numberMaxObj)
    {

        for (int i = 0; i < data._numberMonter; i++)
        {
            SpawnObj(data.GetTypeObjRandom());
            _numberCurObj++;
            _stageInfoCurrent.OnChangeValuesSliderBar((float)_numberCurObj / _numberMaxObj);
            Debug.Log(" Spawn Obj ");
            yield return new WaitForSeconds(data._nextTime + Random.Range(3, 7));
        }
        yield return new WaitUntil(() => CheckNumberMonterOneStage());
        _completeOneStage = true;
    }

    public void SpawnObj(GameObject mob1)
    {
        int check = Random.Range(0, 5);
        GameObject obj = Instantiate(mob1, new Vector2(_location[check].x + 2, _location[check].y + .2f), Quaternion.identity, _parrent.transform);
        obj.GetComponent<ObjectThuyTinh>().Born();
        _listMonter.Add(obj.GetComponent<ObjectBase>());
    }
    public void SpawnObj(GameObject mob1, Vector2 pos)
    {
        GameObject obj = Instantiate(mob1, pos, Quaternion.identity, _parrent.transform);
        obj.GetComponent<ObjectThuyTinh>().Born();
        _listMonter.Add(obj.GetComponent<ObjectBase>());
    }
    public void RemoveMonsterAll()
    {

    }
    public bool CheckNumberMonterOneStage()
    {
        return _listMonter.Count <= 0;
    }
    public void RemoveMonster(ObjectBase obj)
    {
        _listMonter.Remove(obj);

    }
    public void CompleteLevel()
    {
        if (GameManager._gameState != GameState.PLAYING)
        {
            return;
        }
        GameManager.Instance.EndGame(GameState.WIN_GAME);

    }
}
