using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour
{
    public int dungeonGoldValue=0;                                                   //gold the player carries in the dungeon
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)                         //once the player touches the gold drop, it gets added to the dungeon inventory of gold
    {
        if(collision.gameObject.CompareTag("DungeonGold"))
        {
            collision.gameObject.SetActive(false);
            addDungeonGoldValue(4);
            Destroy(collision.gameObject);
           
        }
    }

    public void addDungeonGoldValue(int n)
    {
        dungeonGoldValue += n;
    }
}
