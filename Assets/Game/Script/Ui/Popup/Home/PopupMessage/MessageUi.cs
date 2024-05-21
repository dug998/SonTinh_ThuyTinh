using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageUi : MonoBehaviour
{
    public bool _isShow;
    public TextMeshProUGUI _txtTitle;
    public TextMeshProUGUI _txtDesc;
    public Color _colorTitle = Color.white;
    public Color _colorDesc = Color.white;

    public void Show()
    {
        _isShow = true;
        gameObject.SetActive(true);
      
      
    }
    public void Hide()
    {
        _isShow = false;
        gameObject.SetActive(false);
    }
   
    public void SetMessage(DataMessage data)
    {
        if (_txtTitle != null) _txtTitle.text = data._title;
        if (_txtDesc != null) _txtDesc.text = data._desc;
        _colorTitle = data._colorTitle;
        _colorDesc = data._colorDesc;
    }

}
public class DataMessage
{
    public TypeMessage _typeMessage;
    public string _title;
    public string _desc;
    public Color _colorTitle = Color.white;
    public Color _colorDesc = Color.white;
    public DataMessage(TypeMessage typeMessage, string title, string desc, Color colorTitle, Color colorDesc)
    {
        _typeMessage = typeMessage;
        _title = title;
        _desc = desc;
        _colorTitle = colorTitle;
        _colorDesc = colorDesc;
    }
    public DataMessage(TypeMessage typeMessage, string title, string desc)
    {
        _typeMessage = typeMessage;
        _title = title;
        _desc = desc;
    }
}

public enum TypeMessage
{
    None,
    Error,
    Success,
}
