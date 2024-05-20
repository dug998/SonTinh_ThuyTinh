using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyObjectPool : ObjectPool
{
    public static CurrencyObjectPool Instance;
    public Pool Gold, Gem;
    private void Awake()
    {
        Instance = this;
    }
    protected override void Start()
    {
        pools.Add(Gold);
        pools.Add(Gem);
        base.Start();
    }
}
