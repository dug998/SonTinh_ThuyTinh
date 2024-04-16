using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardDay : MonoBehaviour
{
    [Header(" --- data --- ")]
    Reward _data;
    int _indexDay;
    public Image _imgIcon;
    public TextMeshProUGUI _txtDay;
    public TextMeshProUGUI _txtValues;
    [Header("--- Status --- ")]
    public Image _imgBg;
    public Sprite _bgClam, _bgAvailable;
    public GameObject _objClaim;
    public GameObject _objAvailable;
    public void Init(int index, Reward data)
    {
        _data = data;
        _indexDay = index + 1;
        _imgIcon.sprite = data._spIcon;
        _imgIcon.SetNativeSize();
        _txtDay.text = _indexDay.ToString();
        _txtValues.text = _data.valuesRw.ToString();

    }
    public void UpdateStatus(statusReward status)
    {
        switch (status)
        {
            case statusReward.Claimed:
                Claimed();
                break;
            case statusReward.Available:
                Available();
                break;

            default:
                Lock();
                break;
        }
    }
    public void GetReward()
    {
        PopupController.Instance._popupReward.GetReward(_data);
    }
    void Claimed()
    {
        _imgBg.sprite = _bgClam;
        _objClaim.SetActive(true);
        _objAvailable.SetActive(false);

    }
    void Available()
    {
        _imgBg.sprite = _bgAvailable;
        _objClaim.SetActive(false);
        _objAvailable.SetActive(true);
    }
    public void Lock()
    {
        _imgBg.sprite = _bgAvailable;
        _objClaim.SetActive(false);
        _objAvailable.SetActive(false);
    }
}
public enum statusReward
{
    Locked,     // Bị khóa, không thể nhận được
    Claimed,   // Đã được nhận
    Available,  // Có sẵn để nhận
}
