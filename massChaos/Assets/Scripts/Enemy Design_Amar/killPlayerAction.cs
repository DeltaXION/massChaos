using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayerAction : GOAPAction
{
    private bool playerDead = false;
    
    
    
    public killPlayerAction()
    {
        addPrecondition("damagePlayer", true);
        addEffect("killPlayer", true);
        cost = 1f;

        
        
    }
    public override void reset()
    {

        playerDead = false;
        target = null;
    }

    public override bool isDone()
    {
        return playerDead;
    }

    public override bool requiresInRange()
    {
        return false;
    }

    public override bool checkProceduralPrecondition(GameObject agent)
    {
        // Currently target is automatically set to Player, this will be made dynamic later, with "Player" set first and then it changes to whoever has caused it most damage.

        target = GameObject.FindGameObjectWithTag("Player");
       
        Warrior currentEnemy = agent.GetComponent<Warrior>();

        //Will run only if enemy is dead,
        if (target != null) {
            return true;
        } else
        {
            return false;
        }
      
    }

    //run code that corresponds to performing the action. Returns true if performed successfully
    public override bool perform(GameObject agent)
    
    {

        Debug.Log("player dead");
        //Play attack animation;
        playerDead = true;
        return playerDead;
    }

}
