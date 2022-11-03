using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class Goal 
{
    public Quest Quest { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }
    public int CurrentAmount { get; set; }
    public int RequiredAmount { get; set; }

    public virtual void Init()
    {
        //default init staff
    }

    public void Evaluate()
    {
        
        if (CurrentAmount>=RequiredAmount)
        {
            Complete();
        }
    }

    public void Complete()
    {
        Completed = true;
        Quest.CheckGoals();
    }

}
