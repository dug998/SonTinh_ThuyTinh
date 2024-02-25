using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSonTinh : ObjectBase
{
    public DataHero _dataHero;
    public override void Born(Object data = null)
    {

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


}
