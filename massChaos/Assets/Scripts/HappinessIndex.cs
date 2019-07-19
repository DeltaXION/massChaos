using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HappinessIndex : MonoBehaviour
{
    private int FrootHappiness;
    private float Foodfactor;
    private float FrootBaseComfort;
    private float FrootAssignments;
    private float BaseHealth;
    private float FrootPrestige;
	private float TotalFollowersInBase;

    private float BaseAssignmentAffinityBoost = 0.025f;
	private float QuestAffinityBoost = 0.025f;
	private float DuplexBoost = 0.025f;
	private float VillaBoost = 0.05f;
	private float DamagedBuildingReduction = 0.15f;
	private float DamagedAffinityBuildingReduction = 0.175f;


    public Text FrootHappinessUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void SetFrootHappiness()
    {
        FrootHappiness = Mathf.RoundToInt(Foodfactor + FrootAssignments + BaseHealth + FrootBaseComfort);
        FrootHappinessUI.text = "Froot Happiness:" + FrootHappiness;
		Debug.Log("Froot Happiness" + FrootHappiness);
    }
    
    void SetFoodFactor()
    {
        float ConsumptionRate = 10f;
        float TotalFoodStock = 100f;
		float TotalFollowersInBase = 15f;
        float StarvingFollowers = (TotalFollowersInBase - (TotalFoodStock / ConsumptionRate));
        float StarvingPercentage = (StarvingFollowers / TotalFollowersInBase) * 100f;
        float F = 40; //This is the Total possible happiness that can be achieved via Food

        if (TotalFoodStock >= (ConsumptionRate * TotalFollowersInBase))
        {
            Foodfactor = F/10;
        }
        else
        {
            Foodfactor = (F - ((StarvingPercentage / 100) * F))/10;
        }
    }

    void SetAssignmentFactor()
    {
        float A = 20f; //This is the total BASE happiness that can be achieved via Follower assignments.
        float MaxBaseAb = A / 2;
        float MaxQuestAq = A / 2;
        float FrootFollowersAssignedAtBase = 6f;
        float FrootFollowersAssignedToAffinityBaseAssignments = 2f;
        float PercentOfFrootAffinityAssignments = (FrootFollowersAssignedToAffinityBaseAssignments / FrootFollowersAssignedAtBase) * 100;
        //BaseAssignmentAffinityBoost = MaxBaseAb * 0.0125f;
        
        float Ab = MaxBaseAb + ((PercentOfFrootAffinityAssignments / 100) * MaxBaseAb) * BaseAssignmentAffinityBoost;

        float FrootFollowersAssignedToQuests = 5f;
        float FrootFollowersAssignedToAffinityQuests = 5f;
        float PercentOfFrootAffinityQuests = (FrootFollowersAssignedToAffinityQuests / FrootFollowersAssignedToQuests) * 100;
        

        float Aq = MaxQuestAq + ((PercentOfFrootAffinityQuests / 100) * MaxQuestAq) * QuestAffinityBoost;

        FrootAssignments = (Ab/10) + (Aq/10);

    }

	void SetBaseHealth()
	{
		float TotalBH = 10f;
		float TotalBaseHealth = 100f;
		float CurrentBaseHealth = 80f;
		float PercentReductionInBaseHealth = (CurrentBaseHealth / TotalBaseHealth) * 100f;

		
		BaseHealth = TotalBH - ((PercentReductionInBaseHealth / 100) * TotalBH);

	}

	void SetBaseComfort()
	{
		float TotalBC = 10f;
		float BCCap = TotalBC - ((30/100) * TotalBC);
		float TotalFollowersInBase = 15f;
        

		float SimpleHouseCount = 1f;
		float FollowersInSimpleHouse = SimpleHouseCount * 2f;
		float PercentofFollowersInSH = ((FollowersInSimpleHouse / TotalFollowersInBase) * 100f);

		float DuplexCount = 1f;
		float FollowersInDuplex = DuplexCount * 5f;
		float PercentofFollowersInDup = ((FollowersInDuplex / TotalFollowersInBase) * 100f);

		float VillaCount = 1f;
		float FollowersInVillas = VillaCount * 7f;
		float PercentofFollowersInVC = ((FollowersInVillas / TotalFollowersInBase) * 100f);

		
		float x = BCCap + (((PercentofFollowersInDup/100) * BCCap) * DuplexBoost) + (((PercentofFollowersInVC / 100) * BCCap) * VillaBoost);

		float TotalBuildingsAtBase = 10f;
		float NumberOfDamangedBuildings = 2f;
		float NumberOfAffinityDamagedBuildings = 1f;
		float PercentOfDamagedBuildings = ((Mathf.Abs(NumberOfDamangedBuildings - NumberOfAffinityDamagedBuildings)/TotalBuildingsAtBase) * 100f);
		float PercentOfDamagedAffinityBuildings = (NumberOfAffinityDamagedBuildings / TotalBuildingsAtBase) * 100f;


		float y = ((PercentOfDamagedBuildings /100f) * DamagedBuildingReduction) + ((PercentOfDamagedAffinityBuildings / 100f) * DamagedAffinityBuildingReduction);

		FrootBaseComfort = (x + y) / 10f;
	}
	

    void RecalculateHappinessIndex()
    {
        SetFoodFactor();
        SetAssignmentFactor();
		SetBaseHealth();
		SetBaseComfort();
		SetFrootHappiness();

    }

    // Update is called once per frame
    void Update()
    {
        
		RecalculateHappinessIndex();


    }
}
