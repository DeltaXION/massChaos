using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySurroundingSensor : MonoBehaviour
{
    GameObject collidedObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject returnCollidedObject()
    {
        return collidedObject;
    }
     

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {
            collidedObject = collision.gameObject;
        }
        

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject == collidedObject)
        {
            collidedObject = null;
        }


    }
}
