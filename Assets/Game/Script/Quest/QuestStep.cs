using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestStep : MonoBehaviour
{
    private bool isFinished = false;
    protected Quest quest;

    protected TypeTask _typeTask;
    private int stepIndex;

    public virtual void InitQuestStep(Quest quest, int stepIndex, string questStepState = null)
    {
        isFinished = false;
        this.quest = quest;
        this.stepIndex = stepIndex;
        StartStep();

    }
    public abstract void StartStep();
    public abstract void EndStep();

    protected void FinishQuestStep()
    {
        if (isFinished)
        {
            return;
        }
        isFinished = true;
        QuestEvents.onAdvanceQuest.Invoke(quest);
        EndStep();
        Destroy(this);
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
    public abstract void SetQuestStepCollectSO(TypeTask typeTask, QuestStepCollectSO data);
}