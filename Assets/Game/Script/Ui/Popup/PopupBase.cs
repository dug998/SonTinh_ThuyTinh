using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBase : MonoBehaviour
{
    public virtual void Show(object data = null)
    {
        gameObject.SetActive(true);
    }
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
