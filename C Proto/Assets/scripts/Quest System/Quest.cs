using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : MonoBehaviour
{
    public List<Goal> Goals { get; set; } = new List<Goal>(); //проверить на функциональность (из туториала с .NET 4.6)
    public string QuestName { get; set; }
    public string Description { get; set; }
    public int EXPReward { get; set; }
    public InventoryItemData ItemReward { get; set; }
    public bool Completed { get; set; }
    public TutorialQuest_1 NextQuest { get; set; }
    public TutorialQuest_1 CurrentQuest { get; set; }
    public int QuestID { get; set; }

    public void CheckGoals()
    {
        Completed = Goals.All(g => g.Completed);
        if (Completed) GiveReward();
    }
    
    void GiveReward()
    {
        Debug.Log(" вест пройден ебана");
        QuestEvent.QuestCompleted(CurrentQuest);
        Debug.Log(NextQuest);
        if(NextQuest!=null) //если за квестом следует другой
            CurrentQuest.nextQuest.SetQuest();
        if (ItemReward != null)
            InventorySystem.Instance.Add(ItemReward);

    }

    public void ResetAmount()
    {
        FindObjectOfType<QuestsUIManager>().SetGoalTrecker();
    }

}
