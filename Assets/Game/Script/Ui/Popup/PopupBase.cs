using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CanvasGroup))]
public class PopupBase : MonoBehaviour
{
    public CanvasGroup _canvasGroup;
    protected virtual void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    public bool _isShow;
    public virtual void Show(object data = null)
    {
        _canvasGroup.alpha = 1;
        gameObject.SetActive(true);
    }
    public virtual void Hide()
    {
        _canvasGroup.DOFade(0, 1).From(1).SetEase(Ease.OutCubic).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
