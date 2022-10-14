using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGoal : Goal
{
    public int EnemyID { get; set; }

    //�����������
    public KillGoal(int enemyID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.EnemyID = enemyID;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        CombatEvent.OnEnemyDeath += EnemyDeath;
    }

    void EnemyDeath(IEnemy enemy)
    {
        if (enemy.ID == this.EnemyID)
        {
            CurrentAmount++;
            Evaluate();
        }
    }
}
