using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectQuestStep : QuestStep
{
    public TypeCollect _typeCollect;
    public int _currCollect;
    public int _targetCollect = 5;
    public CollectQuestStep()
    {
    }
    private void UpdateCollected(int amount, TypeCollect typeTask)
    {
        if (_typeCollect != typeTask)
        {
            return;
        }
        if (_currCollect < _targetCollect)
        {
            _currCollect += amount;
            UpdateState();
        }

        if (-_currCollect >= _targetCollect)
        {
            FinishQuestStep();
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
    public void SetQuestStepCollectSO(QuestStepCollectSO data)
    {
        _targetCollect = data.target;
        _typeCollect = data._typeCollect;
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
