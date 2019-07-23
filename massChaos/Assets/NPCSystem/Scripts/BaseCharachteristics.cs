using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharachteristics
{
   // public List<NomadData> Nomads;
    //public List<FerrariumData> Ferrarium;
    public int id;
    public string name;
    public string type;
<<<<<<< HEAD
    public char classType; //dummy for quest team
    public string secItem; //dummy for quest team


    public BaseCharachteristics(int id, string  name, string type, char classType, string secItem) {
      this.id = id;
      this.name = name;
      this.type = type;
       this.classType = classType;
        this.secItem = secItem;
=======
    public char classType;
    public string secItem;
    public string priItem;
    public string status;
     
    public BaseCharachteristics(int id, string  name, string type, char classType, string secItem, string priItem, string status) {
      this.id = id;
      this.name = name;
      this.type = type;
      this.classType = classType;
      this.secItem = secItem;
      this.priItem = priItem;
      this.status = status;
>>>>>>> 1dc80758be172dd3efeb56761c7acdb97f37a723
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

    public char ClassType
    {
        get { return classType; }
        set { classType = value; }
    }

    public string SecItem
    {
        get { return secItem; }
        set { secItem = value; }
    }

<<<<<<< HEAD
=======
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

>>>>>>> 1dc80758be172dd3efeb56761c7acdb97f37a723

}   






