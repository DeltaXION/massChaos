using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : EnemyBaseClass
{
    // Start is called before the first frame update
    void Start()
    {
        base.createWallCollisionTriggers();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void InitializeEnemy(int dungeonLevel)
    {
        
    }

    public override bool moveAgent(GoapAction nextAction)
    {
        return base.moveAgent(nextAction);
    }
    public override HashSet<KeyValuePair<string, object>> createGoalState()
    {
        HashSet<KeyValuePair<string, object>> goal = new HashSet<KeyValuePair<string, object>>();
        goal.Add(new KeyValuePair<string, object>("hurtPlayer", true));
        goal.Add(new KeyValuePair<string, object>("Patrol", true));
        return goal;
    }
}
