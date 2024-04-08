using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PopupShop : PopupBase
{
    public ButtonUi _btnTapChest, _btnTapGold, _btnTapGem;
    [Space(20)]
    public GameObject TapChest, TapGold, TapGem;
    GameObject _currTap;
    ButtonUi _currbtn;
    protected override void Awake()
    {
        base.Awake();
        _btnTapChest.AddEvent(() => OnClickTap(TapChest, _btnTapChest));
        _btnTapGold.AddEvent(() => OnClickTap(TapGold, _btnTapGold));
        _btnTapGem.AddEvent(() => OnClickTap(TapGem, _btnTapGem));

    }
    public override void Show(object data = null)
    {
        base.Show(data);
        OnClickTap(TapChest, _btnTapChest);
    }
    public void OnClickTap(GameObject obj, ButtonUi button)
    {
        if (_currTap != null && _currbtn != null)
        {
            _currTap.SetActive(false);
            _currbtn._txtDesc.color = Color.white;
            _currbtn._icon.gameObject.SetActive(false);
        }
        _currTap = obj;
        _currTap.SetActive(true);
        _currbtn = button;
        _currbtn._txtDesc.color = Color.yellow;
        _currbtn._icon.gameObject.SetActive(true);
    }
}
