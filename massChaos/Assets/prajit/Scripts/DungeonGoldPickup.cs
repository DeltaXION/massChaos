using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGoldPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)                         //once the player touches the gold drop, it gets added to the dungeon inventory of gold
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.SetActive(false);
            Destroy(gameObject);

        }
    }
}
