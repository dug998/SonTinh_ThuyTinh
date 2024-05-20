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
            SpawnButtlets();

            yield return new WaitForSeconds(.3f);
            _myAnim.SetBool("hit", false);
            yield return new WaitForSeconds(_nextHitting);
        }
    }

    public override void SpawnButtlets()
    {

        BornBullet(_poolBullet, _statDame, Vector2.right * 8, ballShotTop.position);
        BornBullet(_poolBullet, _statDame, Vector2.right * 8, ballShotMid.position);
        BornBullet(_poolBullet, _statDame, Vector2.right * 8, ballShotBot.position);
    }


}
