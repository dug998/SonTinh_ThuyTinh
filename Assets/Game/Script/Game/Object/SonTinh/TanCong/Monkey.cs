using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Monkey has the ability to throw projectiles after a period of time
/// </summary>
///
public class Monkey : ObjectCounterAttack
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
            SpawnButtlet();
            yield return new WaitForSeconds(.5f);
            _myAnim.SetBool("hit", false);
            yield return new WaitForSeconds(_nextHitting);
        }
    }
    public override void SpawnButtlet()
    {
        GameObject obj = Instantiate(_bulletPref);
        obj.transform.position = _locationAppears.position;
    }


    public override void Move()
    {
    }

}
