using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonResourceController : MonoBehaviour
{
    public Item item;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)                         //once the player touches the gold drop, it gets added to the dungeon inventory of gold
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.SetActive(false);
            Destroy(gameObject);
           
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            bool wasPickedUp = Inventory.instance.Add(item);
            Debug.Log("Picking up item");

            if(wasPickedUp)
            Destroy(gameObject);

        }
    }


}
