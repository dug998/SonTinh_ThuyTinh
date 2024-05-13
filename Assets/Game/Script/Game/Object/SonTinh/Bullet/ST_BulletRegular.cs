using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  ĐẠN CƠ BẢN
/// </summary>
public class ST_BulletRegular : ObjectBase
{

    [SerializeField] protected int dame = 10;
    public GameObject _effect;
    public bool canFire;
    private void OnEnable()
    {
        Born(null);


    }
    public override void Born(Object data = null)
    {
        currSpeed = orginSpeed;
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

        }

    }
    public virtual void CollideWithMonsters(GameObject obj)
    {
        ObjectBase monsterHealth = obj.GetComponent<ObjectBase>();
        monsterHealth.UpdateHealth(-dame);
        if (_effect != null)
        {
            Instantiate(_effect, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        _effect.transform.localScale = Vector2.one * 0.5f;
        Died();
    }
    public override void Move()
    {
        _myBody.velocity = currSpeed;
    }

    public override IEnumerator EffectDie()
    {
        yield return null;
        gameObject.SetActive(false);
    }
}
