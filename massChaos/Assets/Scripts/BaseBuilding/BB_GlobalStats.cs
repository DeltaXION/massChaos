 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
using UnityEngine.UI;

public class BB_GlobalStats : MonoBehaviour
{
    public static int BasePopulation, BaseAssignedNPCs, BaseAffinityAssignedNPCs, BaseTotalBuildings, BaseBuildingDamage;
    public static int UpgradedHouses, UpgradedFarms, UpgradedMarket, UpgradedWorkshop;

    [SerializeField] int numberOfHouses = 0;
    [SerializeField] public int TotalpopulationCapacity = 0;
    int level0, level1, level2;
    BB_BuildingUpgrades bB_BuildingUpgrades;
    Text populationCountText;
    int TotalpopulationCapacityOld;
    int currentPopulation;

    BB_House bBHouse;



    // Start is called before the first frame update
    void Start()
    {
        bB_BuildingUpgrades = FindObjectOfType<BB_BuildingUpgrades>();
        populationCountText = GameObject.FindGameObjectWithTag("populationText").GetComponent<Text>();
        bBHouse = FindObjectOfType<BB_House>();
    }

    // Update is called once per frame
    void Update()
    {
        populationCountText.text = currentPopulation + " / " + TotalpopulationCapacity.ToString();
    }

    public void addToPopulation()
    {
        currentPopulation++;
        BasePopulation = currentPopulation;
    }

    public int GetPopulation()
    {
        return currentPopulation;
    }

    public void addToPopulationCapacity(int upgradeLevel)
    {
        TotalpopulationCapacityOld = TotalpopulationCapacity;
        switch (upgradeLevel)
        {
            case 2:
                TotalpopulationCapacity = 5;
                TotalpopulationCapacity = TotalpopulationCapacityOld + 2;
                //TotalpopulationCapacity = TotalpopulationCapacityOld + (TotalpopulationCapacityOld - 5);
                break;

            case 1:
                TotalpopulationCapacity = 3;
                TotalpopulationCapacity = TotalpopulationCapacityOld + 2;
                break;

            case 0:
                TotalpopulationCapacity = 1;
                TotalpopulationCapacity = TotalpopulationCapacityOld + 1;

                //TotalpopulationCapacity = TotalpopulationCapacityOld + (TotalpopulationCapacityOld - 1);
                break;

            default:
                TotalpopulationCapacity = 999;
                //TotalpopulationCapacity = TotalpopulationCapacity + TotalpopulationCapacityOld;
                break;
        }


       
    }



    public void CurrentNumberOfHouses()
    {
        numberOfHouses++;
    }
}
