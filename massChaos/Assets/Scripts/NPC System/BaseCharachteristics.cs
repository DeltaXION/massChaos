using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharachteristics
{
   // public List<NomadData> Nomads;
    //public List<FerrariumData> Ferrarium;
    public int id;
    public string name;
    public float affinity;
    public float foodIntake;
    public string type;

   
    public BaseCharachteristics(int id,
      string  name,
     float affinity,
     float foodIntake,
     string type) {
        this.id = id;
        this.name = name;
      this.affinity = affinity;
      this.foodIntake = foodIntake;
      this.type = type;
    }


    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public float Affinity
    {
        get { return affinity; }
        set { affinity = value; }
    }

    public float FoodIntake
    {
        get { return foodIntake; }
        set { foodIntake = value; }
    }

    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }


}   






