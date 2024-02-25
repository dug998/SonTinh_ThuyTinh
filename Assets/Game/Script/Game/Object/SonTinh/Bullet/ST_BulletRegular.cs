using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ST_BulletRegular : ObjectBase
{
    [SerializeField] int dame;
    public GameObject _effect;

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
        if (collision.gameObject.CompareTag(ObjTag.thuyTinh))
        {
            CollideWithMonsters(collision.gameObject);
            Died();
        }

    }
    public virtual void CollideWithMonsters(GameObject obj)
    {
        ObjectBase monsterHealth = obj.GetComponent<ObjectBase>();
        monsterHealth.UpdateHealth(-dame);
        Instantiate(_effect, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        _effect.transform.localScale = Vector2.one * 0.5f;
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
