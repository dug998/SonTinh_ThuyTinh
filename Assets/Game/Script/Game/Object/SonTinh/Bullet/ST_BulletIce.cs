using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ST_BulletIce : ST_BulletRegular
{
    [Range(0, 1)]
    [SerializeField] float _reductionRate = 0.5f;
    public override void CollideWithMonsters(GameObject obj)
    {
        base.CollideWithMonsters(obj);
        ObjectBase _obj = obj.GetComponent<ObjectBase>();
        if (_obj != null)
        {
            _obj.ChangeMove(_reductionRate);
            _obj.ChangeSpeed(_reductionRate);
        }
    }
}
