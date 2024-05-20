using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjTextUi : MonoBehaviour
{
    public TextMeshProUGUI _txtText;
    public void SetText(string text)
    {
        _txtText.text = text;
    }
    public void Show(bool isShow = true)
    {
        gameObject.SetActive(isShow);

    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
