using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : ObjectBase
{
    [SerializeField] protected int _dame = 10;
    [SerializeField] public bool _canFire;
    public GameObject _effect;
    public override IEnumerator EffectDie()
    {
        yield return null;
        BulletObjectPool.Instance.Return(gameObject);
    }
    public override void DiedImmediate()
    {
        BulletObjectPool.Instance.Return(gameObject);
    }
    public override void Move()
    {
        _myBody.velocity = currSpeed;
    }
    public void SetDame(int newDame)
    {
        _dame = newDame;
    }
}
