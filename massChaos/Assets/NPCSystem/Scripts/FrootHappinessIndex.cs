using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FrootHappinessIndex : MonoBehaviour
{
    public static float FrootHappiness;
    private static float Foodfactor;
    private static float FrootBaseComfort;
    private static float FrootAssignments;
    private static float BaseHealth;
    private static float FrootPrestige;
	public static float TotalFollowers = 20f;
	private static float IdleIsWrong;

	public static float TotalFrootFollowers = 15;
	public static float TotalFrootFollowersAssigned = 10;
	private static float TotalFrootFollowersIdle;

    public static float BaseAssignmentAffinityBoost = 0.025f;
	public static float QuestAffinityBoost = 0.025f;
	public static float DuplexBoost = 0.0125f;
	public static float VillaBoost = 0.025f;
	public static float DamagedBuildingReduction = 0.15f;
	public static float DamagedAffinityBuildingReduction = 0.25f;
	private static float IdleIsBad;
	public static float IdlePenalty;
	public static float ConsumptionRate = 10f;
    public static float TotalFoodStock;
	public static float FrootFollowersAssignedAtBase = 6f;
    public static float FrootFollowersAssignedToAffinityBaseAssignments = 2f;
	public static float FrootFollowersAssignedToQuests;
    public static float FrootFollowersAssignedToAffinityQuests = 5f;
	public static float CurrentBaseHealth = 80f;
	public static float SimpleHouseCount = 1f;
	public static float DuplexCount = 1;
	public static float VillaCount = 1;
	public static float TotalBuildingsAtBase = 10;
	public static float NumberOfDamangedBuildings = 2;
	public static float NumberOfAffinityDamagedBuildings = 1;
	public static float CurrentPrestige;

    
	public static bool PlayerHasAFollowing;

	private static  GameObject FrootPrestigeUpdated;
	private GameObject Froot_HappinessUI;
	public GameObject ActiveHIUI;
	public GameObject InactiveHIUI;

    // Start is called before the first frame update
    void Start()
    {
        
		FrootPrestigeUpdated = GameObject.Find("QuestsDiplomacyManager");
		FrootHappiness = 0f;

		StartCoroutine (IdleFollower());
    }

    public static void SetFrootHappiness()
    {
        
		FrootHappiness = (Foodfactor + FrootAssignments + BaseHealth + FrootBaseComfort + FrootPrestige);
        
		//FrootHappinessUI.text = "Froot Happiness:" + FrootHappiness;
		
    }
    
	
    static void SetFoodFactor()
    {
		//float ConsumptionRate = 10f;
        float TotalFoodStock = (float) ResourceManager.food;
		
		
        float StarvingFollowers = (TotalFollowers - (TotalFoodStock / ConsumptionRate));
        float StarvingPercentage = (StarvingFollowers / TotalFollowers);
        float F = 40; //This is the Total possible happiness that can be achieved via Food

        if (TotalFoodStock >= (ConsumptionRate * TotalFollowers))
        {
            Foodfactor = F/10;
        }
        else
        {
            Foodfactor = (F - ((StarvingPercentage) * F))/10;
        }
    }

    static void SetAssignmentFactor()
    {
        float A = 20; //This is the total BASE happiness that can be achieved via Follower assignments.
        float MaxBaseAb = A / 2;
        float MaxQuestAq = A / 2;
        //float FrootFollowersAssignedAtBase = 6;
        //float FrootFollowersAssignedToAffinityBaseAssignments = 2;
        float PercentOfFrootAffinityAssignments = (FrootFollowersAssignedToAffinityBaseAssignments / FrootFollowersAssignedAtBase);
        //BaseAssignmentAffinityBoost = MaxBaseAb * 0.0125f;
        
        float Ab = MaxBaseAb + ((PercentOfFrootAffinityAssignments) * MaxBaseAb) * BaseAssignmentAffinityBoost;

        float FrootFollowersAssignedToQuests = FrootPrestigeUpdated.GetComponent<QuestsDiplomacyManager>().FrootsCurrentlyQuesting;;
        //float FrootFollowersAssignedToAffinityQuests = 5;

		
        float PercentOfFrootAffinityQuests = (FrootFollowersAssignedToAffinityQuests / FrootFollowersAssignedToQuests);
        

        float Aq = MaxQuestAq + ((PercentOfFrootAffinityQuests) * MaxQuestAq *  QuestAffinityBoost);

		//Debug.Log("happiness is reducing");
		FrootAssignments = (Ab/10) + (Aq/10) - IdleIsBad ;
		
    }

	static void SetBaseHealth()
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
	}

	static void SetBaseComfort()
	{
		float TotalBC = 10f;
		float BCCap = 0.7f * TotalBC;
		//Debug.Log("BCCap " + BCCap);

		//float SimpleHouseCount = 1;
		float FollowersInSimpleHouse = SimpleHouseCount * 2;
		float PercentofFollowersInSH = ((FollowersInSimpleHouse / TotalFollowers));
		//Debug.Log("%inSH " + PercentofFollowersInSH);

		//float DuplexCount = 1;
		float FollowersInDuplex = DuplexCount * 5;
		float PercentofFollowersInDup = ((FollowersInDuplex / TotalFollowers));
		//Debug.Log("%inD " + PercentofFollowersInDup);

		//float VillaCount = 1;
		float FollowersInVillas = VillaCount * 7;
		float PercentofFollowersInVC = ((FollowersInVillas / TotalFollowers));
		//Debug.Log("%inVC " + PercentofFollowersInVC);

		
		float x = BCCap + ((PercentofFollowersInDup * BCCap) * DuplexBoost) + ((PercentofFollowersInVC * BCCap) * VillaBoost);
		//Debug.Log("X = " + x);

		//float TotalBuildingsAtBase = 10;
		//float NumberOfDamangedBuildings = 2;
		//float NumberOfAffinityDamagedBuildings = 1;
		float PercentOfDamagedBuildings = ((Mathf.Abs(NumberOfDamangedBuildings - NumberOfAffinityDamagedBuildings)/TotalBuildingsAtBase));
		float PercentOfDamagedAffinityBuildings = (NumberOfAffinityDamagedBuildings / TotalBuildingsAtBase);


		float y = ((PercentOfDamagedBuildings * BCCap) * DamagedBuildingReduction) + ((PercentOfDamagedAffinityBuildings * BCCap) * DamagedAffinityBuildingReduction);
		//Debug.Log("Y = " + y);

		FrootBaseComfort = (x - y) / 10;
	}
	
	static void SetFrootPrestige()
	{
		float TotalP = 5;
		float TotalPrestige = 100;
		float CurrentPrestige = FrootPrestigeUpdated.GetComponent<QuestsDiplomacyManager>().Prestige_Froots;
		//float CurrentPrestige = 45;

		float PrestigeReduction = (TotalPrestige - CurrentPrestige) / TotalPrestige;

		FrootPrestige = (TotalP - ((PrestigeReduction) * TotalP)) / 10;

	}

	public static void RecalculateHappinessIndex()
    {
		
		if(PlayerHasAFollowing == true)
		{
        SetFoodFactor();
        SetAssignmentFactor();
		SetBaseHealth();
		SetBaseComfort();
		SetFrootPrestige();
		
		SetFrootHappiness();

		//Debug.Log("Froot Happiness" + FrootHappiness);
		//Debug.Log("Foof factor" + Foodfactor);
		//Debug.Log("Froot Assignments" + FrootAssignments);
		//Debug.Log("Base Health" + BaseHealth);
		//Debug.Log("Froot Base Comfort" + FrootBaseComfort);
		//Debug.Log("Froot Prestige" + FrootPrestige);
		}
	
	}

	IEnumerator IdleFollower()
	{
		while(TotalFrootFollowersAssigned < TotalFrootFollowers)
		{
			//Debug.Log("REcalculating every 1s");
			RecalculateHappinessIndex();
			TotalFrootFollowersIdle = TotalFrootFollowers - TotalFrootFollowersAssigned;
			IdlePenalty = (TotalFrootFollowersIdle/TotalFrootFollowers) * 0.05f;
			IdleIsBad = IdleIsBad + IdlePenalty;
			yield return new WaitForSeconds(3f);
		}
		while(TotalFrootFollowersAssigned == TotalFrootFollowers)
		{
			IdleIsBad = 0f;
			yield return new WaitForSeconds(1f);
		}
	}


    // Update is called once per frame
    void Update()
    {
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
