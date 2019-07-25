using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_GlobalStats : MonoBehaviour
{
    public static int BasePopulation, BaseAssignedNPCs, BaseAffinityAssignedNPCs, BaseTotalBuildings, BaseBuildingDamage;

    [SerializeField] int numberOfHouses = 0;
    [SerializeField] public int populationCapacity = 0;
    BB_BuildingUpgrades bB_BuildingUpgrades;


    // Start is called before the first frame update
    void Start()
    {
        bB_BuildingUpgrades = FindObjectOfType<BB_BuildingUpgrades>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addToPopulationCapacity(int count)
    {
        populationCapacity += count;
    }

    public void CurrentNumberOfHouses()
    {
        numberOfHouses++;
    }
}
