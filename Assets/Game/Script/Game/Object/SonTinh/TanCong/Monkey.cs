using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : ObjectCounterattack
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

    public override void Die()
    {
    }

    public override void Move()
    {
    }

}
