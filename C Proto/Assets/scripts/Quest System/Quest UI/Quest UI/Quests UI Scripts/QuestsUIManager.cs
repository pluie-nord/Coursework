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
    [SerializeField] TextMeshProUGUI[] goalsTrack;

    private string currentName;
    private string currentDescription;
    private int currentGoalCount;
    private List<Goal> currentGoals;


    public void SetCurrentActiveQuest(string questName, string description, int goalCount, List<Goal> goals)
    {
        this.currentName = questName;
        this.currentDescription = description;
        this.currentGoalCount = goalCount;
        this.currentGoals = goals;
    }

    public void SetActiveQuest()
    {
        this.questName.text = currentName;
        this.description.text = currentDescription;
        for(int i = 0; i<3; i++)
        {
            if (i+1> currentGoalCount)
            {
                this.goals[i].gameObject.SetActive(false);
            }
            else
            {
                this.goals[i].gameObject.SetActive(true);
                this.goals[i].text = currentGoals[i].Description;
            }
        }
        for (int i = 0; i < currentGoals.Count; i++)
        {
            goalsTrack[i].text = currentGoals[i].CurrentAmount + "/" + currentGoals[i].RequiredAmount;
        }
    }

    public void SetGoalTrecker()
    {
        print("Пересчет");
        for(int i = 0; i < currentGoals.Count; i++)
        {
            goalsTrack[i].text = currentGoals[i].CurrentAmount + "/" + currentGoals[i].RequiredAmount;
        }

    }
    
}
