using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeAttackPlayerAction : GOAPAction
{
    private bool attacked = false;
    public int staminaCost = 3;


    public rangeAttackPlayerAction()
    {
        addPrecondition("playerInVision", true);
        addPrecondition("playerInCombatZone", true);

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
        return false;
    }

    public override bool checkProceduralPrecondition(GameObject agent)
    {

        // Currently target is automatically set to Player, this will be made dynamic later, with "Player" set first and then it changes to whoever has caused it most damage.

        target = GameObject.FindGameObjectWithTag("Player");

        Ranger currentEnemy = agent.GetComponent<Ranger>();

        //Can attack only if target is real, enemy is not hitstunned and there is enough stamina
        if (target != null && !currentEnemy.hitStunned && currentEnemy.stamina >= staminaCost) //here 5 is max stamina
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


        Ranger currentEnemy = agent.GetComponent<Ranger>();
        currentEnemy.stamina -= staminaCost;
        currentEnemy.attackPlayer();
        //Play attack animation;

        attacked = true;
        return attacked;
    }

    IEnumerator attackPlayerInSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);

    }


}
