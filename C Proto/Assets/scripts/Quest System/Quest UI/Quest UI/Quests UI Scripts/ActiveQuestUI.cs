using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActiveQuestUI : MonoBehaviour
{
    public Quest displayedQuest;
    private QuestsUIManager questsUIManager;

    [SerializeField] TextMeshProUGUI questName;
    void Start()
    {
        questsUIManager = FindObjectOfType<QuestsUIManager>();
        SetHiddenQuest(displayedQuest.QuestName);
    }

    public void SetHiddenQuest(string questName)
    {
        this.questName.text = questName;
    }

    public void HiddenToActive()
    {
        questsUIManager.SetActiveQuest(displayedQuest.QuestName, displayedQuest.Description, displayedQuest.Goals.Count, displayedQuest.Goals);
        Quest newActiveQuest = displayedQuest;
        displayedQuest = questsUIManager.displayedQuest;
        questsUIManager.displayedQuest = newActiveQuest;
    }

    private void OnMouseDown()
    {
        print("down");
        HiddenToActive();
        SetHiddenQuest(displayedQuest.QuestName);
    }

}
