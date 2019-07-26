using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ranger : EnemyBaseClass
{
    
    public GameObject rangeWeapon;

    public int arrowForce = 20;
    public float arrowRange = 5;
    Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        base.createCollisionTriggers();
        myAnimator = GetComponent<Animator>();
    }

    
    // Update is called once per frame
    void Update()
    {
        base.readSensorStatusAndUpdateFlags();
        base.updateTheWorldStateForAI();
        setWalkingAnimation();
       
       
    }

    //animate Damage using particle system
    public override void animateDamage()
    {
        damageParticles.Play();
    }

    void setWalkingAnimation()
    {
        myAnimator.SetBool("moving", moving);
    }

    public override void attackPlayer()
    {
        
        player = GameObject.FindGameObjectWithTag("dungeonPlayer");
        
        GameObject arrow = Instantiate(rangeWeapon, transform.position, Quaternion.identity);
        rangedWeaponBehavior currentArrow = arrow.GetComponent<rangedWeaponBehavior>();
        currentArrow.setTarget(arrowForce, player.transform.position, arrowRange);
    }

    public override void animateFacingDirection(string direction)
    {
        switch (direction)
        {
            case "left":
                myAnimator.SetFloat("moveX", -1);
                myAnimator.SetFloat("moveY", 0);
                break;
            case "right":
                myAnimator.SetFloat("moveX", 1);
                myAnimator.SetFloat("moveY", 0);
                break;
            case "up":
                myAnimator.SetFloat("moveX", 0);
                myAnimator.SetFloat("moveY", 1);
                break;
            case "down":
                myAnimator.SetFloat("moveX", 0);
                myAnimator.SetFloat("moveY", -1);
                break;

        }
    }
    public override void staminaRegen()
    {
       
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
