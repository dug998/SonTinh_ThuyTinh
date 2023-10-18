using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : ObjectDefense
{
    [SerializeField] int _valuesStatus = 50;
    public override void Die()
    {

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
