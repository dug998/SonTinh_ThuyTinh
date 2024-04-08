using System.Collections.Generic;
using UnityEngine;
public class ItemGame
{
    ItemJson itemJson;
    public DataEquipItem item;
    public ItemGame(ItemJson itemJson, DataEquipItem data)
    {
        this.itemJson = itemJson;
        this.item = data;
    }
}

[RequireComponent(typeof(InventoreJson))]
public class InventoreManager : MonoBehaviour
{
    List<DataEquipItem> _dataEquipItems;
    InventoreJson _inventoreJson;

    List<ItemGame> _itemGames;
    private void Awake()
    {
        _dataEquipItems = AssetSO.Instance._dataEquipItems;
        _inventoreJson = GetComponent<InventoreJson>();
        _inventoreJson.LoadInventory();
        LoadInventory();
    }
    void LoadInventory()
    {
        AllItemJson allItemJson = _inventoreJson.GetAllItemJson();
        if (allItemJson.items.Count <= 0)
        {
            return;
        }
        foreach (var item in allItemJson.items)
        {
            DataEquipItem data = _dataEquipItems.Find(x => x.GetKey() == item.keyEquip);
            _itemGames.Add(new ItemGame(item, data));
        }
    }
    public void AddItem(string itemName, int quantity)
    {

    }
    public void RemoveItem(string itemName, int quantity)
    {
    }
    public void RemoveItem(string keyItem)
    {

    }
}
