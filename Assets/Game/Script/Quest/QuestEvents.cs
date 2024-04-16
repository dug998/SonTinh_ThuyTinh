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
    public static Action<int, TypeCollectOrUse> onCollect;
    public static void UpdateCollected(int amount, TypeCollectOrUse typeTask)
    {
        if (onCollect != null)
        {
            onCollect.Invoke(amount, typeTask);
        }
    }
}
