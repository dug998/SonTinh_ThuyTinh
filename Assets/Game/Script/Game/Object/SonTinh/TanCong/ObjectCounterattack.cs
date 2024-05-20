using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// class base for objects that can attack
/// 
/// 
/// </summary>
public abstract class ObjectCounterAttack : ObjectSonTinh
{
    [Header(" ___ ObjectCounterAttack ___"), Space(30)]
    [SerializeField] protected GameObject _bulletPref;
    [SerializeField] protected Transform _locationAppears;
    protected bool _isHitting;
    [SerializeField] protected float _nextHitting = 1;
    protected Pool _poolBullet;
    public override void Born(Object data = null)
    {
        base.Born(data);
        LoadBulletPool();
        StartCoroutine(Attack());
    }
    public virtual void LoadBulletPool()
    {
        if (_bulletPref != null)
            _poolBullet = BulletObjectPool.Instance.TryAddPoolByScript(_bulletPref);
    }
    public abstract IEnumerator Attack();
    public abstract void SpawnButtlets();
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
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
    public void BornBullet(Pool _pool, int _dame, Vector2 speed, Vector2 pos)
    {
        BulletBase obj = BulletObjectPool.Instance.Get(_pool).GetComponent<BulletBase>();
        obj.gameObject.SetActive(true);
        obj.SetPos(pos);
        obj.SetDame(_dame);
        obj.SetSpeed(speed);
        obj.Born();
    }
    public override IEnumerator EffectDie()
    {
        _Dead.PixelGravityDie();
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
