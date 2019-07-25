using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_GlobalStats : MonoBehaviour
{
    public static int BasePopulation, BaseAssignedNPCs, BaseAffinityAssignedNPCs, BaseTotalBuildings, BaseBuildingDamage;

    [SerializeField] int numberOfHouses = 0;
    BB_BuildingUpgrades bB_BuildingUpgrades;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CurrentNumberOfHouses()
    {
        numberOfHouses++;
    }
}
