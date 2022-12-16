using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestEventManager : MonoBehaviour
{
    [SerializeField] DioAgent[] dioAgents;

    [SerializeField] DialogueState[] triggerStates;

    private void Start()
    {
        QuestEvent.OnQuestCompleted += SetTriggeredState;
    }

    void SetTriggeredState(IQuest questID)
    {
        if(questID.ID<dioAgents.Length)
        {
            dioAgents[questID.ID].State = triggerStates[questID.ID];
            dioAgents[questID.ID].thisQuest = null;
            print("Listner activated");
        }

    }

}
