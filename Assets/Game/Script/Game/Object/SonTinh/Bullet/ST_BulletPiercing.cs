using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ST_BulletPiercing : ST_BulletRegular
{

    public float _timeLife = 20;
    public override void Born(Object data = null)
    {
        base.Born(data);
        Invoke(nameof(DiedImmediate), _timeLife);
    }
    public override void ReceiveDame(int values)
    {
    }
    public override void CollideWithMonsters(GameObject obj)
    {
        ObjectBase monsterHealth = obj.GetComponent<ObjectBase>();
        monsterHealth.ReceiveDame(-_dame);
        if (_effect != null)
        {
            Instantiate(_effect, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        _effect.transform.localScale = Vector2.one * 0.5f;
    }


}
