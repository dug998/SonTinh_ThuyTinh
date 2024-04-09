using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemJson
{
    public string keyEquip;
    public int quantity;
    public void UpdateQuantity(int quantity)
    {
        this.quantity = quantity;
    }
    public ItemJson(string keyEquip, int quantity)
    {
        this.keyEquip = keyEquip;
        this.quantity = quantity;
    }
}
[System.Serializable]
public class AllItemJson
{
    public List<ItemJson> items = new List<ItemJson>();
}

public class InventoreJson : MonoBehaviour
{
    private string playerPrefsKey = "inventoryData";
    private AllItemJson allItemJson;
    
    public AllItemJson GetAllItemJson() { return allItemJson; }
    public void SetAllItemJson(AllItemJson allItemJson) {  this.allItemJson= allItemJson; }


    // Phương thức để lưu dữ liệu Inventory thành JSON
    public void SaveInventory()
    {
        string json = JsonUtility.ToJson(allItemJson);
        PlayerPrefs.SetString(playerPrefsKey, json);
        PlayerPrefs.Save();
    }

    // Phương thức để đọc dữ liệu Inventory từ JSON
    public void LoadInventory()
    {
        if (PlayerPrefs.HasKey(playerPrefsKey))
        {
            string json = PlayerPrefs.GetString(playerPrefsKey);
            allItemJson = JsonUtility.FromJson<AllItemJson>(json);
        }
        else
        {
            Debug.LogWarning("Không tìm thấy tệp dữ liệu Inventory.");
            allItemJson = new AllItemJson();

        }
    }
}

