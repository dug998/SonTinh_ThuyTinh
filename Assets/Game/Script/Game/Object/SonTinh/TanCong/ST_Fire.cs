using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ST_Fire : ObjectBase
{
    public GameObject fire_ball;

    public override IEnumerator EffectDie()
    {
        yield return null;
        gameObject.SetActive(false);
    }

    public override void Move()
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            var obj = collision.GetComponent<ST_BulletRegular>();
            if (obj != null && obj.canFire)
            {

                Instantiate(fire_ball, collision.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                Destroy(collision.gameObject);

            }

        }
    }
}
