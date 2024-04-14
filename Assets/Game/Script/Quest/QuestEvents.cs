using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuestEvents
{
    public static Action<Quest> onStartQuest;


    public static Action<Quest> onAdvanceQuest;


    public static Action<Quest> onFinishQuest;


    public static Action<Quest> onQuestStateChange;


    public static Action<Quest, int, QuestStepState> onQuestStepStateChange;

    public static Action<int> onPlayerLevelChange;

    // set amount
    public  static Action<int, TypeCollect> onCollect;
    public static void UpdateCollected(int amount, TypeCollect typeTask)
    {
        if (onCollect != null)
        {
            onCollect.Invoke(amount, typeTask);
        }
    }
}
