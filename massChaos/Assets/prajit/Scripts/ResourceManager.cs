using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class ResourceManager : MonoBehaviour
{
    public static int gold = 0;
    public static int food = 0;
    public static int wood = 0;
    public static int iron = 0;
    public static Text goldText;
    public static Text woodText;
    public static Text foodText;
    public static Text ironText;

    // Start is called before the first frame update
    void Start()
    {
        goldText = GameObject.FindGameObjectWithTag("goldText").GetComponent<Text>();
        woodText = GameObject.FindGameObjectWithTag("woodText").GetComponent<Text>();
        foodText = GameObject.FindGameObjectWithTag("foodText").GetComponent<Text>();
        ironText = GameObject.FindGameObjectWithTag("ironText").GetComponent<Text>();
        addGold(4);
        addFood(65);
        addIron(1);
        addWood(25);
        subFood(2);
        subGold(1);
        subIron(1);
        subWood(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void addGold(int n)                      //increment gold
    {
        gold += n;
        setGoldText();
    }

    public static void addWood(int n)                       //increment wood
    {
        wood += n;
        setWoodText();
    }

    public static void addFood(int n)                       //increment food
    {
        food += n;
        setFoodText();
    }

    public static void addIron(int n)                       //increment iron
    {
        iron += n;
        setIronText();
    }

    public static void subGold(int n)                       //decrement gold
    {
        gold -= n;
        if(gold<=0)
        {
            gold = 0;
        }
        setGoldText();
    }

    public static void subFood(int n)                      //decrement food
    {
        food -= n;
        if(food<=0)
        {
            food = 0;
        }
        setFoodText();
    }

    public static void subWood(int n)                      //decrement wood
    {
        wood -= n;
        if(wood<=0)
        {
            wood = 0;
        }
        setWoodText();
    }

    public static void subIron(int n)                      //decrement iron
    {
        iron -= n;
        if(iron<=0)
        {
            iron = 0;
        }
        setIronText();
    }

    public static void setGoldText()                                           //display gold value
    {
        goldText.text = "Gold : " + gold.ToString();
    }

    public static void setWoodText()                                           //display wood value
    {
        woodText.text = "Wood : " + wood.ToString();
    }

    public static void setFoodText()                                           //display food value
    {
        foodText.text = "Food : " + food.ToString();
    }

    public static void setIronText()                                           //display iron value
    {
        ironText.text = "Iron : " + iron.ToString();
    }
}
