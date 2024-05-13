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
            SpawnButtlet();

            yield return new WaitForSeconds(1.3f);
            yield return new WaitForSeconds(_nextHitting);
        }
    }

    public override void SpawnButtlet()
    {
        Instantiate(_bulletPref, _locationAppears.position, Quaternion.Euler(new Vector3(0, 0, 0))); ;
       
    }
}
