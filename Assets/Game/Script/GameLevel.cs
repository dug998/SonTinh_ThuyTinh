using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour
{
    public Grounds _grounds;
    public FactoryCoin _factoryCoin;
    [SerializeField] SpawnThuyTinh _pawnThuyTinh;
    public void Init()
    {
        _grounds.SpawnBlocks();
        _factoryCoin.SpawnCoins();
        StartCoroutine(_pawnThuyTinh.CreateArmyList());
    }
}
