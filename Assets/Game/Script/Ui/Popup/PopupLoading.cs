using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupLoading : PopupBase
{
    public TextMeshProUGUI _txt_LoadingValue;
    public Slider _sliderLoadingBar;
    public override void Show(object data = null)
    {
        gameObject.SetActive(true);
        StartCoroutine(CoroutineLoading());
    }
    IEnumerator CoroutineLoading()
    {
        int currentValues = 0;
        _txt_LoadingValue.text = $"Loading... {currentValues}%";
        _sliderLoadingBar.value = currentValues;
        while (currentValues < 100)
        {
            yield return new WaitForSeconds(Random.value / 10);
            currentValues++;
            _txt_LoadingValue.text = $"Loading... {currentValues}%";
            _sliderLoadingBar.value = currentValues;
        }
        yield return null;
        PopupController.Instance.HidePopup(TypePopup.PopupLoading);
        PopupController.Instance.ShowPopup(TypePopup.PopupHome);
    }
}
