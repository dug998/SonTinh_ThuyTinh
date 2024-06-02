using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ST_Fire : ObjectCounterAttack
{
    public override IEnumerator Attack()
    {
        throw new System.NotImplementedException();
    }

    public override IEnumerator EffectDie()
    {
        yield return null;
        gameObject.SetActive(false);
    }

    public override void Move()
    {
    }

    public override void SpawnButtlets()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            var obj = collision.GetComponent<ST_BulletRegular>();
            if (obj != null && obj._canFire)
            {
                BornBullet(_poolBullet, _statDame, Vector2.right * 8, _locationAppears.position);
                obj.DiedImmediate();

            }

        }
    }
}
