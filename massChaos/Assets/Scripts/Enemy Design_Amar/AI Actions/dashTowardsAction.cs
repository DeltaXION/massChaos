using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashTowardsAction : GOAPAction
{
    private bool dashedForward = false;
    public int dashMultiplier = 100;
    public int staminaCost = 3;
    
    
    public dashTowardsAction()
    {
        addPrecondition("playerNotInRange", true);
        //Ive set effect of damagePlayer to true to show its beneficial to the goal
        addEffect("damagePlayer", true);
        cost = 2f;      

        
        
    }
    public override void reset()
    {

        dashedForward = false;
        target = null;
    }

    public override bool isDone()
    {
        return dashedForward;
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
        currentEnemy.GetComponent<Rigidbody2D>().MovePosition(transform.position + Vector3.Normalize(target.transform.position - transform.position) * 2 * currentEnemy.movementSpeed * Time.deltaTime);
        //currentEnemy.GetComponent<Rigidbody2D>().AddForce(Vector3.Normalize(target.transform.position - transform.position) * currentEnemy.movementSpeed * dashMultiplier );

        currentEnemy.stamina -=  staminaCost;
        Debug.Log("dashed toward");
        //Play dash animation;
        dashedForward = true;
        return dashedForward;
    }

}
