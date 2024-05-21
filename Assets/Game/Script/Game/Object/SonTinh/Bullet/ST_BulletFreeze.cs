using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ST_BulletFreeze : ST_BulletRegular
{
    public override void CollideWithMonsters(GameObject obj)
    {
        base.CollideWithMonsters(obj);
        obj.GetComponent<ObjectThuyTinh>().Freeze(2);
    }
}
