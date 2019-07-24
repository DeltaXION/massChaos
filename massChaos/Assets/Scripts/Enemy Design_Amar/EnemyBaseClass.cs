using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enemy base class, all enemy subtypes will inherit from this base class
//Abstract because we do not use this class on an object directly, we first need to create a derived class from it
public abstract class EnemyBaseClass : MonoBehaviour, IGOAP
{

    //declaring variables common to all enemies;
    //minimum distance between enemy and other things
    public GameObject player;
    public float minimumDistanceToInteract;
    public float combatRadius;
    //defining an combat radius
    CircleCollider2D combatRadiusCollider;
    public float health;
    public float maxStamina = 5;
    float attackSpeed;
    float attackDamage;
    public float dashDistance = 2;
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
    bool playerInVision = true;
    bool playerInCombatZone = false;
    bool lowStamina = false;
    //Colliders and booleans for feeling walls
    public enemySurroundingSensor topSensor;
    public bool topIsEmpty;
    public enemySurroundingSensor rightSensor;
    public bool rightIsEmpty;
    public enemySurroundingSensor bottomSensor;
    public bool bottomIsEmpty;
    public enemySurroundingSensor leftSensor;
    public bool leftIsEmpty;
    bool inCombat = false;
    bool playerDeath = false;
    bool patrol;
    bool regeneratingStamina = false;
    public coneOfVision enemySight;
    public combatZone combatZone;

    void Start()
    {
       
        
    }

   
    //function will be replaced in enemysubclasses
    // Dungeon level will be passed to enemy to set difficulty
    public virtual void InitializeEnemy(int dungeonLevel)
    {

    }


    public void damageEnemy(float damage)
    {
        health -= damage;   
        Debug.Log("enemy hurt by " + damage + " points");
    }

    public void enemyDeath()
    {
        if(health <=0)
        {
            //call drop loot function
            Destroy(gameObject);
        }
    }

    public void createCollisionTriggers()
    {
        //Create collision boxes proportional to enemy size
        
        Vector3 enemySize = GetComponent<Renderer>().bounds.size ;
        //Create an attack radius around enemy, value being hardcoded for the timebeing.
        combatRadiusCollider =  combatZone.gameObject.AddComponent<CircleCollider2D>();
        combatRadiusCollider.radius = combatRadius;
        combatRadiusCollider.isTrigger = true;
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
        //sensing Combat
        worldData.Add(new KeyValuePair<string, object>("playerInVision", playerInVision));
        worldData.Add(new KeyValuePair<string, object>("playerInCombatZone", playerInCombatZone));
        worldData.Add(new KeyValuePair<string, object>("lowStamina", lowStamina));
        //sensing world
        worldData.Add(new KeyValuePair<string, object>("leftEmpty", leftIsEmpty));
        worldData.Add(new KeyValuePair<string, object>("rightEmpty", rightIsEmpty));
        worldData.Add(new KeyValuePair<string, object>("topEmpty", topIsEmpty));
        worldData.Add(new KeyValuePair<string, object>("bottomEmpty", bottomIsEmpty));
        //sensing goals
        worldData.Add(new KeyValuePair<string, object>("damagePlayer", playerDeath));
        worldData.Add(new KeyValuePair<string, object>("patrol", patrol));
        //Goal switch variables, turning this to false makes that goal impossible
        worldData.Add(new KeyValuePair<string, object>("inCombat", inCombat));


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

    void rotateVision(GameObject player)
    {
        /*
        Vector2 startingNormal = new Vector2(0, -1);
        Vector2 currentDirection = GetComponent<Rigidbody2D>().velocity.normalized;
        Debug.Log(GetComponent<Rigidbody2D>().velocity);
        float angle = Vector2.SignedAngle(startingNormal, currentDirection);
        enemySight.transform.Rotate(Vector3.up, angle);
        */
        Quaternion sightRotation = Quaternion.LookRotation(player.transform.position - transform.position, Vector3.up);
        sightRotation.x = 0;
        sightRotation.y = 0;
        //sightRotation.z = -sightRotation.z;
        
        //enemySight.transform.rotation = sightRotation;
        enemySight.transform.up = transform.position - player.transform.position ;
        
    }



    public void animateAccordingToAngle()
    {

        float lookingAngle = enemySight.transform.eulerAngles.z;
       
       
        if(lookingAngle >45 && lookingAngle <135 )
        {
           // Debug.Log("Facing Right");
        }
        else if(lookingAngle >135 && lookingAngle <225 )
        {
            // Debug.Log("Facing Up");
            
        }
        else if(lookingAngle >225 && lookingAngle <315)
        {
           // Debug.Log("Facing Left");
        } else
        {
            //Debug.Log("Facing down");
        }
        
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

        //set player in vision and playerin combatzone
        playerInVision = enemySight.returnPlayerSpotted();
        playerInCombatZone = combatZone.returnCombatZone();
        
        if(playerInVision)
        {
            rotateVision(player);
        }
        //playerSpotted true or false based on collision with trigger
        //playerSpotted can also be triggered when another enemy calls for help

        //adding stamina Regen Code
        float staminaRegenTime = 1f;
        if(stamina < maxStamina)
        {
            if(!regeneratingStamina)
            {
                StartCoroutine(StaminaCountDown(0.1f));
                regeneratingStamina = true;
            }
        }

        //low stamina is set to true when it falls below attack staminas
        if(stamina < 3)
        {
            lowStamina = true;
        } else
        {
            lowStamina = false;
        }


    }

   
    public virtual void attackPlayer()
    {
        Debug.Log("attackPlayer:");
    }

    //Sets playerSpotted to true if this enemy is in range of another enemy's cry for help
    public void enemyCallForHelp()
    {
        
    }

    //Adding a patrolling code separately, not as a goal.
    public void patrolArea()
    {
        Vector2 leftInput = new Vector2 (-1, 0);
        Vector2 rightInput = new Vector2(1, 0);
        Vector3 topInput = new Vector2(0, 1);
        Vector4 downInput = new Vector2(0, -1);
        string[] patrolInstructions = { "left", "right" };


    }

    //player COllisions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if(collision.gameObject.CompareTag("hitbox_player_ss"))
        {
            takeDamage();
        }
        */
    }

    //read values from sensors and update flags
    public void readSensorStatusAndUpdateFlags()
    {
        //Updated animator
        animateAccordingToAngle();

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
    public virtual void Update()
    {
        
    }

    public void updateStamina()
    {
        
        if (stamina <= maxStamina)
        {
            Invoke("staminaRegen",1f);
        }
        else
        {
            stamina = maxStamina;
        }
    }
    //A timer to trigger stamina Regen
    private IEnumerator StaminaCountDown(float duration)
    {   
        yield return new WaitForSeconds(duration);
        regeneratingStamina = false;
        updateStamina();
    }
}
