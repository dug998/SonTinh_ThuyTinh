using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class PopupUpgradeHero : PopupBase
{
    [ReadOnly] public int _currentStart;
    ItemRecipe _itemRecipeUpgrade;

    [ReadOnly] public HeroProfile _heroUpgrade;
    public ButtonUi _btnUpgrade;
    public StarHeroUi _startHeroUi;

    [Header(" Stat ")]
    [Header(" hp ")]
    public StatHeroUi _StatHeroHp;
    public TextMeshProUGUI _txtValuesHpIncrease;
    [Header(" Damage ")]
    public StatHeroUi _StatHeroDamage;
    public TextMeshProUGUI _txtValuesDamaIncrease;
    [Header(" Defense ")]
    public StatHeroUi _StatHeroDefense;
    public TextMeshProUGUI _txtValuesDefenseIncrease;

    [Header(" Recipe Upgrade")]
    public List<EquipItemUi> _equipItemRecipes;
    public TextMeshProUGUI _txtNumberGold;
    protected override void Awake()
    {
        base.Awake();
        _btnUpgrade.AddEvent(OnClickUpgradeHero);
    }
    public override void Show(object data = null)
    {
        base.Show(data);
        LoadProfileHero(data);

    }
    public bool CheckHaveUpgrade()
    {
        bool haveUpgrade = _heroUpgrade.HaveUpgrade();

        _txtValuesHpIncrease.gameObject.SetActive(haveUpgrade);
        _txtValuesDamaIncrease.gameObject.SetActive(haveUpgrade);
        _txtValuesDefenseIncrease.gameObject.SetActive(haveUpgrade);
        _btnUpgrade.gameObject.SetActive(haveUpgrade);
        foreach (var item in _equipItemRecipes)
        {
            item.gameObject.SetActive(haveUpgrade);
        }

        return haveUpgrade;
    }
    private void LoadProfileHero(object data)
    {
        _heroUpgrade = (HeroProfile)data;
        if (CheckHaveUpgrade())
        {
            _itemRecipeUpgrade = _heroUpgrade.GetItemRecipeUpgrade(_currentStart);
            ShowStatHeroUdgrade();
        }
        _currentStart = _heroUpgrade._currentStart;
        _startHeroUi.Show(_currentStart);
        ShowStatHeroCurrent();


    }
    public void ShowStatHeroUdgrade()
    {

        int _percentIncrease = _itemRecipeUpgrade.so_percentIncrease;
        _txtValuesHpIncrease.text = _percentIncrease + "%";
        _txtValuesDamaIncrease.text = _percentIncrease + "%";
        _txtValuesDefenseIncrease.text = _percentIncrease + "%";
        foreach (var item in _equipItemRecipes)
        {
            item.gameObject.SetActive(false);
        }
        ItemRecipeIngredient itemRecipeIngredient;
        for (int i = 0; i < _itemRecipeUpgrade.ItemRecipeIngredients.Count; i++)
        {
            _equipItemRecipes[i].gameObject.SetActive(true);
            itemRecipeIngredient = _itemRecipeUpgrade.ItemRecipeIngredients[i];

            _equipItemRecipes[i].Init(itemRecipeIngredient.dataEquipItem.Icon, itemRecipeIngredient.itemCount);
        }
        _txtNumberGold.text = _itemRecipeUpgrade.so_priceGold + "";


    }
    public void ShowStatHeroCurrent()
    {
        _StatHeroHp.UpdateStat(_heroUpgrade._currentHp, _heroUpgrade._MaxtHp);
        _StatHeroDamage.UpdateStat(_heroUpgrade._currentDame, _heroUpgrade._MaxtDame);
        _StatHeroDefense.UpdateStat(_heroUpgrade._currentDefense, _heroUpgrade._MaxtDefense);

    }
    public void UpgradeComplete()
    {
        _heroUpgrade.UpgradeComplete();
        LoadProfileHero(_heroUpgrade);
    }
    public void OnClickUpgradeHero()
    {
        if (_heroUpgrade == null)
        {
            return;
        }

        if (!HaveItemRecipe())
        {
            LogGame.LogWarning("Cannot upgrade !");
            return;
        }
        if (!HaveEnoughIngredients(_itemRecipeUpgrade))
        {
            LogGame.LogWarning("No Enough Ingredients !");
            return;
        }
        Deductdients(_itemRecipeUpgrade);
        UpgradeComplete();
        LogGame.Log("Complete");
    }
    public bool HaveItemRecipe()
    {
        return _heroUpgrade._maxStart > 0;
    }
    public bool HaveEnoughIngredients(ItemRecipe ItemRecipeUpgrade)
    {

        foreach (ItemRecipeIngredient item in ItemRecipeUpgrade.ItemRecipeIngredients)
        {
            if (InventoreManager.Instance.QuantityItem(item.dataEquipItem) < item.itemCount)
                return false;
        }

        return true;
    }
    public void Deductdients(ItemRecipe itemRecipe)
    {
        foreach (ItemRecipeIngredient item in itemRecipe.ItemRecipeIngredients)
        {
            InventoreManager.Instance.DeductItem(item.dataEquipItem, item.itemCount);

        }
    }
}
