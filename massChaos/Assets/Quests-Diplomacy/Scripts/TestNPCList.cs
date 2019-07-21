using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNPCList : MonoBehaviour
{
    public int FollowerSlotNo;
    public string FollowerName, Race, Class, SecondaryItem;
    //public string[] FollowerData;
    // Start is called before the first frame update


    public void FollowerSlotisSelected(int SlotNumber)
    {
        FollowerSlotNo = SlotNumber;
        FetchFollower(FollowerSlotNo);
        Debug.Log("Slot number " + FollowerSlotNo + " is selected." + "Data is " + FollowerName + Race + Class + SecondaryItem);
    }
    
    public void FetchFollower(int FollowerID)
    {
        if (FollowerID == 0)
        {
            FollowerName = " ";
            Race = " ";
            Class = " ";
            SecondaryItem = " ";
        }

        if (FollowerID == 1)
        {
            FollowerName = "Jerras";
            Race = "Nomads";
            Class = "Warrior";
            SecondaryItem = "None";
        }

        if (FollowerID == 2)
        {
            FollowerName = "Hod";
            Race = "Ferrarium";
            Class = "Mage";
            SecondaryItem = "None";
        }

        if (FollowerID == 3)
        {
            FollowerName = "Odds";
            Race = "Ferrarium";
            Class = "Ranger";
            SecondaryItem = "None";
        }

        if (FollowerID == 4)
        {
            FollowerName = "Arda";
            Race = "Ferrarium";
            Class = "Ranger";
            SecondaryItem = "None";
        }

        if (FollowerID == 5)
        {
            FollowerName = "Vhayt";
            Race = "Froots";
            Class = "Ranger";
            SecondaryItem = "Urfha's Fruit";
        }

        if (FollowerID == 6)
        {
            FollowerName = "Busayt";
            Race = "Froots";
            Class = "Warrior";
            SecondaryItem = "None";
        }

        if (FollowerID == 7)
        {
            FollowerName = "Janatp";
            Race = "Mimax";
            Class = "Ranger";
            SecondaryItem = "None";
        }
    }
}
