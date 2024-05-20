using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class PopupBase : MonoBehaviour
{
    public CanvasGroup _canvasGroup;
    public Button _btnBack;
    protected virtual void Awake()
    {
        if (_btnBack != null)
        {
            _btnBack.onClick.AddListener(Hide);
        }
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
        _canvasGroup.DOFade(0, 0.5f).From(1).SetEase(Ease.OutCubic).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
