using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ST_Monkey has the ability to throw projectiles after a period of time
/// </summary>
///
public class ST_Monkey : ObjectCounterAttack
{

    public override IEnumerator Attack()
    {
        yield return null;
        while (true)
        {
            _myAnim.SetBool("hit", false);
            yield return new WaitUntil(() => GameManager._gameState == GameState.PLAYING);
            yield return new WaitUntil(() => _isHitting);

            yield return new WaitForSeconds(.5f);
            _myAnim.SetBool("hit", true);
            yield return new WaitForSeconds(.5f);
            SpawnButtlets();
            yield return new WaitForSeconds(.5f);
            _myAnim.SetBool("hit", false);
            yield return new WaitForSeconds(_nextHitting);
        }
    }
    public override void SpawnButtlets()
    {
        BornBullet(_poolBullet, _statDame, Vector2.right * 8, _locationAppears.position);
    }


    public override void Move()
    {
    }

}
