using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoQuest : Quest
{
    public void SetQuest()
    {
        QuestName = "Хвосты и уши";
        Description = "Малышка Аня очень просить нарисовать ей лисичку. Огненно-рыжую, с пышным хвостиком. Вы же не станете расстраивать ребенка?";
        ItemReward = null;
        Goals.Add(new DrawGoal(this, 1, "Зарисовать 1 лису", false, 0, 1));
        Goals.ForEach(g => g.Init());
        print("Quest setted");
    }

    
}
