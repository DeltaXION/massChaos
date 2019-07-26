using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharachteristics
{
   // public List<NomadData> Nomads;
    //public List<FerrariumData> Ferrarium;
    public int id;
    public string name;


    public string type; //faction
    public string classType; //class

    public string secItem;
    public string priItem;
    public string status;
    public int houseId;
     
    public BaseCharachteristics(int id, string  name, string type, string classType, string secItem, string priItem, string status, int houseId) {
      this.id = id;
      this.name = name;
      this.type = type;
      this.classType = classType;
      this.secItem = secItem;
      this.priItem = priItem;
      this.status = status;
        this.houseId = houseId;

    }

    public string Name
    {
        get { return name; }
        set { name = value; }
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

    public string ClassType
    {
        get { return classType; }
        set { classType = value; }
    }

    public string SecItem
    {
        get { return secItem; }
        set { secItem = value; }
    }


    public string PriItem
    {
        get { return priItem; }
        set { priItem = value; }
    }

    public string Status
    {
        get { return status; }
        set { status = value; }
    }

    public int HouseId
    {
        get { return houseId; }
        set { houseId = value; }
    }



}   






