
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[System.Serializable]
public class ItemRecipe
{
    // List<ItemRecipeIngredient> ItemRecipeIngredients;

    [PreviewField(Height = 20)]
    [TableColumnWidth(30, Resizable = false)]
    public Texture2D Icon;

    [TableColumnWidth(100, Resizable = false)]
    public int ID;
    public int so_priceGold;
    public int so_percentIncrease;
    [TableList]
    public List<ItemRecipeIngredient> ItemRecipeIngredients;


}

[System.Serializable]
public class ItemRecipeIngredient
{
    public EquipItemSO dataEquipItem;
    public int itemCount;
}