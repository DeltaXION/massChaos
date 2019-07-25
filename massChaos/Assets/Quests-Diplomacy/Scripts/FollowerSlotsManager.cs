using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerSlotsManager : MonoBehaviour
{
    public GameObject[] Slots;
    public GameObject ActiveFollower;
    public int ActiveFollowerSlotID = 0;

    public GameObject ActiveNode;
    List<BaseCharachteristics> FollowerList = NPCSystem.followers;

    void Start()
    {
        DecideonNumberofSlotsperFollower();
        FillSlots();
    }

    public void ChangeFollowerStatebetweenBusyandIdle(int QuestingFollowerID)
    {
        int count = 1;
        foreach(var person in FollowerList)
        {
            if (count == QuestingFollowerID)
            {
                if (person.status == "Questing")
                    person.status = "idle";
                else if (person.status != "Questing")
                    person.status = "Questing";
            }
            count++;
        }
        FillSlots();
    }

    public void SendActiveNode(GameObject ActivatedNode)
    {
        ActiveNode = ActivatedNode;        
    }

    public GameObject GetActiveFollower()
    {
        ActiveFollower = Slots[ActiveFollowerSlotID];
        return ActiveFollower;
    }

    //TO FETCH GAMEOBJECT WITH RELEVANT FOLLOWERSLOT ID
    public GameObject FetchFollowerSlotDetails(int FollowerID)
    {
        int ID = FollowerID;
        if (ID > 0)                                 //BECAUSE ALL ARRAYS START WITH 0
            ID -= 1;
        GameObject ReturnThis = Slots[ID];
        
        return ReturnThis;
    }

    //TO TURN OFF ALL FOLLOWER SLOTS THAT DON'T HOLD ANY VALUE BY TURNING OFF ALL PAST THE SIZE OF THE FOLLOWERLIST
    public void DecideonNumberofSlotsperFollower()
    {
        int NumberofSlots = FollowerList.Count;

        foreach(GameObject Slot in Slots)
        {
            if (NumberofSlots > 0)
                Slot.SetActive(true);
            else
                Slot.SetActive(false);

            NumberofSlots--;
        }

    }

    //FILLS FOLLOWER SLOTS WITH VALUES
    //id, name, type, classType, secItem, priItem, status
    public void FillSlots()
    {
        int count = 0;
        Debug.Log("Follower List " + FollowerList[1]);
        foreach (var item in FollowerList)
        {
            

            //Change the variables of each Slot in the array.
            Slots[count].GetComponent<FollowerSlot>().FollowerName = item.name;
            Slots[count].GetComponent<FollowerSlot>().FollowerRace = RaceTypeDeCompiler(item.type);
            Slots[count].GetComponent<FollowerSlot>().FollowerClass = item.classType;
            Slots[count].GetComponent<FollowerSlot>().FollowerPrimaryWeapon = item.priItem;
            Slots[count].GetComponent<FollowerSlot>().FollowerSecondaryWeapon = item.secItem;
            Slots[count].GetComponent<FollowerSlot>().FollowerStatus = item.status;

            Slots[count].GetComponent<FollowerSlot>().InfoSlotsFill();
            count++;
        }
    }
    string RaceTypeDeCompiler(string ClassCode)
    {
        string ReturnString = ClassCode;

        if(ClassCode == "N")
        {
            ReturnString = "Nomad";
            Debug.Log("N is for Nomad");
        }
        if (ClassCode == "Fr")
        {
            ReturnString = "Ferrarium";
        }
        if (ClassCode == "Fo")
        {
            ReturnString = "Froots";
        }
        if (ClassCode == "M")
        {
            ReturnString = "Mimax";
        }
        
        return ReturnString;

    }
}
