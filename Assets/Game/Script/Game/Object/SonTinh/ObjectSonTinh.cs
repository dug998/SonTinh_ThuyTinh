using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSonTinh : ObjectBase
{
    //  public bool _jumpable = true;
    [ReadOnly] public HeroProfile _heroProfile;

    [Header("Stat")]
    [ReadOnly] public int _statHp;
    [ReadOnly] public int _statDame;
    [ReadOnly] public int _statDefense;

    public override void Born(Object data = null)
    {
        orginSpeed = Vector2.zero;
        _heroProfile = (HeroProfile)data;
        _statHp = _heroProfile._currentHp;
        _statDame = _heroProfile._currentDame;
        _statDefense = _heroProfile._currentDefense;

        _health.SetMaxHealth((_statHp));

        base.Born(data);
    }
    public override IEnumerator EffectDie()
    {
        throw new System.NotImplementedException();
    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }
    private void Reset()
    {
        currSpeed = Vector2.zero;
    }
    public void SetSortingOrder(int order)
    {
        _sprite.sortingOrder = order;
    }
}
