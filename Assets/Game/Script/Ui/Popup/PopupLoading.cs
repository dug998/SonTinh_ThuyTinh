using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupLoading : PopupBase
{
    public RectTransform _title;

    public override void Show(object data = null)
    {
        gameObject.SetActive(true);
        _title.DOAnchorPosY(20, 2).From(Vector2.zero).SetEase(Ease.OutQuad);
    }
}
