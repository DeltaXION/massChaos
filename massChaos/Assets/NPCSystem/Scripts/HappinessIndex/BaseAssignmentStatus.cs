/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAssignmentStatus : MonoBehaviour
{
    public static List<BaseCharachteristics> FollowersAssignedAtFarm = new List<BaseCharachteristics>();
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //if placed farm is clicked
    void GetIdleFollowers()
    {


        foreach(var o in NPCSystem.followers)
        {
            if (o.Status == "idle")
            {
                int ID = o.Id;

                BaseCharachteristics c = GetFollowerByID(ID);
                FollowersAssignedAtFarm.Add(new BaseCharachteristics (c.id, c.name, c.type, c.classType, c.secItem, c.priItem, c.status));
            }
        }



    }

    public BaseCharachteristics GetFollowerByID(int id)
    {

        BaseCharachteristics b = null;
        foreach (var o in NPCSystem.followers)
        {
            if (o.id == id)
            {
                b = o;
            }
        }
        return b;
    }
    // Update is called once per frame

    //when follower is assigned
    /*void FollowerAssignedToFarm()
    {
        //if Assign Button is clicked
        int AssignedID; //(ID of the element whos button was clicked)

        foreach(var o in NPCSystem.followers)
        {
            if(o.id == AssignedID)
            {
                //string farm = o.Status;
               o.Status.Replace("idle", "Farm");
               
            }
        }
    }


    void Update()
    {
        
    }
}
*/