using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TT_BulletRegular : ObjectBase
{
    [SerializeField] int dame;
    public GameObject ballHit;

    public override void Born(Object data = null)
    {
    }
    public override void UpdateHealth(int values)
    {
    }
    void FixedUpdate()
    {
        Move();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.CompareTag(ObjTag.sonTinh))
        {
            CollideWithMonsters(collision.gameObject);
            Died();
        }

    }
    public virtual void CollideWithMonsters(GameObject obj)
    {
        ObjectBase monsterHealth = obj.GetComponent<ObjectBase>();
        monsterHealth.UpdateHealth(-dame);

    }
    public override void Move()
    {
        _myBody.velocity = new Vector2(speed, _myBody.velocity.y);
    }

    public override IEnumerator EffectDie()
    {
        gameObject.SetActive(false);
        yield return null;
    }
}
