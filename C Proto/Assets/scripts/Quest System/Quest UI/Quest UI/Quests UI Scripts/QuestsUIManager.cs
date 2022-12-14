using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestsUIManager : MonoBehaviour
{
    public Quest displayedQuest;

    [SerializeField] TextMeshProUGUI questName;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] TextMeshProUGUI[] goals;
    void Start()
    {
        SetActiveQuest(displayedQuest.QuestName, displayedQuest.Description, displayedQuest.Goals.Count, displayedQuest.Goals);
    }

    public void SetActiveQuest(string questName, string description, int goalCount, List<Goal> goals)
    {
        this.questName.text = questName;
        this.description.text = description;
        for(int i = 0; i<3; i++)
        {
            if (i+1>goalCount)
            {
                this.goals[i].color = new Color32(0, 0, 0, 0);
            }
            else
            {
                this.goals[i].color = new Color32(0, 0, 0, 255);
                this.goals[i].text = goals[i].Description+" " + goals[i].CurrentAmount + "/" + goals[i].RequiredAmount;
            }
        }
    }
    
}
