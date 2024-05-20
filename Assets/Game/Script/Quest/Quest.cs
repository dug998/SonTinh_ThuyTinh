using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public Sprite _spIcon;
    public QuestStep _currQuestStep;

    public QuestInfoSO _questInfoData;

    public QuestState _questState;

    public int _currQuestStepIndex;

    public QuestStepState[] _questStepStates;

    public void NewQuest(QuestInfoSO questInfoData)
    {
        _questInfoData = questInfoData;
        _questState = QuestState.REQUIREMENTS_NOT_MET;
        _currQuestStepIndex = 0;
        _spIcon = questInfoData.questStepPrefabs[_currQuestStepIndex]._spIcon;
        _questStepStates = new QuestStepState[questInfoData.questStepPrefabs.Count];

        for (int i = 0; i < _questStepStates.Length; i++)
        {
            _questStepStates[i] = new QuestStepState();
        }
    }
    public void NewQuest(QuestInfoSO questInfo, QuestState questState, int currentQuestStepIndex, QuestStepState[] questStepStates)
    {
        _questInfoData = questInfo;
        _questState = questState;
        _currQuestStepIndex = currentQuestStepIndex;
        _spIcon = questInfo.questStepPrefabs[_currQuestStepIndex]._spIcon;
        _questStepStates = questStepStates;
    }
    public void MoveToNextStep()
    {
        _currQuestStepIndex++;
    }
    public bool CurrentStepExists()
    {
        return (_currQuestStepIndex < _questInfoData.questStepPrefabs.Count);
    }
    public void InitCurrentQuestStep()
    {
        if (!CurrentStepExists())
        {

            LogGame.LogError(" stepIndex was out of range ! " + _currQuestStepIndex + "_" + _questInfoData.questStepPrefabs.Count);
            return;
        }

        QuestStepSO questStepSO = _questInfoData.questStepPrefabs[_currQuestStepIndex];

        if (questStepSO.typeTask == TypeTask.CollectData || questStepSO.typeTask == TypeTask.UseData)
        {
            gameObject.AddComponent<CollectOrUseQuestStep>();
            _currQuestStep = gameObject.GetComponent<CollectOrUseQuestStep>();
            _currQuestStep.SetQuestStepCollectSO(questStepSO.typeTask, questStepSO.questStepCollectSO);
        }

        _spIcon = questStepSO._spIcon;
        _currQuestStep.InitQuestStep(this, _currQuestStepIndex, _questStepStates[_currQuestStepIndex].state);
    }
    public void StoreQuestStepState(QuestStepState questStepState, int stepIndex)
    {
        if (stepIndex < _questStepStates.Length)
        {
            _questStepStates[stepIndex].state = questStepState.state;
            _questStepStates[stepIndex].status = questStepState.status;
        }

    }
    public void GetQuestStepState()
    {
        QuestEvents.onQuestStepStateChange.Invoke(
            this,
            _currQuestStepIndex,
            new QuestStepState(_questStepStates[_currQuestStepIndex].state, _questStepStates[_currQuestStepIndex].status)
        );
    }
    public string GetFullStatusText()
    {
        string fullStatus = "";
        Debug.Log("index :" + _currQuestStepIndex);
        Debug.Log("index :" + _currQuestStepIndex + " __" + _questStepStates[_currQuestStepIndex].status);
        if (_questState == QuestState.REQUIREMENTS_NOT_MET)
        {
            fullStatus = "Requirements are not yet met to start this quest.";
        }
        else if (_questState == QuestState.CAN_START)
        {
            fullStatus = "This quest can be started!";
        }
        else
        {
            if (CurrentStepExists())
            {
                fullStatus += _questStepStates[_currQuestStepIndex].status;
            }
            if (_questState == QuestState.CAN_FINISH)
            {
                fullStatus += " The quest is ready to be turned in.";
            }
            else if (_questState == QuestState.FINISHED)
            {
                fullStatus += " The quest has been completed!";
            }
        }

        return fullStatus;
    }
}
