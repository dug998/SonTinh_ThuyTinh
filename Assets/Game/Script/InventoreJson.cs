using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemJson
{
    public string keyEquip;
    public int quantity;
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

    // Phương thức để thêm một vật phẩm vào Inventory
    public void AddItem(string keyEquip, int quantity)
    {
        // Kiểm tra xem vật phẩm đã tồn tại trong Inventory chưa
        int existingIndex = FindItemIndex(keyEquip);
        if (existingIndex != -1)
        {
            // Nếu đã tồn tại, cập nhật số lượng
            allItemJson.items[existingIndex].quantity += quantity;
        }
        else
        {
            // Nếu chưa tồn tại, thêm vào Inventory
            allItemJson.items.Add(new ItemJson { keyEquip = keyEquip, quantity = quantity });
        }
        SaveInventory();
    }
    // Phương thức để xóa một vật phẩm từ Inventory
    public void RemoveItem(string itemName, int quantity)
    {
        // Kiểm tra xem vật phẩm đã tồn tại trong Inventory chưa
        int existingIndex = FindItemIndex(itemName);
        if (existingIndex != -1)
        {
            // Giảm số lượng của vật phẩm
            allItemJson.items[existingIndex].quantity -= quantity;
            // Kiểm tra xem vật phẩm đã hết số lượng chưa
            if (allItemJson.items[existingIndex].quantity <= 0)
            {
                // Nếu đã hết, xóa vật phẩm khỏi Inventory
                allItemJson.items.RemoveAt(existingIndex);
            }
            SaveInventory();
        }
    }
    public void RemoveItem(string keyItem)
    {
        // Kiểm tra xem vật phẩm đã tồn tại trong Inventory chưa
        int existingIndex = FindItemIndex(keyItem);
        if (existingIndex != -1)
        {
            allItemJson.items[existingIndex].quantity = 0;
            if (allItemJson.items[existingIndex].quantity <= 0)
            {
                // Nếu đã hết, xóa vật phẩm khỏi Inventory
                allItemJson.items.RemoveAt(existingIndex);
            }
            SaveInventory();
        }
    }
    // Phương thức để tìm vật phẩm trong Inventory và trả về index
    private int FindItemIndex(string keyEquip)
    {
        return allItemJson.items.FindIndex(x => x.keyEquip == keyEquip);
    }

    // Phương thức để lưu dữ liệu Inventory thành JSON
    private void SaveInventory()
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

