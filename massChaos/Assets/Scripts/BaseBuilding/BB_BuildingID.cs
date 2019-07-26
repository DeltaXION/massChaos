using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_BuildingID : MonoBehaviour
{
    int buildingID;

    public int AddtoID(string tag)
    {
        int buildingID = GameObject.FindGameObjectsWithTag(tag).Length;
        return buildingID;
    }
 
}
