using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashTowardsRangerAction : GOAPAction
{
    private bool dashedForward = false;
    bool dashPossible = false;
    public int dashMultiplier = 100;
    public int staminaCost = 2;
    GameObject dashTowardsPoint;
    bool wayPointCreated = false;
    bool dashSuccessful;



    public dashTowardsRangerAction()
    {
        addPrecondition("playerInVision", true);
        addPrecondition("playerInCombatZone", false);
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
        return true;
    }

    public override bool checkProceduralPrecondition(GameObject agent)
    {
        Ranger currentEnemy = agent.GetComponent<Ranger>();
        // Currently target is automatically set to Player, this will be made dynamic later, with "Player" set first and then it changes to whoever has caused it most damage.
        //Create a hidden target between the enemy and the player and have him move to that.
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        //check if dash is possible acc to surrounding


        //Creating a raycast to track colliders
        int layerMask = ~(1 << LayerMask.NameToLayer("enemy"));
       Vector3 directionVector = Vector3.Normalize(player.transform.position - transform.position);
        RaycastHit2D rayCastToPlayer = Physics2D.Raycast(transform.position, directionVector, currentEnemy.dashDistance,layerMask);
       
        if (rayCastToPlayer.collider==null)
        {
            dashPossible = true;
        }
        else
        {
            if(rayCastToPlayer.collider.gameObject.CompareTag("Player"))
            {
                dashPossible = true;
            } else
            {
                dashPossible = false;
            }
            
        }

        if (!wayPointCreated)
        {

            dashTowardsPoint = new GameObject();
            dashTowardsPoint.name = "Dash towards";
            wayPointCreated = true;
        }
        // Dash by dash distance or by as much as the wall allows
        float closestWallDistance = rayCastToPlayer.distance;
        closestWallDistance = Mathf.Abs(closestWallDistance);

        if (rayCastToPlayer.collider!=null && closestWallDistance < currentEnemy.dashDistance)
        {
            
            dashTowardsPoint.transform.position = transform.position + directionVector * (closestWallDistance);
        } else
        {
            dashTowardsPoint.transform.position = transform.position + directionVector * (currentEnemy.dashDistance );
        }
        
        
        target = dashTowardsPoint;

        //Will dash  only if has stamina to attack as well as dash
        if (currentEnemy.stamina >= staminaCost + 3 &&dashPossible)
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
       // currentEnemy.GetComponent<Rigidbody2D>().MovePosition(transform.position + Vector3.Normalize(target.transform.position - transform.position) * 2 * currentEnemy.movementSpeed * Time.deltaTime);
        //currentEnemy.GetComponent<Rigidbody2D>().AddForce(Vector3.Normalize(target.transform.position - transform.position) * currentEnemy.movementSpeed * dashMultiplier );
        currentEnemy.staminaRegen();
        currentEnemy.stamina -=  staminaCost;
        Debug.Log("dashed toward");
        //Play dash animation;
        dashedForward = true;
        if (currentEnemy.bottomIsEmpty == false || currentEnemy.topIsEmpty == false || currentEnemy.rightIsEmpty == false || currentEnemy.leftIsEmpty == false)
        {
            dashSuccessful = false;
        } else
        {
            dashSuccessful = true;
        }
        return dashSuccessful;
    }

}
