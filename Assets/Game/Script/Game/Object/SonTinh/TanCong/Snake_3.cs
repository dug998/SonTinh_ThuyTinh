using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_3 : ObjectCounterAttack
{
    public Transform ballShotTop, ballShotMid, ballShotBot;

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
            yield return new WaitForSeconds(.2f);
            SpawnButtlet();

            yield return new WaitForSeconds(.3f);
            _myAnim.SetBool("hit", false);
            yield return new WaitForSeconds(_nextHitting);
        }
    }

    public override void SpawnButtlet()
    {
        Instantiate(_bulletPref, ballShotTop.position, Quaternion.Euler(new Vector3(0, 0, 0)));

        Instantiate(_bulletPref, ballShotMid.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        Instantiate(_bulletPref, ballShotBot.position, Quaternion.Euler(new Vector3(0, 0, 0)));
    }


}
