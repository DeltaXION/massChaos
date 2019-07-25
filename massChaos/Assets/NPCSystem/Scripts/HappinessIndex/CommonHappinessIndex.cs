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
    public static float DuplexBoost = 0.0125f;
    public static float VillaBoost = 0.025f;

    //Multipliers for damage to base buildings
    public static float DamagedBuildingReduction = 0.15f;
    public static float DamagedAffinityBuildingReduction = 0.25f;

    //Variables to calculate Base shelter dependency
    public static float TotalBuildingsAtBase; //Total Number of buildigns on the base
    public static float SimpleHouseCount = 1f; //Number of Simple houses in the base
    public static float DuplexCount = 1; //Number of Duplexs in the base
    public static float VillaCount = 1; //Number of Villas in the base
    public static float NumberOfDamangedBuildings = 2; //Number of buildings damaged
    //public static float NumberOfAffinityDamagedBuildings = 1; 

    //Variables for Food consumption 
    public static float ConsumptionRate = 10f; //Consumption rate /follower/day 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    static void SetCommonHappiness()
    {
        CommonHappiness = Foodfactor + BaseHealth;
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
        float TotalFollowers = (float)BB_GlobalStats.BasePopulation;

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

    static void SetBaseComfort()
    {
        float TotalBC = 10f;
        float BCCap = 1f * TotalBC;
        //Debug.Log("BCCap " + BCCap);
        float TotalFollowers = NPCSystem.followers.Count;
        //float SimpleHouseCount = 1;

        float FollowersInSimpleHouse = SimpleHouseCount * 1;
        float PercentofFollowersInSH = ((FollowersInSimpleHouse / TotalFollowers));
        //Debug.Log("%inSH " + PercentofFollowersInSH);

        //float DuplexCount = 1;
        float FollowersInDuplex = DuplexCount * 3;
        float PercentofFollowersInDup = ((FollowersInDuplex / TotalFollowers));
        //Debug.Log("%inD " + PercentofFollowersInDup);

        //float VillaCount = 1;
        float FollowersInVillas = VillaCount * 5;
        float PercentofFollowersInVC = ((FollowersInVillas / TotalFollowers));
        //Debug.Log("%inVC " + PercentofFollowersInVC);


        float x = BCCap + ((PercentofFollowersInDup * BCCap) * DuplexBoost) + ((PercentofFollowersInVC * BCCap) * VillaBoost);
        //Debug.Log("X = " + x);

        //TotalBuildingsAtBase = BB_BasicControls.buildBuilt;
        //float NumberOfDamangedBuildings = 2;
        //float NumberOfAffinityDamagedBuildings = 1;
        float PercentOfDamagedBuildings = ((Mathf.Abs(NumberOfDamangedBuildings /*- NumberOfAffinityDamagedBuildings*/) / TotalBuildingsAtBase));
        //float PercentOfDamagedAffinityBuildings = (NumberOfAffinityDamagedBuildings / TotalBuildingsAtBase);


        float y = ((PercentOfDamagedBuildings * BCCap) * DamagedBuildingReduction) /*+ ((PercentOfDamagedAffinityBuildings * BCCap) * DamagedAffinityBuildingReduction)*/;

        BaseComfort = (x - y) / 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
