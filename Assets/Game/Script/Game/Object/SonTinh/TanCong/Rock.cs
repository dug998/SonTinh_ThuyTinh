using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : ObjectCounterAttack
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
            yield return new WaitForSeconds(.3f);
            SpawnButtlet();
            yield return new WaitForSeconds(.4f);
            _myAnim.SetBool("hit", false);
            yield return new WaitForSeconds(_nextHitting);
        }
    }

    public override void SpawnButtlet()
    {
        Instantiate(_bulletPref, _locationAppears.position, Quaternion.Euler(new Vector3(0, 0, 0)));

    }

    // Start is called before the first frame update

}
