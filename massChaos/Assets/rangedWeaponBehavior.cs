using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rangedWeaponBehavior : MonoBehaviour
{
    Vector3 target;
    int bulletForce;
    Rigidbody2D myBody;
    float maxLifeDistance;
    Vector3 initialPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("bullet initiated");
        initialPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        checkDistanceAndDestroy();
    }

    public void setTarget(int bulletForce, Vector3 cordinates, float maxLife)
    {
        target = cordinates;
        maxLifeDistance = maxLife;
        fireAtTarget(bulletForce, target);
    }

    void fireAtTarget(int bulletForce, Vector3 target)
    {
        Vector3 shotDirection = (target - transform.position).normalized;
        myBody = gameObject.GetComponent<Rigidbody2D>();
        myBody.AddForce(shotDirection* bulletForce);
    }

    void checkDistanceAndDestroy()
    {
        Vector3 currentPosition = transform.position;
        if(Vector3.Distance(initialPosition,currentPosition) > maxLifeDistance)
        {
            Destroy(gameObject);
        }
    }
}
