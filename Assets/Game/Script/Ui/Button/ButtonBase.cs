using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class ButtonBase : MonoBehaviour
{
    public Button _btn;
    protected virtual void Awake()
    {

    }
    public virtual void AddEvent(UnityAction action)
    {
        _btn.onClick.RemoveListener(action);
        _btn.onClick.AddListener(action);
    }
    public void RemoveAll()
    {
        _btn.onClick.RemoveAllListeners();
    }
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
    public virtual void Activity(bool values)
    {

        _btn.enabled = values;
    }

    public abstract void Init(object data);

}
