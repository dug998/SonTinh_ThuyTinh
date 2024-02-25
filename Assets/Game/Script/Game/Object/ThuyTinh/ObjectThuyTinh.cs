
using System.Collections;
using UnityEngine;

public abstract class ObjectThuyTinh : ObjectBase
{
    [Header(" ___ Object Counterattack ___"), Space(30)]
    [SerializeField] protected GameObject _bulletPref;
    [SerializeField] protected Transform _locationAppears;
    protected bool _isHitting, _stand;
    [SerializeField] protected float _nextHitting;

    public override void Born(Object data = null)
    {
        base.Born();
        StartCoroutine(Attack());
    }
    public override void Move()
    {
        if (_isDead)
        {
            _myBody.velocity = new Vector2(0, _myBody.velocity.y);
            _myAnim.SetBool("walk", false);
            return;
        }
    }
    public abstract IEnumerator Attack();
    public abstract void SpawnButtlet();
    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ObjTag.sonTinh) && collision.isTrigger == true)
        {
            _isHitting = true;
            _stand = true;
        }
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.gameObject.CompareTag(ObjTag.sonTinh) && collision.isTrigger == true)
        {
            _isHitting = true;
            _stand = true;
        }

    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ObjTag.sonTinh))
        {
            _isHitting = false;
            _stand = false;
        }
    }
}
