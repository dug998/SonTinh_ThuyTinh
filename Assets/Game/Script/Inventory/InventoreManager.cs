using JetBrains.Annotations;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class ItemGame
{
    public ItemJson itemJson;
    public ItemSO dataItem;
    public ItemGame(ItemJson itemJson, ItemSO data)
    {
        this.itemJson = itemJson;
        this.dataItem = data;
    }
    public void UpdateQuantity(int quantity)
    {
        itemJson.UpdateQuantity(quantity);
    }
    public void AddQuantity(int quantity)
    {
        itemJson.AddQuantity(quantity);
    }
    public int GetQuantity() {
        return itemJson.quantity;
    }
}

[RequireComponent(typeof(InventoreJson))]
public class InventoreManager : MonoBehaviour
{
    public static InventoreManager Instance;
    List<ItemSO> _dataEquipItems;
    InventoreJson _inventoreJson;

    public List<ItemGame> _itemGames;
    public List<ItemGame> GetListItemGame()
    {
        return _itemGames;
    }
    private IEnumerator Start()
    {
        Instance = this;
        yield return new WaitUntil(() => AssetSO.Instance != null);
        _itemGames = new List<ItemGame>();
        _dataEquipItems = AssetSO.Instance._dataEquipItems;
        _inventoreJson = GetComponent<InventoreJson>();
        _inventoreJson.LoadInventory();

        LoadInventory();
    }
    void OnApplicationQuit()
    {
        SaveInventory();
    }
    void LoadInventory()
    {
        AllItemJson allItemJson = _inventoreJson.GetAllItemJson();
        if (allItemJson.items.Count <= 0)
        {
            LogGame.LogWarning("Inventory empty !");
            return;
        }
        foreach (var item in allItemJson.items)
        {
            ItemSO data = _dataEquipItems.Find(x => x.GetKey() == item.keyEquip);
            _itemGames.Add(new ItemGame(item, data));
        }
    }
    void SaveInventory()
    {
        AllItemJson allItemJson = new AllItemJson();
        foreach (var item in _itemGames)
        {
            allItemJson.items.Add(item.itemJson);
        }
        _inventoreJson.SetAllItemJson(allItemJson);
        _inventoreJson.SaveInventory();
    }
    void AddItem(string keyEquip, int quantity = 1)
    {
        ItemGame item = FindItem(keyEquip);
        if (item != null)
        {
            item.AddQuantity(quantity);
        }
        else
        {
            ItemSO data = _dataEquipItems.Find(x => x.GetKey() == keyEquip);
            ItemJson i = new ItemJson(keyEquip, quantity);
            _itemGames.Add(new ItemGame(i, data));
        }
    }
    public void AddItem(ItemSO dataEquip, int quantity = 1)
    {
        LogGame.Log("Add equip :" + dataEquip.GetKey());
        AddItem(dataEquip.GetKey(), quantity);
    }
    public int GetQuantityItem(ItemSO dataEquip)
    {
        return GetQuantityItem(dataEquip.GetKey());
    }
    int GetQuantityItem(string keyEquip)
    {
        ItemGame item = FindItem(keyEquip);
        if (item == null)
        {
            LogGame.LogWarning("Not found item :" + keyEquip);
            return 0;
        }
        return item.itemJson.quantity;
    }
    public void DeductItem(ItemSO dataEquip, int quantity)
    {
        DeductItem(dataEquip.GetKey(), quantity);
    }
    void DeductItem(string keyEquip, int quantity)
    {
        ItemGame item = FindItem(keyEquip);
        if (item == null)
        {
            Debug.Log("Null dataItem !");
            LogGame.LogWarning("not found item :" + keyEquip);
            return;
        }
        item.itemJson.quantity -= quantity;
        if (item.itemJson.quantity <= 0)
        {
            _itemGames.Remove(item);
        }
    }
    public void RemoveItem(string keyEquip)
    {
        ItemGame item = FindItem(keyEquip);
        if (item == null)
        {
            LogGame.LogWarning("not found item :" + keyEquip);
            return;
        }
        _itemGames.Remove(item);
    }
    private ItemGame FindItem(string keyEquip)
    {
        return _itemGames.Find(x => x.itemJson.keyEquip == keyEquip);
    }
    [Button]
    public void AddItemsRandom()
    {

        AddItem(_dataEquipItems[Random.Range(0, _dataEquipItems.Count)]);
    }
}
