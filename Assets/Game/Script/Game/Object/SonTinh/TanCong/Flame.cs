using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : ObjectCounterAttack
{

    public override IEnumerator Attack()
    {
        yield return null;
        while (true)
        {
            yield return new WaitUntil(() => GameManager._gameState == GameState.PLAYING);
            yield return new WaitUntil(() => _isHitting);

            yield return new WaitForSeconds(.5f);
            yield return new WaitForSeconds(.5f);
            SpawnButtlets();

            yield return new WaitForSeconds(1.3f);
            yield return new WaitForSeconds(_nextHitting);
        }
    }

    public override void SpawnButtlets()
    {

        BornBullet(_poolBullet, _statDame, Vector2.right * 8, _locationAppears.position);

    }
}
