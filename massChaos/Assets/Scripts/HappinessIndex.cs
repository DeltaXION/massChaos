using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HappinessIndex : MonoBehaviour
{
    private float FrootHappiness;
    private float Foodfactor;
    private float FrootBaseComfort;
    private float FrootAssignments;
    private float BaseHealth;
    private float FrootPrestige;
	private float TotalFollowers;
	private float IdleIsWrong;

	float TotalFrootFollowers = 15;
	float TotalFrootFollowersAssigned = 10;

    private float BaseAssignmentAffinityBoost = 0.025f;
	private float QuestAffinityBoost = 0.025f;
	private float DuplexBoost = 0.0125f;
	private float VillaBoost = 0.025f;
	private float DamagedBuildingReduction = 0.15f;
	private float DamagedAffinityBuildingReduction = 0.25f;
	private float IdleIsBad;
	


    public Text FrootHappinessUI;

	private GameObject FrootPrestigeUpdated;

    // Start is called before the first frame update
    void Start()
    {
        TotalFollowers = 15;
		FrootPrestigeUpdated = GameObject.Find("QuestsDiplomacyManager");

		StartCoroutine (IdleFollower());
    }

    void SetFrootHappiness()
    {
        
		FrootHappiness = (Foodfactor + FrootAssignments + BaseHealth + FrootBaseComfort + FrootPrestige);
        
		FrootHappinessUI.text = "Froot Happiness:" + FrootHappiness;
		
    }
    
    void SetFoodFactor()
    {
        float ConsumptionRate = 10;
        float TotalFoodStock = 100;
		
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

    void SetAssignmentFactor()
    {
        float A = 20; //This is the total BASE happiness that can be achieved via Follower assignments.
        float MaxBaseAb = A / 2;
        float MaxQuestAq = A / 2;
        float FrootFollowersAssignedAtBase = 6;
        float FrootFollowersAssignedToAffinityBaseAssignments = 2;
        float PercentOfFrootAffinityAssignments = (FrootFollowersAssignedToAffinityBaseAssignments / FrootFollowersAssignedAtBase);
        //BaseAssignmentAffinityBoost = MaxBaseAb * 0.0125f;
        
        float Ab = MaxBaseAb + ((PercentOfFrootAffinityAssignments) * MaxBaseAb) * BaseAssignmentAffinityBoost;

        float FrootFollowersAssignedToQuests = 5;
        float FrootFollowersAssignedToAffinityQuests = 5;
        float PercentOfFrootAffinityQuests = (FrootFollowersAssignedToAffinityQuests / FrootFollowersAssignedToQuests);
        

        float Aq = MaxQuestAq + ((PercentOfFrootAffinityQuests) * MaxQuestAq *  QuestAffinityBoost);

		//Debug.Log("happiness is reducing");
		FrootAssignments = (Ab/10) + (Aq/10) - IdleIsBad ;
		
    }

	void SetBaseHealth()
	{
		float TotalBH = 10;
		float TotalBaseHealth = 100;
		float CurrentBaseHealth = 80;
		float PercentReductionInBaseHealth = (CurrentBaseHealth / TotalBaseHealth);

		
		BaseHealth = (TotalBH - ((PercentReductionInBaseHealth) * TotalBH)) / 10;

	}

	void SetBaseComfort()
	{
		float TotalBC = 10f;
		float BCCap = 0.7f * TotalBC;
		float TotalFollowers = 15f;
        //Debug.Log("BCCap " + BCCap);

		float SimpleHouseCount = 1;
		float FollowersInSimpleHouse = SimpleHouseCount * 2;
		float PercentofFollowersInSH = ((FollowersInSimpleHouse / TotalFollowers));
		//Debug.Log("%inSH " + PercentofFollowersInSH);

		float DuplexCount = 1;
		float FollowersInDuplex = DuplexCount * 5;
		float PercentofFollowersInDup = ((FollowersInDuplex / TotalFollowers));
		//Debug.Log("%inD " + PercentofFollowersInDup);

		float VillaCount = 1;
		float FollowersInVillas = VillaCount * 7;
		float PercentofFollowersInVC = ((FollowersInVillas / TotalFollowers));
		//Debug.Log("%inVC " + PercentofFollowersInVC);

		
		float x = BCCap + ((PercentofFollowersInDup * BCCap) * DuplexBoost) + ((PercentofFollowersInVC * BCCap) * VillaBoost);
		//Debug.Log("X = " + x);

		float TotalBuildingsAtBase = 10;
		float NumberOfDamangedBuildings = 2;
		float NumberOfAffinityDamagedBuildings = 1;
		float PercentOfDamagedBuildings = ((Mathf.Abs(NumberOfDamangedBuildings - NumberOfAffinityDamagedBuildings)/TotalBuildingsAtBase));
		float PercentOfDamagedAffinityBuildings = (NumberOfAffinityDamagedBuildings / TotalBuildingsAtBase);


		float y = ((PercentOfDamagedBuildings * BCCap) * DamagedBuildingReduction) + ((PercentOfDamagedAffinityBuildings * BCCap) * DamagedAffinityBuildingReduction);
		//Debug.Log("Y = " + y);

		FrootBaseComfort = (x - y) / 10;
	}
	
	void SetFrootPrestige()
	{
		float TotalP = 5;
		float TotalPrestige = 100;
		//float CurrentPrestige = FrootPrestigeUpdated.GetComponent<QuestsDiplomacyManager>().Prestige_Froots;
		float CurrentPrestige = 45;

		float PrestigeReduction = (TotalPrestige - CurrentPrestige) / TotalPrestige;

		FrootPrestige = (TotalP - ((PrestigeReduction) * TotalP)) / 10;

	}

	void RecalculateHappinessIndex()
    {
        SetFoodFactor();
        SetAssignmentFactor();
		SetBaseHealth();
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

	IEnumerator IdleFollower()
	{
		while(TotalFrootFollowersAssigned < TotalFrootFollowers)
		{
			//IdlePenalty();
			//Debug.Log("REcalculating every 1s");
			RecalculateHappinessIndex();
			IdleIsBad = IdleIsBad + 0.05f;
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
        if(Input.GetKeyDown("space"))
		{
		RecalculateHappinessIndex();
		
		}

    }
}
