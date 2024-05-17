using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor.Examples;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DataHeroSo", menuName = "Game/DataHeroSo")]
public class DataHeroSo : ScriptableObject
{
    public int so_id;
    public string so_title;
    public string so_name;
    public string KeyHero()
    {
        return so_name;
    }
    [TextArea]
    public string so_description;
    public int so_price = 25;
    public float so_timeRecoveryCard;
    [PreviewField()]
    public Sprite so_spriteAvatar;

    [PreviewField()]
    public Sprite so_spriteCard;
    public GameObject so_ObjPref;

    [ReadOnly] public int so_MaxStart;
    [Header("Stat")]
    public StatHeroSO so_statHeroHp;
    public StatHeroSO so_statHeroDame;
    public StatHeroSO so_StatHeroDefense;

    [Header("Upgrade")]
    [TableList]
    public List<ItemRecipe> so_itemRecipes;
    public void OnValidate()
    {
        so_MaxStart = so_itemRecipes.Count;

    }

}
[System.Serializable]
public class StatHeroSO
{
    public int _origin = 0;
    public int _maxStat = 300;
    public int _minStat = 0;

}