using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : ObjectCounterAttack
{
    public List<GameObject> direcBullets;
    public override IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitUntil(() => GameManager._gameState == GameState.PLAYING);
            yield return new WaitUntil(() => _isHitting);
            yield return new WaitForSeconds(.5f);
            yield return new WaitForSeconds(.5f);
            SpawnButtlets();
            yield return new WaitForSeconds(_nextHitting);
        }
    }

    public override void SpawnButtlets()
    {
        foreach (var direc in direcBullets)
        {
            BornBullet(_poolBullet, _statDame, (_locationAppears.transform.position - direc.transform.position).normalized, _locationAppears.position);
        }
    }
}
