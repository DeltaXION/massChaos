using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonHappinessIndex : MonoBehaviour
{
    private static float Foodfactor; //Food Dependency of HI (Common)
    private static float BaseHealth; //Base Health Dependency HI (Common)
    private static float BaseComfort; //Base Shelter Dependency of HI
    public static float CommonHappiness;

    //Multipliers for Base shelter and upgrades
    //public static float DuplexBoost = 0.0125f;
    //public static float VillaBoost = 0.025f;

    //Multipliers for damage to base buildings
    public static float DamagedBuildingReduction = 0.3f;
    //public static float DamagedAffinityBuildingReduction = 0.25f;

    //Variables to calculate Base shelter dependency
    public static float TotalBuildingsAtBase; //Total Number of buildigns on the base
    public static float HouseUpgradeBoost = 0.3f; //Multiplier for house upgrades
    //public static float NumberOfAffinityDamagedBuildings = 1; 

    //Variables for Food consumption 
    public static float ConsumptionRate = 10f; //Consumption rate /follower/day 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    static void SetCommonHappiness()
    {
        CommonHappiness = Foodfactor /*+ BaseHealth + BaseComfort*/;
    }

    public static void RecaclculateHappinessIndex()
    {
        FrootHappinessIndex.RecalculateFrootHappinessIndex();
        FerroHappinessIndex.RecalculateFerroHappinessIndex();
        NomadHappinessIndex.RecalculateNomadHappinessIndex();
        MimaxHappniessIndex.RecalculateMimaxHappinessIndex();
    }

    static void SetFoodFactor()
    {
        //Total Amount of food stock
        float TotalFoodStock = (float)ResourceManager.food;
        float TotalFollowers = (float)NPCSystem.followers.Count;

        int n = (int)TotalFollowers * (int)ConsumptionRate;

        float StarvingFollowers = (TotalFollowers - (TotalFoodStock / ConsumptionRate));//Number of followers not getting food in a day
        float StarvingPercentage = (StarvingFollowers / TotalFollowers); //percentage of followers not getting food today
        float F = 40; //This is the Total possible happiness that can be achieved via Food

        if (TotalFoodStock >= (ConsumptionRate * (float)n)) //If food is sufficient
        {
            Foodfactor = F / 10;
        }
        else //if food is insufficient
        {
            Foodfactor = (F - ((StarvingPercentage) * F)) / 10;
        }

        ResourceManager.subFood(n);

    }

    /*static void SetBaseHealth()
	{
		float TotalBH = 10;
		float MaxBaseHealth = 100;
		//float CurrentBaseHealth = 80;
		float PercentReductionInBaseHealth = (CurrentBaseHealth / MaxBaseHealth);
		if(CurrentBaseHealth == MaxBaseHealth)
		{
			BaseHealth = 1;
		}
		else
		{
			BaseHealth = (TotalBH - ((PercentReductionInBaseHealth) * TotalBH)) / 10;
		}
	}*/

    /*static void SetBaseComfort()
    {
        float TotalBC = 10f;
        float BCCap = 1f * TotalBC;
        float TotalFollowers = NPCSystem.followers.Count;

        float TotalNumberOfHouses = BB_BasicControls.houseBuilt;
        float TotalNumberOfUpgradedHouses = BB_GlobalStats.UpgradedHouses;
        float PercentOfUpgradedHouses = TotalNumberOfUpgradedHouses / TotalNumberOfHouses;

        float x = BCCap + ((PercentOfUpgradedHouses * BCCap) * HouseUpgradeBoost);

        float TotalBuildingsAtBase = BB_BasicControls.buildBuilt;
        float NumberOfDamangedBuildings = BaseDamage.destroyedbuilds;
        
        float PercentOfDamagedBuildings = ((Mathf.Abs(NumberOfDamangedBuildings  / TotalBuildingsAtBase)));


        float y = ((PercentOfDamagedBuildings * BCCap) * DamagedBuildingReduction); 

        BaseComfort = (x - y) / 10;
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
