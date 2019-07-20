using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonResourceController : MonoBehaviour
{
    public static int dungeonGoldValue=0;                                                   //gold the player carries in the dungeon
    public static int dungeonFoodValue = 0;
    public static int dungeonWoodValue = 0;
    public static int dungeonIronValue = 0;
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

    public static void addDungeonGoldValue(int n)
    {
        dungeonGoldValue += n;
    }

    public static void addDungeonFoodValue(int n)
    {
        dungeonFoodValue += n;
    }

    public static void addDungeonWoodValue(int n)
    {
        dungeonWoodValue += n;
    }

    public static void addDungeonIronValue(int n)
    {
        dungeonIronValue += n;
    }
}
