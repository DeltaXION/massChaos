using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public int openingDirection;
    // 1 --> need bootom door
    // 2 --> need top door
    // 3 --> need left door
    // 4 --> need right door

    public RoomTemplates templates;
    public int rand;
    public bool spawned = false;
    public float waitTime = 4f;


    void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }



    void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                //will spawn a room with Bottom door.
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                //will spawn room with top door.
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                //will spawn room with left door.
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                //will spawn a room with right door.
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
                spawned = true;
        }
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spawnpoint"))
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }

    }
}


    
       
