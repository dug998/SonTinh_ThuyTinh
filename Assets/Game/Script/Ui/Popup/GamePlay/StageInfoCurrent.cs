using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageInfoCurrent : MonoBehaviour
{
    [Header(" --- ")]
    public Slider _sliderBar_Stage;
    public List<RectTransform> _stagePrgPointers;
    public RectTransform _stagePrgPointerStart, _stagePrgPointerEnd;
    public int index;
    public List<float> _dataStageInfos;

    [Header(" --- "), Space(30)]
    public GameObject _bossWarning;
    public GameObject _StageWarning;
    public TextMeshProUGUI _txtStage;
    public void Init(List<float> _dataStageInfos)
    {
        this._dataStageInfos = _dataStageInfos;
        for (int i = 0; i < _stagePrgPointers.Count; i++)
        {
            if (i < _dataStageInfos.Count - 1)
            {
                _stagePrgPointers[i].gameObject.SetActive(true);
                _stagePrgPointers[i].anchoredPosition =
             new Vector2((_stagePrgPointerEnd.anchoredPosition.x - _stagePrgPointerStart.anchoredPosition.x) * _dataStageInfos[i] + _stagePrgPointerStart.anchoredPosition.x, _stagePrgPointers[i].anchoredPosition.y);
            }
            else
            {
                _stagePrgPointers[i].gameObject.SetActive(false);
            }
        }

    }
    public void OnChangeValuesSliderBar(float values)
    {
        DOTween.To(() => _sliderBar_Stage.value, x => _sliderBar_Stage.value = x, values, .5f);
    }


    public void StartOneStage(int index)
    {
        Debug.Log("start turn :" + index);
        _StageWarning.SetActive(true);
        _txtStage.text = $"Stage : {index}";
        DOVirtual.DelayedCall(2, () =>
        {
            _StageWarning.SetActive(false);
        });
    }

    public void EndOneStage(int index)
    {
        Debug.Log("end turn :" + index);
    }
}
