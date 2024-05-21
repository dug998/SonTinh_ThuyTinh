using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupUpgradeHero : PopupBase
{
    [ReadOnly] public int _currentStart;
    ItemRecipe _itemRecipeUpgrade;

    [ReadOnly] public HeroProfile _heroUpgrade;
    public ButtonUi _btnUpgrade;

    public Image _iconHero;
    public TextMeshProUGUI _txtNameHero;
    public StarHeroUi _starHeroUi;

    [Header(" Stat ")]
    [Header(" hp ")]
    public StatHeroUi _StatHeroHp;
    public ObjTextUi _txtUiHpIncrease;
    [Header(" Damage ")]
    public StatHeroUi _StatHeroDamage;
    public ObjTextUi _txtUiDamaIncrease;
    [Header(" Defense ")]
    public StatHeroUi _StatHeroDefense;
    public ObjTextUi _txtUiDefenseIncrease;

    [Header(" Recipe Upgrade")]
    public List<ItemUi> _equipItemRecipes;
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
        PopupCurrencyStatus.Instance.Hide();
    }
    public override void Hide()
    {
        PopupCurrencyStatus.Instance.Show();
        base.Hide();
    }
    public bool CheckHaveUpgrade()
    {
        bool haveUpgrade = _heroUpgrade.HaveUpgrade();

        _txtUiHpIncrease.Show(haveUpgrade);
        _txtUiDamaIncrease.Show(haveUpgrade);
        _txtUiDefenseIncrease.Show(haveUpgrade);
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
        _iconHero.sprite = _heroUpgrade._iconHero;
        _txtNameHero.text = _heroUpgrade._nameHero;
        _starHeroUi.ShowStatMax(_heroUpgrade._maxStart);
        _currentStart = _heroUpgrade._currentStart;
        _starHeroUi.Show(_currentStart);
        ShowStatHeroCurrent();
        if (CheckHaveUpgrade())
        {
            _itemRecipeUpgrade = _heroUpgrade.GetIndexItemRecipeUpgrade(_currentStart);
            ShowStatHeroUdgrade();
        }


    }
    public void ShowStatHeroUdgrade()
    {

        int _percentIncrease = _itemRecipeUpgrade.so_percentIncrease;
        _txtUiHpIncrease.SetText(_percentIncrease + "%");
        _txtUiDamaIncrease.SetText(_percentIncrease + "%");
        _txtUiDefenseIncrease.SetText(_percentIncrease + "%");
        foreach (var item in _equipItemRecipes)
        {
            item.gameObject.SetActive(false);
        }
        ItemRecipeIngredient itemRecipeIngredient;
        int currQuantity = 0;
        int requiredQuantity = 0;
        string desc = "";
        for (int i = 0; i < _itemRecipeUpgrade.ItemRecipeIngredients.Count; i++)
        {
            _equipItemRecipes[i].gameObject.SetActive(true);

            itemRecipeIngredient = _itemRecipeUpgrade.ItemRecipeIngredients[i];
            currQuantity = InventoreManager.Instance.GetQuantityItem(itemRecipeIngredient.dataEquipItem);
            requiredQuantity = itemRecipeIngredient.itemCount;
            if (currQuantity > requiredQuantity)
            {
                desc = $"{requiredQuantity}/{currQuantity}";
            }
            else if (currQuantity < requiredQuantity)
            {
                desc = string.Format("<color={0}> {1} </color>/ {2}", "#DB6E58", requiredQuantity, currQuantity);
            }
            _equipItemRecipes[i].Init(itemRecipeIngredient.dataEquipItem, desc);
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
        PopupController.Instance.ShowPopup(TypePopup.PopupNotife, new DataMessage(TypeMessage.Success, "", " Upgrade Complete !"));
    }
    public bool HaveItemRecipe()
    {
        return _heroUpgrade._maxStart > 0;
    }
    public bool HaveEnoughIngredients(ItemRecipe ItemRecipeUpgrade)
    {

        foreach (ItemRecipeIngredient item in ItemRecipeUpgrade.ItemRecipeIngredients)
        {
            if (InventoreManager.Instance.GetQuantityItem(item.dataEquipItem) < item.itemCount)
            {
                LogGame.LogWarning("No Enough !" + item.dataEquipItem.so_names);
                return false;
            }
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
