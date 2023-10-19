using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectCounterattack : ObjectBase
{
    [Header(" ___ ObjectCounterattack ___"), Space(30)]
    [SerializeField] protected GameObject _bulletPref;
    [SerializeField] protected Transform _locationAppears;
    protected bool _isHitting;
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
        if (collision.gameObject.CompareTag(ObjTag.thuyTinh))
        {
            _isHitting = true;
        }
    }
    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ObjTag.thuyTinh))
        {
            _isHitting = false;
        }

    }
    public override IEnumerator Die()
    {
        _Dead.PixelGravityDie();
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
