﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashTowardsAction : GOAPAction
{
    private bool dashedForward = false;
    public int dashMultiplier = 100;
    public int staminaCost = 2;
    GameObject dashTowardsPoint;
    bool wayPointCreated = false;



    public dashTowardsAction()
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
        Warrior currentEnemy = agent.GetComponent<Warrior>();
        // Currently target is automatically set to Player, this will be made dynamic later, with "Player" set first and then it changes to whoever has caused it most damage.
        //Create a hidden target between the enemy and the player and have him move to that.
        GameObject player = GameObject.FindGameObjectWithTag("Player");


        Vector3 directionVector = Vector3.Normalize(player.transform.position - transform.position);
        if (!dashTowardsPoint)
        {

            dashTowardsPoint = new GameObject();
            dashTowardsPoint.name = "Dash towards";
            wayPointCreated = true;
        }
        //1 is dash time, we can change this

        dashTowardsPoint.transform.position = transform.position + directionVector * currentEnemy.dashDistance;
        target = dashTowardsPoint;

        //Will dash  only if has stamina to attack as well as dash
        if (currentEnemy.stamina >= staminaCost + 3)
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
       // currentEnemy.GetComponent<Rigidbody2D>().MovePosition(transform.position + Vector3.Normalize(target.transform.position - transform.position) * 2 * currentEnemy.movementSpeed * Time.deltaTime);
        //currentEnemy.GetComponent<Rigidbody2D>().AddForce(Vector3.Normalize(target.transform.position - transform.position) * currentEnemy.movementSpeed * dashMultiplier );
        currentEnemy.staminaRegen();
        currentEnemy.stamina -=  staminaCost;
        Debug.Log("dashed toward");
        //Play dash animation;
        dashedForward = true;
        return dashedForward;
    }

}
