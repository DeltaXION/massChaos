using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackPlayerAction : GOAPAction
{
    private bool attacked = false;
    public int staminaCost = 3;


    public attackPlayerAction()
    {
        addPrecondition("playerNotInRange", false);
        addEffect("damagePlayer", true);
        cost = 1f;

        
        
    }
    public override void reset()
    {
        
        attacked = false;
        target = null;
    }

    public override bool isDone()
    {
        return attacked;
    }

    public override bool requiresInRange()
    {
        return true;
    }

    public override bool checkProceduralPrecondition(GameObject agent)
    {
        
        // Currently target is automatically set to Player, this will be made dynamic later, with "Player" set first and then it changes to whoever has caused it most damage.

        target = GameObject.FindGameObjectWithTag("Player");
       
        Warrior currentEnemy = agent.GetComponent<Warrior>();

        //Can attack only if target is real, enemy is not hitstunned and there is enough stamina
        if (target != null && !currentEnemy.hitStunned && currentEnemy.stamina >=  staminaCost) //here 5 is max stamina
        {

            return true;
        }
        else
        {

            return false;
        }
        
    }

    //run code that corresponds to performing the action. Returns true if performed successfully
    public override bool perform(GameObject agent)
    
    {
        
        target.GetComponent<playerTest>().health -= 1;
        Warrior currentEnemy = agent.GetComponent<Warrior>();
        currentEnemy.stamina -= staminaCost;
        currentEnemy.attackPlayer();
        //Play attack animation;
        attacked = true;
        return attacked;
    }

    
}
