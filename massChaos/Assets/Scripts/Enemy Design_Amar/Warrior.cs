using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Warrior : EnemyBaseClass
{
    // Start is called before the first frame update
    void Start()
    {
        base.createCollisionTriggers();
        
    }

    // Update is called once per frame
    void Update()
    {
        base.readSensorStatusAndUpdateFlags();
        base.updateTheWorldStateForAI();
        
       
       
    }


    public override void attackPlayer()
    {
        Debug.Log("sword attack player");
    }
    public override void staminaRegen()
    {
        Debug.Log("Stamina update" + stamina);
        if (stamina < maxStamina)
        {
            stamina += staminaRegenRate;
        }
    }

    public override void InitializeEnemy(int dungeonLevel)
    {
        
    }

   
    public override HashSet<KeyValuePair<string, object>> createGoalState()
    {
        HashSet<KeyValuePair<string, object>> goal = new HashSet<KeyValuePair<string, object>>();
        goal.Add(new KeyValuePair<string, object>("damagePlayer", true));
        goal.Add(new KeyValuePair<string, object>("patrol", true));
        return goal;
    }
}
