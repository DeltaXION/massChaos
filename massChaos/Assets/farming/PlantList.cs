using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlantList 
{
   public GameObject ShowButton;

    public int plantId;
    public string plantName;
    public bool winter;
    public int growDuration;
    public int foodReward;

    public PlantList(int id, string name, bool winterCondition, int duration, int reward)
    {
        this.plantId = id;
        this.plantName = name;
        this.winter = winterCondition;
        this.growDuration = duration;
        this.foodReward = reward;
    }

    public int plantID
    {
        get { return plantID; }
        set { plantID = value; }
    }

    public string PlantName
    {
        get { return plantName; }
        set { plantName = value; }
    }

    public bool Winter
    {
        get { return winter; }
        set { winter = value; }
    }

    public int GrowDuration
    {
        get { return growDuration; }
        set { growDuration = value; }
    }

    public int FoodReward
    {
        get { return foodReward; }
        set { foodReward = value; }
    }
    
}
