using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemy base class, all enemy subtypes will inherit from this base class
//Abstract because we do not use this class on an object directly, we first need to create a derived class from it
public abstract class EnemyBaseClass : MonoBehaviour, IGoap
{

    //declaring variables common to all enemies;
    float health;
    float rangeOfVisibility;
    float attackSpeed;
    float attackDamage;
    float movementSpeed;
    float poise;
    float poiseRegenRate;
    bool enemyIsDead;
    bool enemyIsVulnerableToAttacks;
    float flinchTime;
    float staminaRegenRate;
    float stamina;
    string enemyClass;
    //difficulty modifier will be incremented when a dungeon is raided successfully
    int difficultyModifier;
    //Booleans for procedural preconditons (AI)
    bool hitStunned = false;
    //Booleans for worldstate
    bool playerSpotted = false;
    //Colliders and booleans for feeling walls
    public enemySurroundingSensor topSensor;
    public bool topIsEmpty;
    public enemySurroundingSensor rightSensor;
    public bool rightIsEmpty;
    public enemySurroundingSensor bottomSensor;
    public bool bottomIsEmpty;
    public enemySurroundingSensor leftSensor;
    public bool leftIsEmpty;
   
  
    public  virtual void Start()
    {
       
        
    }

    public abstract HashSet<KeyValuePair<string, object>> createGoalState ();

    //function will be replaced in enemysubclasses
    // Dungeon level will be passed to enemy to set difficulty
    public virtual void InitializeEnemy(int dungeonLevel)
    {

    }
   
    public void createWallCollisionTriggers()
    {
        //Create collision boxes proportional to enemy size
        
        Vector3 enemySize = GetComponent<Renderer>().bounds.size ;
        
        //Create colliders on all four sides to surround enemy
        
        BoxCollider2D rightCollider = rightSensor.gameObject.AddComponent<BoxCollider2D>();
        rightCollider.size = new Vector2(0.75f, 0.75f);
        rightCollider.offset = new Vector2(1, 0);
        rightCollider.isTrigger = true;

        BoxCollider2D leftCollider = leftSensor.gameObject.AddComponent<BoxCollider2D>();
        leftCollider.size = new Vector2(0.75f, 0.75f);
        leftCollider.offset = new Vector2(-1, 0);
        leftCollider.isTrigger = true;

        BoxCollider2D topCollider = topSensor.gameObject.AddComponent<BoxCollider2D>();
        topCollider.size = new Vector2(0.75f, 0.75f);
        topCollider.offset = new Vector2(0, 1);
        topCollider.isTrigger = true;

        BoxCollider2D bottomCollider = bottomSensor.gameObject.AddComponent<BoxCollider2D>();
        bottomCollider.size = new Vector2(0.75f, 0.75f);
        bottomCollider.offset = new Vector2(0, -1);
        bottomCollider.isTrigger = true;

    }

    public HashSet<KeyValuePair<string, object>> getWorldState()
    {
        HashSet<KeyValuePair<string, object>> worldData = new HashSet<KeyValuePair<string, object>>();
        worldData.Add(new KeyValuePair<string, object>("playerSpotted", playerSpotted));
        //Need to replace true,false with dynamic values, these will control the patrolling
        worldData.Add(new KeyValuePair<string, object>("leftEmpty", leftIsEmpty));
        worldData.Add(new KeyValuePair<string, object>("rightEmpty", rightIsEmpty));
        worldData.Add(new KeyValuePair<string, object>("topEmpty", topIsEmpty));
        worldData.Add(new KeyValuePair<string, object>("bottomEmpty", bottomIsEmpty));

        return worldData;
    }

    public void planFailed(HashSet<KeyValuePair<string, object>> failedGoal)
    {

    }

    public void planFound(HashSet<KeyValuePair<string, object>> goal, Queue<GoapAction> action)
    {

    }

    public void actionsFinished()
    {

    }

    public void planAborted(GoapAction aborter)
    {

    }

    public virtual bool moveAgent(GoapAction nextAction)
    {
        return false;
    }
    //updates variables that are required for AI to take a call on action
    void updateTheWorldStateForAI()
    {
        //playerSpotted true or false based on collision with trigger
        //playerSpotted can also be triggered when another enemy calls for help
        

    }

    

    //Sets playerSpotted to true if this enemy is in range of another enemy's cry for help
    public void enemyCallForHelp()
    {
        playerSpotted = true;
    }
    //Checking colliders to update player spotted
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            
            playerSpotted = true;
            Debug.Log("spotted");
        }
            
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        //Check if player ran from field of vision, if player is in field of vision, the enemy will be following them
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Seen!");
            playerSpotted = false;
        }


    }
    //read values from sensors and update flags
    public void readSensorStatusAndUpdateFlags()
    {
        GameObject topCollidedBody = topSensor.returnCollidedObject();
        GameObject bottomCollidedBody = bottomSensor.returnCollidedObject();
        GameObject rightCollidedBody = rightSensor.returnCollidedObject();
        GameObject leftCollidedBody = leftSensor.returnCollidedObject();
       
        //Check what topSensor has found, change corresponding flags
       if(topCollidedBody != null && topCollidedBody.CompareTag("Wall"))
        {
            topIsEmpty = false;
        } else
        {
            topIsEmpty = true;
        }
       //space for: Detecting traps

        //right sensor findings
        if (rightCollidedBody != null && rightCollidedBody.CompareTag("Wall"))
        {
            rightIsEmpty = false;
        }
        else
        {
            rightIsEmpty = true;
        }
        //left sensor findings
        if (leftCollidedBody != null && leftCollidedBody.CompareTag("Wall"))
        {
            leftIsEmpty = false;
        }
        else
        {
            leftIsEmpty = true;
        }
        //bottom sensor findings
        if (bottomCollidedBody != null && bottomCollidedBody.CompareTag("Wall"))
        {
            bottomIsEmpty = false;
        }
        else
        {
            bottomIsEmpty = true;
        }

    }



    // Update is called once per frame
    void Update()
    {
           
    }
}
