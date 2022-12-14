using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialQuest_1 : Quest
{
    public string questName;
    public string description;
    [SerializeField] InventoryItemData itemReward;
    public int[] itemID;
    public int goalsNumber;
    public string[] goalsDescription;
    public int[] itemsNumber;
    public void SetQuest()
    {
        QuestName = questName;
        Description = description;
        ItemReward = itemReward;
        for(int i=0; i<goalsNumber; i++)
        {
            Goals.Add(new DrawGoal(this, itemID[i], goalsDescription[i], false, 0, itemsNumber[i]));
        }
        Goals.ForEach(g => g.Init());
        print("Quest setted"+questName);
    }
}
