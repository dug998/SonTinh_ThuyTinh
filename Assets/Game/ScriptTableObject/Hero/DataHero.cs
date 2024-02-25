using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DataHero", menuName = "Game/DataHero")]
public class DataHero : ScriptableObject
{
    public int _id;
    public string _title;
    public string _name;
    public string _description;
    public int _price;
    public float _timeRecoveryCard;
    public Sprite _spriteAvatar;
    public Sprite _spriteCard;
    public GameObject _ObjPref;

    [Header("Stat")]
    public float _statHp;
    public float _statDamage;
    public float _statDefense;
    public void OnValidate()
    {
        _statHp = Mathf.Clamp(_statHp, ConstStatHero._minStat, ConstStatHero._maxHp);
        _statDamage = Mathf.Clamp(_statDamage, ConstStatHero._minStat, ConstStatHero._maxDamage);
        _statDefense = Mathf.Clamp(_statDefense, ConstStatHero._minStat, ConstStatHero._maxDefense);

    }

}
