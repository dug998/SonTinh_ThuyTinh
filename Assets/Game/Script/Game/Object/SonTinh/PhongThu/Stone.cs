using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : ObjectDefense
{
    float _valuesStatus;

    public override void Born(Object data = null)
    {
        base.Born(data);
        _valuesStatus = _health.GetMaxHealth() * .3f;
    }
    public override void Move()
    {

    }

    public override void StatusObjHealth()
    {
        if (_health.GetCurrentHealth() < _valuesStatus)
        {
            _myAnim.SetBool("hit", true);
        }
    }

}
