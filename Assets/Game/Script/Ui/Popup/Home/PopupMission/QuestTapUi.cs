using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestTapUi : MonoBehaviour
{
    [ReadOnly] public Quest _quest;
    public Image _imgIcon;
    public TextMeshProUGUI _txtName;
    public TextMeshProUGUI _txtDescription;
    public TextMeshProUGUI _txtProgress;

    public Slider _sliderProgress;
    public Button _btnClam;
    public Button _btnStart;

    public ItemUi _itemUi, _itemUiDemo;
    [Header(" data ")]
    [ReadOnly] public Reward _rewards;
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
            _itemUi.gameObject.SetActive(true);

        }
        else if (_quest._questState == QuestState.FINISHED)
        {
        }
        _txtDescription.text = quest.GetFullStatusText();
        UpdateProgress((CollectOrUseQuestStep)_quest._currQuestStep);
    }
    public void ChangeQuestStep(Quest quest, int stepIndex, QuestStepState questStepState)
    {
        if (_quest != quest)
        {
            return;
        }
        _txtDescription.text = quest.GetFullStatusText();
        UpdateProgress((CollectOrUseQuestStep)quest._currQuestStep);
    }
    public void Init(Quest quest)
    {
        _quest = quest;
        QuestInfoSO questdata = _quest._questInfoData;
        _imgIcon.sprite = _quest._spIcon;
        _txtName.text = questdata.displayName;
        _rewards = questdata._itemRewards;

        _itemUi.Init(_rewards._ItemSO, _rewards._valuesRw);
        _itemUiDemo.Init(_rewards._ItemSO, _rewards._valuesRw);
        _itemUi.gameObject.SetActive(false);
        ChangeQuestState(_quest);

    }
    public void UpdateProgress(CollectOrUseQuestStep collectQuestStep)
    {
        bool isNullStep = collectQuestStep == null;
        _sliderProgress.gameObject.SetActive(!isNullStep);
        _txtProgress.gameObject.SetActive(!isNullStep);
        if (isNullStep)
        {
            return;
        }
        DOTween.To(() => _sliderProgress.value, x => x = _sliderProgress.value, (float)collectQuestStep._currCollect / collectQuestStep._targetCollect, .5f);
        _txtProgress.text = collectQuestStep._currCollect + "/" + collectQuestStep._targetCollect;

    }
    public void OnClickClaim()
    {
        PopupController.Instance.ShowPopup(TypePopup.PopupReward, _rewards);
    }

}
