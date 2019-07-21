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
    public float waiTime = 4f;


    void Start()
    {
        Destroy(gameObject, waiTime);
       // templates = GameObject.FindGameObjectsWithTag("Rooms").GetComponent<RoomTemplates>();

        Invoke("Spawn", 0.1f);
    }



     void Spawn()
    {
        if (spawned == false);
        {
            if (openingDirection == 1)
            {
                //will spawn a room with Bottom door.
                rand = Random.Range(0, templates.bottomrooms.Length);
                Instantiate(templates.bottomrooms[rand], transform.position, templates.bottomrooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                //will spawn room with top door.
                rand = Random.Range(0, templates.toprooms.Length);
                Instantiate(templates.toprooms[rand], transform.position, templates.toprooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                //will spawn room with left door.
                rand = Random.Range(0, templates.leftrooms.Length);
                Instantiate(templates.leftrooms[rand], transform.position, templates.leftrooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                //will spawn a room with right door.
                rand = Random.Range(0, templates.rightrooms.Length);
                Instantiate(templates.rightrooms[rand], transform.position, templates.rightrooms[rand].transform.rotation);
            }
                spawned = true;
            }
       
        }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
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


    
       
