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
        base.readSensorStatusAndUpdateFlags();

       
       
    }

    

    public override void staminaRegen()
    {
        stamina += staminaRegenRate;
    }

    public override void InitializeEnemy(int dungeonLevel)
    {
        
    }

   
    public override HashSet<KeyValuePair<string, object>> createGoalState()
    {
        HashSet<KeyValuePair<string, object>> goal = new HashSet<KeyValuePair<string, object>>();
        goal.Add(new KeyValuePair<string, object>("damagePlayer", true));
        //goal.Add(new KeyValuePair<string, object>("Patrol", true));
        return goal;
    }
}
