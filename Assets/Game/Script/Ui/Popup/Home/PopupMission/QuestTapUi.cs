using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestTapUi : MonoBehaviour
{
    public Quest _quest;
    public Image _imgIcon;
    public TextMeshProUGUI _txtName;
    public TextMeshProUGUI _txtDescription;
    public TextMeshProUGUI _txtProgress;

    public Slider _sliderProgress;
    public Button _btnClam;
    public Button _btnStart;
    private void Awake()
    {
        _btnClam.onClick.AddListener(() =>
        {
            QuestEvents.onFinishQuest.Invoke(_quest);
        });
        _btnStart.onClick.AddListener(() =>
        {
            QuestEvents.onStartQuest.Invoke(_quest);
        });
    }
    public void OnEnable()
    {
        QuestEvents.onQuestStateChange += ChangeQuestState;
        QuestEvents.onQuestStepStateChange += ChangeQuestStep;
    }
    private void OnDisable()
    {
        QuestEvents.onQuestStateChange -= ChangeQuestState;
        QuestEvents.onQuestStepStateChange -= ChangeQuestStep;
    }
    public void ChangeQuestState(Quest quest)
    {
        if (_quest != quest)
        {
            return;
        }
        _btnStart.gameObject.SetActive(false);

        _btnClam.gameObject.SetActive(false);

        if (_quest._questState == QuestState.CAN_START)
        {
            _btnStart.gameObject.SetActive(true);
        }
        else if (_quest._questState == QuestState.CAN_FINISH)
        {
            _btnClam.gameObject.SetActive(true);

        }
        LogGame.Log(" Quest state " + _quest._questState);
       if(quest._currQuestStep) UpdateProgress(quest._currQuestStep);
    }
    public void ChangeQuestStep(Quest quest, int stepIndex, QuestStepState questStepState)
    {
        if (_quest != quest)
        {
            return;
        }
        _txtDescription.text = quest.GetFullStatusText();
        UpdateProgress(quest._currQuestStep);
    }
    public void Init(Quest quest)
    {
        _quest = quest;
        QuestInfoSO questdata = quest._questInfoData;
        _imgIcon.sprite = quest._spIcon;
        _txtName.text = questdata.displayName;
        ChangeQuestState(_quest);

    }
    public void UpdateProgress(CollectQuestStep collectQuestStep)
    {

        DOTween.To(() => _sliderProgress.value, x => x = _sliderProgress.value, (float)collectQuestStep._currCollect / collectQuestStep._targetCollect, .5f);
        _txtProgress.text = collectQuestStep._currCollect + "/" + collectQuestStep._targetCollect;

    }
    public void OnClickClaim()
    {

    }

}
