using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashAwayAction : GOAPAction
{
    private bool dashedAway = false;
    public int dashMultiplier = 100;
    public int staminaCost = 3;
    
    public dashAwayAction()
    {
        addPrecondition("playerNotInRange", false);
        //Dash away when you're low on stamina
        addPrecondition("lowStamina", true);
        //Ive set effect of damagePlayer to true to show its beneficial to the goal
        addEffect("damagePlayer", true);
        //TODO- change cost based on health of enemy
        cost = 1f;      

        
        
    }
    public override void reset()
    {

        dashedAway = false;
        target = null;
    }

    public override bool isDone()
    {
        return dashedAway;
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

        //Will dash  only if stamina
        if(currentEnemy.stamina >staminaCost)
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
        Warrior currentEnemy = agent.GetComponent<Warrior>();
        currentEnemy.GetComponent<Rigidbody2D>().MovePosition(transform.position + Vector3.Normalize(target.transform.position - transform.position) * 2 * currentEnemy.movementSpeed * Time.deltaTime*-1);
        //currentEnemy.GetComponent<Rigidbody2D>().AddForce(Vector3.Normalize(target.transform.position - transform.position) * currentEnemy.movementSpeed * dashMultiplier *-1 );

        currentEnemy.stamina -=  staminaCost;
        Debug.Log("dashed away");
        //Play dash animation;
        dashedAway = true;
        return dashedAway;
    }

}
