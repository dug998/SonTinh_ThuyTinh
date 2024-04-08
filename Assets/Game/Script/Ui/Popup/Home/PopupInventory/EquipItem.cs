using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipItem : MonoBehaviour
{
    DataEquipItem _dataEquip;
    public Image _icon;
    public TextMeshProUGUI _values;
    public ButtonUi _btn;
    private void Awake()
    {
        _btn.AddEvent(() =>
        {
            SeeEquip();
        });
    }
    // Start is called before the first frame update
    public void Init(DataEquipItem dataEquip)
    {
        _dataEquip = dataEquip;
        _icon.gameObject.SetActive(true);
        _icon.sprite = _dataEquip.Icon;

    }
    public void SeeEquip()
    {
        PopupController.Instance._popupInventory.SeeInformation(_dataEquip);
        
    }
}
