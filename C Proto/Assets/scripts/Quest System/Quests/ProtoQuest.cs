using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoQuest : Quest
{
    void Start()
    {
        QuestName = "Лисоебы";
        Description = "Лисички такие вкусные... Подождиде, вы не про грибы?";
        ItemReward = null;
        Goals.Add(new DrawGoal(this, 1, "Зарисуйте 1 лису", false, 0, 1));
        Goals.ForEach(g => g.Init());
        print("Quest setted");
    }

    
}
