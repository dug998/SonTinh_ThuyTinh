using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeScrollViewController : MonoBehaviour, IEndDragHandler
{
    public int _maxPages;
    int _currentPage;
    public Vector3 _targetPos;
    public Vector3 _pageStep;
    public RectTransform _levelPagesRect;

    [Header(" ---- Button ---- ")]
    public ButtonBase _btnNext;
    public ButtonBase _btnPrev;
    private void Awake()
    {
        _currentPage = 1;
        _targetPos = _levelPagesRect.localPosition;

        _btnNext.AddEvent(Next);
        _btnPrev.AddEvent(Previous);
    }
    [ContextMenu("next")]
    public void Next()
    {
        Debug.Log("next");
        if (_currentPage < _maxPages)
        {
            _currentPage++;
            _targetPos += _pageStep;
            MovePage();
        }
    }
    [ContextMenu("Previous")]
    public void Previous()
    {
        if (_currentPage > 1)
        {
            _currentPage--;
            _targetPos -= _pageStep;
            MovePage();

        }
    }
    void MovePage()
    {
        _levelPagesRect.DOLocalMove(_targetPos, 1);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.position.x - eventData.pressPosition.x) > 20)
        {
            if (eventData.position.x > eventData.pressPosition.x)
            {
                Previous();
            }
            else
            {
                Next();
            }
        }
        else
        {
            MovePage();
        }
    }
}
