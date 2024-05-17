using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroProfile : MonoBehaviour
{
    public DataHeroSo dataHero;
    [ReadOnly] public int _currentStart { get; private set; }
    [ReadOnly] public int _maxStart { get; private set; }
    public int _currentHp { get; private set; }
    public int _MaxtHp { get; private set; }
    StatHeroSO _statHeroSoHp;


    public int _currentDame { get; private set; }
    public int _MaxtDame { get; private set; }
    StatHeroSO _statHeroSoDame;

    public int _currentDefense { get; private set; }
    public int _MaxtDefense { get; private set; }
    StatHeroSO _statHeroSoDefense;
    public void Init(DataHeroSo dataHero)
    {
        this.dataHero = dataHero;
        _maxStart = dataHero.so_MaxStart;
        _statHeroSoHp = dataHero.so_statHeroHp;
        _statHeroSoDame = dataHero.so_statHeroDame;
        _statHeroSoDefense = dataHero.so_StatHeroDefense;

        _MaxtHp = _statHeroSoHp._maxStat;
        _MaxtDame = _statHeroSoDame._maxStat;
        _MaxtDefense = _statHeroSoDefense._maxStat;

        _currentHp = CalculateCurrenStat(_statHeroSoHp);
        _currentDame = CalculateCurrenStat(_statHeroSoDame);
        _currentDefense = CalculateCurrenStat(_statHeroSoDefense);

        _currentStart = UserData.GetValuesStartHero(dataHero.KeyHero());

    }
    public int CalculateCurrenStat(StatHeroSO statHeroSO)
    {
        int valuesStat = statHeroSO._origin + Mathf.RoundToInt((TotalPercentIncrease() * statHeroSO._origin) / 100f);
        valuesStat = Mathf.Clamp(valuesStat, 0, statHeroSO._maxStat);
        return valuesStat;
    }
    public int CalculateMaxStat(StatHeroSO statHeroSO)
    {
        return statHeroSO._maxStat;
    }
    public void UpgradeComplete()
    {
        _currentStart++;
        UserData.SetValuesStartHero(dataHero.KeyHero(), _currentStart);
        _currentHp = CalculateCurrenStat(_statHeroSoHp);
        _currentDame = CalculateCurrenStat(_statHeroSoDame);
        _currentDefense = CalculateCurrenStat(_statHeroSoDefense);
    }
    public int TotalPercentIncrease()
    {
        if (dataHero.so_MaxStart <= 0)
        {
            return 0;
        }
        int total = 0;
        for (int i = 0; i < dataHero.so_MaxStart; i++)
        {
            if (i < _currentStart)
            {
                total += dataHero.so_itemRecipes[i].so_percentIncrease;
            }
        }
        return total;

    }
    public bool HaveUpgrade()
    {
        return _currentStart < _maxStart;
    }
    public ItemRecipe GetItemRecipeUpgrade(int index)
    {
        index = Mathf.Clamp(index, 0, _maxStart);
        return dataHero.so_itemRecipes[index];
    }
    public void SetCurrenStat(int currenStat)
    {


    }
}
public enum TypeStat
{
    StatHp,
    StatDame,
    StatDefense,
}
