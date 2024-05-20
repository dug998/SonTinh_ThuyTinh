using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  ĐẠN CƠ BẢN
/// </summary>
public class ST_BulletRegular : BulletBase
{
    public bool canFire;
    public override void Born(Object data = null)
    {
        currSpeed = orginSpeed;
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
        }

    }
    public virtual void CollideWithMonsters(GameObject obj)
    {
        ObjectBase monsterHealth = obj.GetComponent<ObjectBase>();
        monsterHealth.ReceiveDame(-dame);
        if (_effect != null)
        {
            Instantiate(_effect, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            _effect.transform.localScale = Vector2.one * 0.5f;
        }
        Died();
    }
  

   
}
