using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestStep : MonoBehaviour
{
    private bool isFinished = false;
    private Quest quest;
    private int stepIndex;

    public void InitQuestStep(Quest quest, int stepIndex, string questStepState = null)
    {
        this.quest = quest;
        this.stepIndex = stepIndex;
        if (questStepState != null && questStepState != "")
        {
            SetQuestStepState(questStepState);
        }
        StartStep();

    }
    public abstract void StartStep();
    public abstract void EndStep();

    protected void FinishQuestStep()
    {
        if (!isFinished)
        {
            isFinished = true;
            QuestEvents.onAdvanceQuest.Invoke(quest);
            EndStep();
            Destroy(this);
        }
    }
    protected void ChangeState(string newState, string newStatus)
    {
        QuestEvents.onQuestStepStateChange.Invoke(
             quest,
             stepIndex,
             new QuestStepState(newState, newStatus)
         );
    }
    protected abstract void SetQuestStepState(string state);
}