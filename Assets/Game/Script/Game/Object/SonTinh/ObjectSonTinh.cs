using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSonTinh : ObjectBase
{
    //  public bool _jumpable = true;
    public SpriteRenderer _iconObj;
    [HideInInspector] public DataHero _dataHero;
    public override void Born(Object data = null)
    {
        orginSpeed = Vector2.zero;
        _dataHero = (DataHero)data;
        Debug.LogError(_dataHero._name);
        _health.SetMaxHealth((int)_dataHero._statHp);

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
        _iconObj.sortingOrder = order;
    }
}
