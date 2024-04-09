using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupInventory : PopupBase
{
    int MaxItem = 50;
    public EquipItem _prefabEquip;
    public GameObject _parentEquip;
    [ReadOnly]
    public List<EquipItem> _listEquipItem;
    public List<ItemGame> _itemGames;
    [Header(" Info Item ")]
    public Image _icon;
    public TextMeshProUGUI _txtName;

    protected override void Awake()
    {
        base.Awake();
        Init();
    }
    public void Init()
    {
        _listEquipItem.Clear();
        for (int i = 0; i < MaxItem; i++)
        {
            EquipItem item = Instantiate(_prefabEquip, _parentEquip.transform);
            _listEquipItem.Add(item);
        }
    }
    public override void Show(object data = null)
    {
        Init();
        base.Show(data);
         _itemGames = InventoreManager.Instance.GetListItemGame();
        for (int i = 0; i < _itemGames.Count; i++)
        {
            _listEquipItem[i].Init(_itemGames[i].dataItem);
        }
    }
    public void SeeInformation(EquipItemSO dataEquip)
    {
        _icon.sprite = dataEquip.Icon;
        _txtName.text = dataEquip.Names;
    }
}
