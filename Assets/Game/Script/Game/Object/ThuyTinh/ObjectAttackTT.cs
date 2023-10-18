using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectAttackTT : ObjectBase
{
    [Header(" ___ Object Counterattack ___"), Space(30)]
    [SerializeField] protected GameObject _bulletPref;
    [SerializeField] protected Transform _locationAppears;
    protected bool _isHitting, _stand;
    [SerializeField] protected float _nextHitting;

    public override void Born()
    {
        base.Born();
        StartCoroutine(Attack());
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
}
