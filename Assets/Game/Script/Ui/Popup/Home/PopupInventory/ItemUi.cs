
using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUi : MonoBehaviour
{
    [ReadOnly] public ItemSO _dataItem;
    public Image _icon;
    public TextMeshProUGUI _txtNumberEquip;
    public ButtonUi _btn;
    private void Awake()
    {
        if (_btn != null)
            _btn.AddEvent(() => { SeeEquip(); });
    }
    // Start is called before the first frame update
    public void Init(ItemSO dataItem)
    {
        _dataItem = dataItem;
        _icon.sprite = _dataItem.so_spIcon;
        _icon.gameObject.SetActive(true);

    }
    public void Init(ItemSO dataItem, int numberEquip)
    {
        _icon.sprite = dataItem.so_spIcon;
        _txtNumberEquip.gameObject.SetActive(numberEquip > 0);
        _txtNumberEquip.text = numberEquip.ToString();
        _icon.gameObject.SetActive(true);

    }
    public void Init(ItemSO dataItem, string desc)
    {
        _icon.sprite = dataItem.so_spIcon;
        _txtNumberEquip.text = desc;
        _icon.gameObject.SetActive(true);

    }
    public void SeeEquip()
    {
        PopupController.Instance._popupInventory.SeeInformation(this);

    }
    public void SetFocusDoMove(GameObject focus)
    {
        focus.transform.DOKill(true);
        focus.SetActive(true);
        focus.transform.DOMove(transform.position, 0.1f).OnComplete(() =>
        {
            focus.transform.SetParent(transform);
        });
    }
    public void SetFocus(GameObject focus)
    {
        focus.transform.DOKill(true);
        focus.SetActive(true);
        focus.transform.position = transform.position;
        focus.transform.SetParent(transform);

    }
}
