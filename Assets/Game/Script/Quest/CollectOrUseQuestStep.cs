using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectOrUseQuestStep : QuestStep
{
    public TypeCollectOrUse _typeCollect;
    public int _currCollect;
    public int _targetCollect = 5;
    public override void InitQuestStep(Quest quest, int stepIndex, string questStepState = null)
    {
        base.InitQuestStep(quest, stepIndex, questStepState);
        if (questStepState != null)
        {
            SetQuestStepState(questStepState != "" ? questStepState : "0");
        }
    }
    private void UpdateCollected(int amount, TypeCollectOrUse typeTask)
    {
        if (_typeCollect != typeTask)
        {
            return;
        }
        if (amount < 0 && _typeTask == TypeTask.CollectData)
        {
            return;
        }
        else if (amount > 0 && _typeTask == TypeTask.UseData)
        {
            return;
        }
        if (_currCollect < _targetCollect)
        {
            _currCollect += Mathf.Abs(amount);
            UpdateState();
        }

        if (_currCollect >= _targetCollect)
        {
            FinishQuestStep();
            Debug.Log("Finish");
        }
    }
    void UpdateState()
    {
        string state = _currCollect.ToString();
        string status = " Collected " + _currCollect + "/" + _targetCollect;
        ChangeState(state, status);

    }
    protected override void SetQuestStepState(string state)
    {
        this._currCollect = System.Int32.Parse(state);
        UpdateState();
    }
    public override void SetQuestStepCollectSO(TypeTask typeTask, QuestStepCollectSO data)
    {
        _targetCollect = data.target;
        _typeCollect = data._typeCollect;
        _typeTask = typeTask;
    }
    public override void StartStep()
    {
        QuestEvents.onCollect += UpdateCollected;

    }
    public override void EndStep()
    {
        QuestEvents.onCollect -= UpdateCollected;

    }
}
