using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupWinGame : PopupBase
{
    [Header(" ______ Button  _____ "), Space(20)]

    public ButtonBase _btnHome;
    public ButtonBase _btnContinue;
    public ButtonBase _btnReplay;

    [Header(" ___ Particle ___ "), Space(20)]

    public GameObject _parrentButtons;

    public GameObject _start_1;
    public GameObject _start_2;
    public GameObject _start_3;

    public GameObject _daggers_1;
    public GameObject _daggers_2;

    public GameObject _parGlow;
    public GameObject _txtVictory;
    private void Awake()
    {
        _btnHome.AddEvent(OnClickButtonHome);
        _btnContinue.AddEvent(OnClickButtonContinue);
        _btnReplay.AddEvent(OnClickButtonReplay);
    }
    public override void Show(object data = null)
    {
        base.Show(data);
        EffectShow();
        DOVirtual.DelayedCall(3, () =>
        {
            _isShow = true;
        });

    }
    public void HideNew(System.Action action)
    {
        _isShow = false;
        EffectHide();
        DOVirtual.DelayedCall(3, () =>
        {
            action?.Invoke();
            base.Hide();
        });
    }
    public void OnClickButtonHome()
    {
        if (!_isShow)
        {
            return;
        }
        HideNew(() =>
        {
            PopupController.Instance.ShowPopupHome(true);

        });
    }
    public void OnClickButtonContinue()
    {
        if (!_isShow)
        {
            return;
        }
        HideNew(() =>
        {
            PopupController.Instance.ShowPopupChoice(true);
        });
    }
    public void OnClickButtonReplay()
    {
        if (!_isShow)
        {
            return;
        }
        HideNew(() =>
        {
            GameManager.Instance.StartLevelGame();
        });
    }
    #region Effect
    [ContextMenu("show")]
    public void EffectShow()
    {
        _txtVictory.transform.DOScale(Vector3.one, 1f).From(0).SetEase(Ease.OutCubic).OnComplete(() =>
        {
            _txtVictory.GetComponent<RectTransform>().DOAnchorPosY(-240, 1).From(Vector2.zero).SetEase(Ease.OutBounce);
            LevelComplete();
        });
        _parGlow.transform.DOScale(Vector3.one, 2).From(0).SetEase(Ease.OutCubic);
    }
    public void LevelComplete()
    {
        DOVirtual.DelayedCall(1, () =>
        {
            StarsAnim();

            _daggers_1.GetComponent<RectTransform>().DORotate(new Vector3(0, 0, -15), 2).From(new Vector3(0, 0, 15));
            _daggers_1.transform.DOScale(Vector3.one, 2).OnComplete(() =>
            {
                _daggers_1.GetComponent<RectTransform>().DOAnchorPosY(10, 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
            });

            _daggers_2.GetComponent<RectTransform>().DORotate(new Vector3(0, 180, -15), 2).From(new Vector3(0, 180, 15));
            _daggers_2.transform.DOScale(Vector3.one, 2).OnComplete(() =>
            {
                _daggers_2.GetComponent<RectTransform>().DOAnchorPosY(10, 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
            });
            DOVirtual.DelayedCall(2, () =>
            {
                _parrentButtons.GetComponent<CanvasGroup>().DOFade(1, 2).From(0);
                _btnHome.transform.DOScale(Vector2.one, 1).SetDelay(0.2f);
                _btnReplay.transform.DOScale(Vector2.one, 1).SetDelay(0.4f);
                _btnContinue.transform.DOScale(Vector2.one, 1).SetDelay(0.6f);
            });
        });
    }
    void StarsAnim()
    {
        _start_1.transform.DOScale(Vector3.one, 2f).SetEase(Ease.OutElastic).From(Vector3.zero);
        _start_2.transform.DOScale(Vector3.one, 2f).SetEase(Ease.OutElastic).SetDelay(.1f).From(Vector3.zero);
        _start_3.transform.DOScale(Vector3.one, 2f).SetEase(Ease.OutElastic).SetDelay(.2f).From(Vector3.zero);
    }

    [ContextMenu("hide")]
    public void EffectHide()
    {
        _btnHome.transform.DOScale(Vector2.zero, .7f);
        _btnReplay.transform.DOScale(Vector2.zero, .7f).SetDelay(0.1f);
        _btnContinue.transform.DOScale(Vector2.zero, .7f).SetDelay(0.2f);

        _txtVictory.transform.DOScale(Vector3.zero, 0.5f);
        _txtVictory.GetComponent<RectTransform>().DOAnchorPosY(0, .7f).SetEase(Ease.InCubic);


        _parGlow.transform.DOScale(Vector3.zero, .5f).From(0);

        DOVirtual.DelayedCall(1, () =>
        {
            _start_1.transform.DOScale(Vector3.zero, .7f).SetEase(Ease.Linear).SetEase(Ease.InBack);
            _start_2.transform.DOScale(Vector3.zero, .7f).SetEase(Ease.Linear).SetDelay(.2f).SetEase(Ease.InBack);
            _start_3.transform.DOScale(Vector3.zero, .7f).SetEase(Ease.Linear).SetEase(Ease.InBack);
        });
        DOVirtual.DelayedCall(.5f, () =>
        {
            _daggers_1.transform.DOKill();
            _daggers_2.transform.DOKill();

            _daggers_1.GetComponent<RectTransform>().DORotate(new Vector3(0, 0, 15), 1).SetEase(Ease.InBack);
            _daggers_1.transform.DOScale(Vector3.zero, 1);

            _daggers_2.GetComponent<RectTransform>().DORotate(new Vector3(0, 180, 15), 1).SetEase(Ease.InBack);
            _daggers_2.transform.DOScale(Vector3.zero, 1);
        });

    }
    #endregion
}
