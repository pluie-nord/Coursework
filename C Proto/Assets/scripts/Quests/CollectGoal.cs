using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGoal : Goal
{
    public int ItemID { get; set; }

    //конструктор
    public CollectGoal(Quest quest, int itemID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.ItemID = itemID;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        InventorySystem.OnCollectItem += CollectItem;
    }

    void CollectItem(IItem item)
    {
        if (item.ID == this.ItemID)
        {
            CurrentAmount++;
            Evaluate();
        }
    }
}
