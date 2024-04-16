using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class ItemGame
{
    public ItemJson itemJson;
    public EquipItemSO dataItem;
    public ItemGame(ItemJson itemJson, EquipItemSO data)
    {
        this.itemJson = itemJson;
        this.dataItem = data;
    }
    public void UpdateQuantity(int quantity)
    {
        itemJson.UpdateQuantity(quantity);
    }
}

[RequireComponent(typeof(InventoreJson))]
public class InventoreManager : MonoBehaviour
{
    public static InventoreManager Instance;
    List<EquipItemSO> _dataEquipItems;
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
            return;
        }
        foreach (var item in allItemJson.items)
        {
            EquipItemSO data = _dataEquipItems.Find(x => x.GetKey() == item.keyEquip);
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
    public void AddItem(string keyName, int quantity = 1)
    {
        ItemGame item = FindItem(keyName);
        if (item != null)
        {
            item.UpdateQuantity(quantity);
        }
        else
        {
            EquipItemSO data = _dataEquipItems.Find(x => x.GetKey() == keyName);
            ItemJson i = new ItemJson(keyName, quantity);
            _itemGames.Add(new ItemGame(i, data));
        }
    }
    public void AddItem(EquipItemSO dataEquip)
    {
        AddItem(dataEquip.GetKey());
    }
    public void RemoveItem(string keyName, int quantity)
    {
        ItemGame item = FindItem(keyName);
        if (item == null)
        {
            Debug.Log("Null dataItem !");
            return;
        }
        item.itemJson.quantity -= quantity;
        if (item.itemJson.quantity <= 0)
        {
            _itemGames.Remove(item);
        }
    }
    public void RemoveItem(string keyName)
    {
        ItemGame item = FindItem(keyName);
        if (item == null)
        {
            Debug.Log("Null dataItem !");
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
