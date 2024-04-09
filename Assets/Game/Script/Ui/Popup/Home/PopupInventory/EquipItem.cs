
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipItem : MonoBehaviour
{
    public EquipItemSO _dataEquip;
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
    public void Init(EquipItemSO dataEquip)
    {
        _dataEquip = dataEquip;
        Debug.Log(" icon " + dataEquip.Icon.name);
        _icon.sprite = dataEquip.Icon;

        _icon.gameObject.SetActive(true);

    }
    public void SeeEquip()
    {
        PopupController.Instance._popupInventory.SeeInformation(_dataEquip);

    }
}
