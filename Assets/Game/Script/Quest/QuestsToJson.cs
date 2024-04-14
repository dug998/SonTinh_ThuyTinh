using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestJson
{
    public QuestState state;
    public int questStepIndex;
    public QuestStepState[] questStepStates;

    public QuestJson(QuestState state, int questStepIndex, QuestStepState[] questStepStates)
    {
        this.state = state;
        this.questStepIndex = questStepIndex;
        this.questStepStates = questStepStates;
    }
}
public static class QuestsToJson
{
    public static Quest LoadQuest(QuestInfoSO questInfo)
    {
        Quest quest = null;
        try
        {
            if (PlayerPrefs.HasKey(questInfo.id))
            {
                string serializedData = PlayerPrefs.GetString(questInfo.id);
                QuestJson questData = JsonUtility.FromJson<QuestJson>(serializedData);
                quest = new Quest(questInfo, questData.state, questData.questStepIndex, questData.questStepStates);
            }
            // otherwise, initialize a new quest
            else
            {
                quest = new Quest(questInfo);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to load quest with id " + questInfo.id + ": " + e);
        }
        return quest;
    }
    public static void SaveQuest(Quest quest)
    {
        try
        {
            QuestJson questData = GetQuestJson(quest);
            string serializedData = JsonUtility.ToJson(questData);
            PlayerPrefs.SetString(quest._questInfoData.id, serializedData);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to save quest with id " + quest._questInfoData.id + ": " + e);
        }
    }
    public static QuestJson GetQuestJson(Quest quest)
    {
        return new QuestJson(quest._questState, quest._currQuestStepIndex, quest._questStepStates);
    }
}
