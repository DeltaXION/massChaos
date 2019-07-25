using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Warrior : EnemyBaseClass
{
    Animator myAnimator;
    Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        base.createCollisionTriggers();
        myAnimator = GetComponent<Animator>();
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        base.readSensorStatusAndUpdateFlags();
        base.updateTheWorldStateForAI();
        setWalkingAnimation();
       
       
    }

    void setWalkingAnimation()
    {
        myAnimator.SetBool("moving", moving);
    }
    //animate damage particle system
    public override void animateDamage()
    {
        damageParticles.Play();
    }
    private IEnumerator AttackCoroutine()
    {
        myAnimator.SetBool("attacking", true);
        yield return null;
        
        myAnimator.SetBool("attacking", false);
        yield return new WaitForSeconds(0.2f);
        
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
    public override void attackPlayer()
    {
        StartCoroutine(AttackCoroutine());


       
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
