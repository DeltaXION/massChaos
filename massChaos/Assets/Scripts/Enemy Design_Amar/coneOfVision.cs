using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coneOfVision : MonoBehaviour
{
    bool playerSpotted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool returnPlayerSpotted()
    {
        return playerSpotted;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
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
}
