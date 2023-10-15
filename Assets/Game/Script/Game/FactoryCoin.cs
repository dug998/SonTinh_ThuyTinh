using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FactoryCoin : MonoBehaviour
{

    public GameObject _coinPref;
    float _minNextSpawn = 2;
    int _maxNumber = 3;
    public void SpawnCoins(float _nextSpawn = 6)
    {
        if (_nextSpawn < _minNextSpawn)
        {
            _nextSpawn = _minNextSpawn;
        }
        StartCoroutine(FastAction(_nextSpawn));

    }
    IEnumerator FastAction(float _nextSpawn = 2)
    {
        while (true)
        {
            yield return new WaitUntil(() => GameManager._gameState == GameState.PLAYING);

            GameObject obj = Instantiate(_coinPref, transform);

            yield return new WaitForSeconds(_nextSpawn);

        }
    }
}
