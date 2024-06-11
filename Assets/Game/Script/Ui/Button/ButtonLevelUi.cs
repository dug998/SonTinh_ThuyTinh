using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLevelUi : ButtonBase
{
    [SerializeField] int _id;
    [SerializeField] bool _isLock;
    [SerializeField] TextMeshProUGUI _textTitle;
    [SerializeField] Image _spriteIcon;
    public DataLevel _data;
    public GameObject _objFocus;
    public GameObject _objLock;
    private void OnEnable()
    {
        AddEvent(OnChooseLevel);
    }
    public override void Init(object data)
    {
        (DataLevel dataCard, bool _isLock) _d = ((DataLevel dataCard, bool a))data;
        _data = _d.dataCard;
        _isLock = _d._isLock;

        _textTitle.text = _data._title;
        _id = _data._id;
        _spriteIcon.sprite = _data._spriteiIcon;
        _objLock.SetActive(_isLock);
    }
    public void OnChooseLevel()
    {
        if (_isLock)
        {
            PopupController.Instance.ShowPopup(TypePopup.PopupNotife, new DataMessage(TypeMessage.Success, "", " Please complete the levels first !"));
            return;
        }
        PopupController.Instance._popupChoiceLevel.ChooseLevel(this);
    }
    public void OnFocus(bool select)
    {
        _objFocus.SetActive(select);
    }

}
