using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGameManager : MonoBehaviour
{

    public static QuestGameManager instance;
    [SerializeField] private bool loadQuestState = true;

    public Dictionary<string, Quest> questMap;
    public List<QuestInfoSO> allQuests;
    [Button]
    public void UpdateCollect()
    {
        QuestEvents.UpdateCollected(3, TypeCollectOrUse.Gold);
    }
    private void Awake()
    {
        instance = this;
        questMap = CreateQuestMap();
        StartCoroutine(UpdateQuestNew());

    }
    public IEnumerator UpdateQuestNew()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            foreach (var quest in questMap.Values)
            {
                if (quest._questState == QuestState.REQUIREMENTS_NOT_MET && CheckRequirementsMet(quest))
                {
                    ChangeQuestState(quest, QuestState.CAN_START);
                    Debug.Log("start ");
                }
            }
        }
    }
    private void OnEnable()
    {
        QuestEvents.onStartQuest += StartQuest;
        QuestEvents.onAdvanceQuest += AdvanceQuest;
        QuestEvents.onFinishQuest += FinishQuest;
        QuestEvents.onQuestStepStateChange += QuestStepStateChange;

    }

    private void OnDisable()
    {
        QuestEvents.onStartQuest -= StartQuest;
        QuestEvents.onAdvanceQuest -= AdvanceQuest;
        QuestEvents.onFinishQuest -= FinishQuest;
        QuestEvents.onQuestStepStateChange -= QuestStepStateChange;
    }
    private bool CheckRequirementsMet(Quest quest)
    {
        // start true and prove to be false
        bool meetsRequirements = true;
        return true;

    }
    private void ChangeQuestState(Quest quest, QuestState state)
    {
        quest._questState = state;
        QuestEvents.onQuestStateChange?.Invoke(quest);
        NotifyQuestCanFinish();
    }

    private void StartQuest(Quest quest)
    {
        quest.InitCurrentQuestStep();
        ChangeQuestState(quest, QuestState.IN_PROGRESS);
    }

    private void AdvanceQuest(Quest quest)
    {
        quest.MoveToNextStep();
        if (quest.CurrentStepExists())
        {
            quest.InitCurrentQuestStep();
        }
        else
        {
            ChangeQuestState(quest, QuestState.CAN_FINISH);
        }

    }

    private void FinishQuest(Quest quest)
    {
        LogGame.Log(" Finish " + quest._questInfoData.displayName);
        ChangeQuestState(quest, QuestState.FINISHED);
    }
    public void NotifyQuestCanFinish()
    {
        foreach (var quest in questMap.Values)
        {
            if (quest._questState == QuestState.CAN_FINISH)
            {
                EventGame.OnNotifyQuest.Invoke(true);
                return;
            }
        }
        EventGame.OnNotifyQuest.Invoke(false);
    }

    private void QuestStepStateChange(Quest quest, int stepIndex, QuestStepState questStepState)
    {
        quest.StoreQuestStepState(questStepState, stepIndex);
        ChangeQuestState(quest, quest._questState);
    }

    private Dictionary<string, Quest> CreateQuestMap()
    {
        Dictionary<string, Quest> idToQuestMap = new Dictionary<string, Quest>();
        foreach (QuestInfoSO questInfo in allQuests)
        {
            if (idToQuestMap.ContainsKey(questInfo.id))
            {
                Debug.LogWarning("Duplicate ID found when creating quest map: " + questInfo.id);
            }
            idToQuestMap.Add(questInfo.id, QuestsToJson.LoadQuest(questInfo));
        }
        return idToQuestMap;
    }

}
