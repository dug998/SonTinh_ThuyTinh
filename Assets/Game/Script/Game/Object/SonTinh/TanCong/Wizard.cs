using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : ObjectCounterAttack
{
    public override IEnumerator Attack()
    {
        yield return new WaitUntil(() => GameManager._gameState == GameState.PLAYING);
        yield return new WaitForSeconds(_nextHitting);
        SpawnButtlets();
        ReceiveDame(-_health.GetMaxHealth());
    }

    public override void Move()
    {
    }

    public override void SpawnButtlets()
    {
        Instantiate(_bulletPref, _locationAppears.position, Quaternion.Euler(new Vector3(0, 0, 0)));

    }
    protected override void OnTriggerStay2D(Collider2D collision)
    {
    }
    protected override void OnTriggerExit2D(Collider2D collision)
    {

    }

}
