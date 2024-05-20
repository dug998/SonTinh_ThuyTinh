using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPool : ObjectPool
{
    public static BulletObjectPool Instance;

   
    public void Awake()
    {
        Instance = this;
    }

}
