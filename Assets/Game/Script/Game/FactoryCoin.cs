using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FactoryCoin : MonoBehaviour
{

    public GameObject _coinPref;
    float _minNextSpawn = 2;
    int _maxNumber = 3;
    [SerializeField] DOTweenPath _pathFrom;
    [SerializeField] DOTweenPath _pathTo;
    int _numberFrom, _numberTo;
    private void Awake()
    {
        _numberFrom = _pathFrom.wps.Count;
        _numberTo = _pathTo.wps.Count;
    }
    public void SpawnCoins(float _nextSpawn = 6)
    {
        if (_nextSpawn < _minNextSpawn)
        {
            _nextSpawn = _minNextSpawn;
        }
        StartCoroutine(FastAction(_nextSpawn));

    }
    IEnumerator FastAction(float _nextSpawn = 6)
    {
        while (true)
        {
            yield return new WaitUntil(() => GameManager._gameState == GameState.PLAYING);

            GameObject obj = Instantiate(_coinPref, transform);
            obj.transform.localScale = Vector3.one * 1.5f;
            obj.GetComponent<Coin>().DoMove(_pathFrom.wps[Random.Range(0, _numberFrom)], _pathTo.wps[Random.Range(0, _numberTo)], 2);
            yield return new WaitForSeconds(_nextSpawn);

        }
    }
}
