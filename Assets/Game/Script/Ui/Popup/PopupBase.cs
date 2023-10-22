using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CanvasGroup))]
public class PopupBase : MonoBehaviour
{
    public bool _isShow;
    public virtual void Show(object data = null)
    {
        GetComponent<CanvasGroup>().DOFade(1, 1).From(0).SetEase(Ease.InCubic);
        gameObject.SetActive(true);
    }
    public virtual void Hide()
    {
        GetComponent<CanvasGroup>().DOFade(0, 1).From(1).SetEase(Ease.OutCubic).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
