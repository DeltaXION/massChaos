using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemy base class, all enemy subtypes will inherit from this base class
//Abstract because we do not use this class on an object directly, we first need to create a derived class from it
public abstract class EnemyBaseClass : MonoBehaviour, IGOAP
{

    //declaring variables common to all enemies;
    //minimum distance between enemy and other things
    public float minimumDistanceToInteract;
    public float health;
    public float maxStamina = 5;
    float rangeOfVisibility;
    float attackSpeed;
    float attackDamage;
    public float movementSpeed;
    public float poise;
    float poiseRegenRate;
    bool enemyIsDead;
    float flinchTime;
    public float staminaRegenRate;
    public float stamina;
    string enemyClass;
    //need to replace getPlayerHealth with actual script
    playerTest getPlayerHealth;
    //difficulty modifier will be incremented when a dungeon is raided successfully
    int difficultyModifier;
    //Booleans for procedural preconditons (AI)
    public bool hitStunned = false;
    //Booleans for worldstate
    bool playerNotInRange = true;
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
    bool playerDeath = false;

    void Start()
    {
       
        
    }

   
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

    //The AI will basically try to change worldState variables as a goal, one of the actions should end with the variable declared as goal changing. if this has to be repeated, this variable value should change in world state
    public HashSet<KeyValuePair<string, object>> getWorldState()
    {
        //replace getPlayerHealth with value from combat system player controller
        
        HashSet<KeyValuePair<string, object>> worldData = new HashSet<KeyValuePair<string, object>>();
        worldData.Add(new KeyValuePair<string, object>("playerNotInRange", playerNotInRange));
        worldData.Add(new KeyValuePair<string, object>("playerSpotted", playerSpotted));
        worldData.Add(new KeyValuePair<string, object>("leftEmpty", leftIsEmpty));
        worldData.Add(new KeyValuePair<string, object>("rightEmpty", rightIsEmpty));
        worldData.Add(new KeyValuePair<string, object>("topEmpty", topIsEmpty));
        worldData.Add(new KeyValuePair<string, object>("bottomEmpty", bottomIsEmpty));
        worldData.Add(new KeyValuePair<string, object>("lowStamina", stamina < 3));
        worldData.Add(new KeyValuePair<string, object>("damagePlayer", playerDeath )); //TODO change false to a boolean based on playerHealth

        return worldData;
    }

    public abstract HashSet<KeyValuePair<string, object>> createGoalState();

    public void planFailed(HashSet<KeyValuePair<string, object>> failedGoal)
    {
        // Not handling this here since we are making sure our goals will always succeed.
        // But normally you want to make sure the world state has changed before running
        // the same goal again, or else it will just fail.
    }

    public void planFound(HashSet<KeyValuePair<string, object>> goal, Queue<GOAPAction> action)
    {
        Debug.Log("<color=green>Plan found</color> " + GOAPAgent.prettyPrint(action));

    }


    public abstract void staminaRegen();
    
    public void actionsFinished()
    {
        Debug.Log("<color=blue>Actions completed</color>");
    }

    public void planAborted(GOAPAction aborter)
    {
        Debug.Log("<color=red>Plan Aborted</color> " + GOAPAgent.prettyPrint(aborter));

    }

    //gradually move the enemy towards the target location. (eg. for attack player, target will be player)
    public  bool moveAgent(GOAPAction nextAction)
    {
        
        
        float step = movementSpeed * Time.deltaTime;
        Rigidbody2D enemyBody = gameObject.GetComponent<Rigidbody2D>();
        float distanceToTarget = Vector3.Distance(transform.position, nextAction.target.transform.position);
        //move towards the object till you reach minimumDistance to Interact
        //function returns true when you reach the interactable range
        enemyBody.MovePosition(transform.position + Vector3.Normalize(nextAction.target.transform.position - transform.position) * movementSpeed * Time.deltaTime);

        
        if(distanceToTarget <= minimumDistanceToInteract)
        {
            nextAction.setInRange(true);
            return true;
        } else
        {
            return false;
        }

    }
    //updates variables that are required for AI to take a call on action
    public void updateTheWorldStateForAI()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        getPlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playerTest>();
        
        if (getPlayerHealth.health <= 0)
        {
            playerDeath = true;
            
        } else
        {
            playerDeath = false;
        }

        //set playerInRange 
        if(Vector3.Distance(transform.position,player.transform.position) <= minimumDistanceToInteract*2)
        {
            playerNotInRange = false;
        } else
        {
            playerNotInRange = true;
        }
        //playerSpotted true or false based on collision with trigger
        //playerSpotted can also be triggered when another enemy calls for help


    }

    public void attackPlayer()
    {
        Debug.Log("attackPlayer:");
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
            
        }
            
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        //Check if player ran from field of vision, if player is in field of vision, the enemy will be following them
        if (collision.gameObject.CompareTag("Player"))
        {
            
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

    public void updateStamina()
    {
        if (stamina <= maxStamina)
        {
            Invoke("staminaRegen", 1f);
        }
        else
        {
            stamina = maxStamina;
        }
    }
}
