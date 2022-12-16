using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkGoal : Goal
{
    public string StateID { get; set; }

    //конструктор
    public TalkGoal(Quest quest, string stateID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.StateID = stateID;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        TalkEvent.OnStateChanged += DrawPicture;
    }

    void DrawPicture(ITalk state)
    {
        if (state.stateID == this.StateID)
        {
            CurrentAmount++;
            Evaluate();
        }
    }
}
