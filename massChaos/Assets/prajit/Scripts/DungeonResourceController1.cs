using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonResourceController1 : MonoBehaviour
{

    public static int dungeonGold = 0;
    public static int dungeonFood = 0;
    public static int dungeonWood = 0;
    public static int dungeonIron = 0;
    public static Text dungeonGoldText;
    public static Text dungeonWoodText;
    public static Text dungeonFoodText;
    public static Text dungeonIronText;

    // Start is called before the first frame update
    void Start()
    {
        dungeonGoldText = GameObject.FindGameObjectWithTag("dungeonGoldText").GetComponent<Text>();
        dungeonWoodText = GameObject.FindGameObjectWithTag("dungeonWoodText").GetComponent<Text>();
        dungeonFoodText = GameObject.FindGameObjectWithTag("dungeonFoodText").GetComponent<Text>();
        dungeonIronText = GameObject.FindGameObjectWithTag("dungeonIronText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void addDungeonGold(int n)                      //increment gold
    {
        dungeonGold += n;
        setDungeonGoldText();
    }

    public static void addDungeonWood(int n)                       //increment wood
    {
        dungeonWood += n;
        setDungeonWoodText();
    }

    public static void addDungeonFood(int n)                       //increment food
    {
        dungeonFood += n;
        setDungeonFoodText();
    }

    public static void addDungeonIron(int n)                       //increment iron
    {
        dungeonIron += n;
        setDungeonIronText();
    }

    public static void subDungeonGold(int n)                       //decrement gold
    {
        dungeonGold -= n;
        if (dungeonGold <= 0)
        {
            dungeonGold = 0;
        }
        setDungeonGoldText();
    }

    public static void subDungeonFood(int n)                      //decrement food
    {
        dungeonFood -= n;
        if (dungeonFood <= 0)
        {
            dungeonFood = 0;
        }
        setDungeonFoodText();
    }

    public static void subDungeonWood(int n)                      //decrement wood
    {
        dungeonWood -= n;
        if (dungeonWood <= 0)
        {
            dungeonWood= 0;
        }
        setDungeonWoodText();
    }

    public static void subDungeonIron(int n)                      //decrement iron
    {
        dungeonIron -= n;
        if (dungeonIron <= 0)
        {
            dungeonIron = 0;
        }
        setDungeonIronText();
    }

    public static void setDungeonGoldText()                                           //display gold value
    {
        dungeonGoldText.text = dungeonGold.ToString();

    }

    public static void setDungeonWoodText()                                           //display wood value
    {
        dungeonWoodText.text = dungeonWood.ToString();
    }

    public static void setDungeonFoodText()                                           //display food value
    {
        dungeonFoodText.text = dungeonFood.ToString();
    }

    public static void setDungeonIronText()                                           //display iron value
    {
        dungeonIronText.text = dungeonIron.ToString();
    }
}
