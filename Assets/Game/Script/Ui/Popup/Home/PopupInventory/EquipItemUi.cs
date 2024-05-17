
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipItemUi : MonoBehaviour
{
    public EquipItemSO _dataEquip;
    public Image _icon;
    public TextMeshProUGUI _txtNumberEquip;
    public ButtonUi _btn;
    private void Awake()
    {
        if (_btn != null)
            _btn.AddEvent(() => { SeeEquip(); });
    }
    // Start is called before the first frame update
    public void Init(EquipItemSO dataEquip)
    {
        _dataEquip = dataEquip;
        _icon.sprite = _dataEquip.Icon;
        _icon.gameObject.SetActive(true);

    }
    public void Init(Sprite sp_icon, int numberEquip)
    {
        _icon.sprite = sp_icon;
        _txtNumberEquip.text = numberEquip.ToString();
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
