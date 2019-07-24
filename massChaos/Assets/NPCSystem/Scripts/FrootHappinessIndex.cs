using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FrootHappinessIndex : MonoBehaviour
{
    //These variables are for calculating the HAppiness index
    public static float FrootHappiness; //Calculated Happiness Index (HI)
    private static float Foodfactor; //Food Dependency of HI (Common)
    private static float FrootBaseComfort; //Base Shelter Dependency of HI (Froot)
    private static float FrootAssignments; //Assignment Dependency of HI (Froot)
    private static float BaseHealth; //Base Health Dependency HI (Common)
    private static float FrootPrestige; //Prestige Dependency of HI (Froot)

    //public static float TotalFollowers = 20f; //Base Population (BB_Stats script) 

    //Variables for deducting for idleness
    private static float IdleIsWrong; //Deduction for Idle Followers (an idle mind is the devil's workshop remember?)
    private static float IdleIsBad;
    public static float IdlePenalty;

    //Multipliers for affiity
    public static float BaseAssignmentAffinityBoost = 0.025f; //Froots Assigned to affinity tasks at base
	public static float QuestAffinityBoost = 0.025f; //Froots Assigned to affinity tasks on quests

    //Multipliers for Base shelter and upgrades
    public static float DuplexBoost = 0.0125f;
	public static float VillaBoost = 0.025f;

    //Multipliers for damage to base buildings
    public static float DamagedBuildingReduction = 0.15f;
	public static float DamagedAffinityBuildingReduction = 0.25f;

    //Variables for Food consumption 
	public static float ConsumptionRate = 10f; //Consumption rate /follower/day 
    
    //Variables for calculating Base Health Dependency
    //public static float CurrentBaseHealth = 80f; 

    //Variables to calculate Base shelter dependency
    public static float TotalBuildingsAtBase = 10; //Total Number of buildigns on the base
    public static float SimpleHouseCount = 1f; //Number of Simple houses in the base
	public static float DuplexCount = 1; //Number of Duplexs in the base
	public static float VillaCount = 1; //Number of Villas in the base
	public static float NumberOfDamangedBuildings = 2; //Number of buildings damaged
    //public static float NumberOfAffinityDamagedBuildings = 1; 

    //Variables to calculate prestige dependency
    public static float CurrentPrestige;

    
	public static bool PlayerHasAFollowing; //Bool to active HI only when there are followers at the base.

    //Game Object references 
	private static  GameObject FrootPrestigeUpdated; //Reference to get prestige variable
	//private GameObject Froot_HappinessUI; 
	public GameObject ActiveHIUI; //UI Active state
	public GameObject InactiveHIUI; //UI Inactive State

    // Start is called before the first frame update
    void Start()
    {
        
		FrootPrestigeUpdated = GameObject.Find("QuestsDiplomacyManager");
		FrootHappiness = 0f;

		StartCoroutine (IdleFollower());
    }

    private static void SetFrootHappiness()
    {
        
		FrootHappiness = (Foodfactor + FrootAssignments /*+ BaseHealth*/ + FrootBaseComfort + FrootPrestige);
        
		//FrootHappinessUI.text = "Froot Happiness:" + FrootHappiness;
		
    }
    
	
    static void SetFoodFactor()
    {
        //Total Amount of food stock
        float TotalFoodStock = (float) ResourceManager.food;
        float TotalFollowers = (float)BB_GlobalStats.BasePopulation;

        int n = (int)TotalFollowers * (int)ConsumptionRate;


        float StarvingFollowers = (TotalFollowers - (TotalFoodStock / ConsumptionRate));//Number of followers not getting food in a day
        float StarvingPercentage = (StarvingFollowers / TotalFollowers); //percentage of followers not getting food today
        float F = 40; //This is the Total possible happiness that can be achieved via Food
        
        if (TotalFoodStock >= (ConsumptionRate * (float) n)) //If food is sufficient
        {
            Foodfactor = F/10;
        }
        else //if food is insufficient
        {
            Foodfactor = (F - ((StarvingPercentage) * F))/10;
        }

        ResourceManager.subFood(n);

    }

    static void SetAssignmentFactor()
    {
        float A = 20; //This is the total BASE happiness that can be achieved via basic Follower assignments.
        float MaxBaseAb = A / 2; //Total base happiness that can be achieved via basic base assignments
        float MaxQuestAq = A / 2; //Total base happiness that can be achieved via basic quest assignments
        float TotalFrootFollowers = 0f; //Total base population
        
        //using the NPCList to count froot followers
        foreach(var o in NPCSystem.followers)
        {
            if(o.type == "Fr")
            {
                TotalFrootFollowers++;
            }
        }

        float TotalIdleFrootFollowers = 0f; //Self explanatory

        //using the NPC List to count idle fruit followers
        foreach(var o in NPCSystem.followers)
        {
            if(o.type == "Fr" || o.status == "idle")
            {
                TotalIdleFrootFollowers++;
            }
        }

        //Total Froot followers given quest assignments
        float TotalFrootsAssignedToQuests = FrootPrestigeUpdated.GetComponent<QuestsDiplomacyManager>().FrootsCurrentlyQuesting;
        float FrootFollowersAssignedAtBase = TotalFrootFollowers - TotalIdleFrootFollowers; //total froot followers assigned at base     
        float FrootFollowersAssignedToAffinityBaseAssignments = 0f;//Total froot followers assigned to farming
        
        //using NPC List to count the number of NPCs engaged in farming at base
        foreach(var o in NPCSystem.followers)
        {
            if(o.type == "Fr" || o.status == "farming")
            {
                FrootFollowersAssignedToAffinityBaseAssignments++;
            }
        }

        //PErcentage of froots given affinity assignments at base
        float PercentOfFrootAffinityAssignments = (FrootFollowersAssignedToAffinityBaseAssignments / FrootFollowersAssignedAtBase);
        //Multiplier 
        BaseAssignmentAffinityBoost = MaxBaseAb * 0.0125f;
        
        //Total Happiness achieved via base assignments
        float Ab = MaxBaseAb + ((PercentOfFrootAffinityAssignments) * MaxBaseAb) * BaseAssignmentAffinityBoost;

        //Total froot followers assigned to quests
        float FrootFollowersAssignedToQuests = FrootPrestigeUpdated.GetComponent<QuestsDiplomacyManager>().FrootsCurrentlyQuesting;;
        //Total froot followers assigned to affinity quests
        float FrootFollowersAssignedToAffinityQuests = FrootPrestigeUpdated.GetComponent<QuestsDiplomacyManager>().FrootsQuestingatHome;

		//percentage of froot followers assigned to affinity quests
        float PercentOfFrootAffinityQuests = (FrootFollowersAssignedToAffinityQuests / FrootFollowersAssignedToQuests);
        
        //Total happiness achieved via quest assignements
        float Aq = MaxQuestAq + ((PercentOfFrootAffinityQuests) * MaxQuestAq *  QuestAffinityBoost);

		FrootAssignments = (Ab/10) + (Aq/10) - IdleIsBad ; //IdleIsBad is the reduction in froot assignment part of HI due to idle followers
		
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

		//float TotalBuildingsAtBase = 10;
		//float NumberOfDamangedBuildings = 2;
		//float NumberOfAffinityDamagedBuildings = 1;
		float PercentOfDamagedBuildings = ((Mathf.Abs(NumberOfDamangedBuildings /*- NumberOfAffinityDamagedBuildings*/)/TotalBuildingsAtBase));
		//float PercentOfDamagedAffinityBuildings = (NumberOfAffinityDamagedBuildings / TotalBuildingsAtBase);


		float y = ((PercentOfDamagedBuildings * BCCap) * DamagedBuildingReduction) /*+ ((PercentOfDamagedAffinityBuildings * BCCap) * DamagedAffinityBuildingReduction)*/;
		
		FrootBaseComfort = (x - y) / 10;
	}
	
	static void SetFrootPrestige()
	{
		float TotalP = 5;
		float TotalPrestige = 100;
		float CurrentPrestige = FrootPrestigeUpdated.GetComponent<QuestsDiplomacyManager>().Prestige_Froots;
		
		float PrestigeReduction = (TotalPrestige - CurrentPrestige) / TotalPrestige;

		FrootPrestige = (TotalP - ((PrestigeReduction) * TotalP)) / 10;

	}

	public static void RecalculateFrootHappinessIndex()
    {
		
		if(PlayerHasAFollowing == true)
		{
        SetFoodFactor();
        SetAssignmentFactor();
		//SetBaseHealth();
		SetBaseComfort();
		SetFrootPrestige();
		
		SetFrootHappiness();

		Debug.Log("Froot Happiness" + FrootHappiness);
		Debug.Log("Foof factor" + Foodfactor);
		Debug.Log("Froot Assignments" + FrootAssignments);
		Debug.Log("Base Health" + BaseHealth);
		Debug.Log("Froot Base Comfort" + FrootBaseComfort);
		Debug.Log("Froot Prestige" + FrootPrestige);
		}
	
	}

	IEnumerator IdleFollower()
	{
        float TotalFrootFollowers = 0f;

        foreach (var o in NPCSystem.followers)
        {
            if (o.type == "Fr")
            {
                TotalFrootFollowers++;
            }
        }

        float TotalFrootFollowersAssigned = 0f;

        foreach( var o in NPCSystem.followers)
        {
            if(o.status != "idle")
            {
                TotalFrootFollowersAssigned++;
            }
        }

        while (TotalFrootFollowersAssigned < TotalFrootFollowers)
		{
			RecalculateFrootHappinessIndex();
			float TotalFrootFollowersIdle = TotalFrootFollowers - TotalFrootFollowersAssigned;
			IdlePenalty = (TotalFrootFollowersIdle/TotalFrootFollowers) * 0.05f;
			IdleIsBad = IdleIsBad + IdlePenalty;
			yield return new WaitForSeconds(3f);
		}
		while(TotalFrootFollowersAssigned == TotalFrootFollowers)
		{
			IdleIsBad = 0f;
			yield return new WaitForSeconds(3f);
		}
	}


    // Update is called once per frame
    void Update()
    {
        float TotalFollowers = NPCSystem.followers.Count;

        if(TotalFollowers > 0)
		{
			PlayerHasAFollowing = true;
			ActiveHIUI.SetActive(true);
			InactiveHIUI.SetActive(false);
		}
		else if(TotalFollowers == 0)
		{
			PlayerHasAFollowing = false;
			ActiveHIUI.SetActive(false);
			InactiveHIUI.SetActive(true);
		}

	}
}
