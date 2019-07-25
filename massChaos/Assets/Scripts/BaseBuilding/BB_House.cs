using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_House : MonoBehaviour
{
    [SerializeField] int HouseID;
    BB_BuildingID bB_BuildingID;
    BB_GlobalStats bB_GlobalStats;

    // Start is called before the first frame update
    void Start()
    {
        bB_BuildingID = FindObjectOfType<BB_BuildingID>();
        HouseID = bB_BuildingID.AddtoID(gameObject.tag);

        FindObjectOfType<BB_GlobalStats>().CurrentNumberOfHouses();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetHouseID()
    {
        return HouseID;
    }
}
