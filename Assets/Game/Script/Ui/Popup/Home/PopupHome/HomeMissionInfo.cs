using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HomeMissionInfo : MonoBehaviour
{
    public bool _isShow;
    public GameObject _main;
    [ReadOnly] public Quest _quest;
    public Image _imgIcon;
    public TextMeshProUGUI _txtTitle;
    public TextMeshProUGUI _txtDescription;
    public TextMeshProUGUI _txtState;
    public Queue<Quest> queueMission = new Queue<Quest>();
    private void OnEnable()
    {
        QuestEvents.onQuestStateChange += OnNotifeQuestState;
    }
    private void OnDisable()
    {
        QuestEvents.onQuestStateChange -= OnNotifeQuestState;
    }
    public void OnNotifeQuestState(Quest quest)
    {
        queueMission.Enqueue(quest);
        ShowNotife();
    }

    void ShowNotife()
    {
        if (_isShow)
        {
            return;
        }
        if (queueMission.Count <= 0)
        {
            return;
        }
        _main.SetActive(true);
        _quest = queueMission.Dequeue();
        _isShow = true;
        QuestInfoSO questdata = _quest._questInfoData;
        _imgIcon.sprite = _quest._spIcon;
        _txtTitle.text = questdata.displayName;
        ChangeQuestState(_quest);
        StartCoroutine(DelayCall(3, () =>
        {
            _isShow = false;
            if (queueMission.Count > 0)
            {
                ShowNotife();
            }

        }));
    }
    IEnumerator DelayCall(float delay, System.Action action)
    {
        yield return new WaitForSeconds(delay);
        action.Invoke();
    }
    public void ChangeQuestState(Quest quest)
    {
        if (_quest._questState == QuestState.CAN_START)
        {
            _txtState.text = "Can Start";
        }
        else if (_quest._questState == QuestState.IN_PROGRESS)
        {
            _txtState.text = "In Progress";

        }
        else if (_quest._questState == QuestState.CAN_FINISH)
        {
            _txtState.text = "Can Finish";

        }
        else if (_quest._questState == QuestState.FINISHED)
        {
            _txtState.text = "Finish";
        }
        _txtDescription.text = quest.GetFullStatusText();

    }
}
