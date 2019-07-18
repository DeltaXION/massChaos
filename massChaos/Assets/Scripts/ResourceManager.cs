using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public static int gold = 0;
    public static int food = 0;
    public static int wood = 0;
    public static int iron = 0;
    public Text goldText;
    public Text woodText;
    public Text foodText;
    public Text ironText;

    // Start is called before the first frame update
    void Start()
    {
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

    public void addGold(int n)                      //increment gold
    {
        gold += n;
        setGoldText();
    }

    public void addWood(int n)                       //increment wood
    {
        wood += n;
        setWoodText();
    }

    public void addFood(int n)                       //increment food
    {
        food += n;
        setFoodText();
    }

    public void addIron(int n)                       //increment iron
    {
        iron += n;
        setIronText();
    }

    public void subGold(int n)                       //decrement gold
    {
        gold -= n;
        if(gold<=0)
        {
            gold = 0;
        }
        setGoldText();
    }

    public void subFood(int n)                      //decrement food
    {
        food -= n;
        if(food<=0)
        {
            food = 0;
        }
        setFoodText();
    }

    public void subWood(int n)                      //decrement wood
    {
        wood -= n;
        if(wood<=0)
        {
            wood = 0;
        }
        setWoodText();
    }

    public void subIron(int n)                      //decrement iron
    {
        iron -= n;
        if(iron<=0)
        {
            iron = 0;
        }
        setIronText();
    }

    public void setGoldText()                                           //display gold value
    {
        goldText.text = "Gold : " + gold.ToString();
    }

    public void setWoodText()                                           //display wood value
    {
        woodText.text = "Wood : " + wood.ToString();
    }

    public void setFoodText()                                           //display food value
    {
        foodText.text = "Food : " + food.ToString();
    }

    public void setIronText()                                           //display iron value
    {
        ironText.text = "Iron : " + iron.ToString();
    }
}
