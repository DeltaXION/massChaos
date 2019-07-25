using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashAwayWarriorAction : GOAPAction
{
    private bool dashedAway = false;
    public int dashMultiplier = 100;
    bool dashSuccessful;
    bool dashPossible;

    public int staminaCost = 2;
    bool wayPointCreated = false;
    GameObject dashAwayPoint;


    public dashAwayWarriorAction()
    {

        addPrecondition("playerInVision", true);
        addPrecondition("playerInCombatZone", true);
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
        return true;
    }

    public override bool checkProceduralPrecondition(GameObject agent)
    {
        Warrior currentEnemy = agent.GetComponent<Warrior>();
        // Currently target is automatically set to Player, this will be made dynamic later, with "Player" set first and then it changes to whoever has caused it most damage.
        //Create a hidden target behind the enemy in the direction of the player and have him move to that.

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        //Creating a raycast to track colliders, opposite to direction of player
        //THIS NEEDS A LAYER CALLED ENEMIES TO PUT THE ENEMIES ON.
        int layerMask = ~(1 << LayerMask.NameToLayer("enemy"));
        Vector3 directionVector = Vector3.Normalize(player.transform.position - transform.position);
        RaycastHit2D rayCastToPlayer = Physics2D.Raycast(transform.position, directionVector * -1, currentEnemy.dashDistance, layerMask);
        //check if raycast touched any colliders in dash away range,it wont be possible if there are obstructions
        if (rayCastToPlayer.collider == null)
        {
            dashPossible = true;
        }
        else
        {
            dashPossible = false;

        }

        if (!wayPointCreated)
        {

            dashAwayPoint = new GameObject();
            dashAwayPoint.name = "Dash Away";
            wayPointCreated = true;
        }
        //1 is dash time, we can change this

        dashAwayPoint.transform.position = transform.position + directionVector * -currentEnemy.dashDistance;
        target = dashAwayPoint;



        //Will dash  only if stamina
        if (currentEnemy.stamina >= staminaCost && dashPossible)
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
        Destroy(dashAwayPoint);
        wayPointCreated = false;
        Warrior currentEnemy = agent.GetComponent<Warrior>();

        currentEnemy.stamina -= staminaCost;
        Debug.Log("dashed away");
        //Play dash animation;
        dashedAway = true;
        
        return dashedAway;
    }

}
