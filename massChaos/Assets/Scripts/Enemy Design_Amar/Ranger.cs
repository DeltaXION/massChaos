using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ranger : EnemyBaseClass
{
    public GameObject rangeWeapon;
    public int arrowForce = 20;
    public float arrowRange = 5;
    // Start is called before the first frame update
    void Start()
    {
        base.createCollisionTriggers();
        
    }

    // Update is called once per frame
    void Update()
    {
        base.readSensorStatusAndUpdateFlags();
        base.updateTheWorldStateForAI();
        
       
       
    }

    
    public override void attackPlayer()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        
        GameObject arrow = Instantiate(rangeWeapon, transform.position, Quaternion.identity);
        rangedWeaponBehavior currentArrow = arrow.GetComponent<rangedWeaponBehavior>();
        currentArrow.setTarget(arrowForce, player.transform.position, arrowRange);
    }
    public override void staminaRegen()
    {
        Debug.Log("Stamina update" + stamina);
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
