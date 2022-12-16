using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestEvent : MonoBehaviour
{
    public delegate void QuestHandler(IQuest quest);
    public static event QuestHandler OnQuestCompleted;

    public static void QuestCompleted(IQuest quest)
    {
        OnQuestCompleted?.Invoke(quest);
    }
}
