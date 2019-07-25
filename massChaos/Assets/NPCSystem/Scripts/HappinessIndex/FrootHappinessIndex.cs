using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FrootHappinessIndex : MonoBehaviour
{
    //These variables are for calculating the HAppiness index
    public static float FrootHappiness; //Calculated Happiness Index (HI)
    private static float FrootAssignments; //Assignment Dependency of HI (Froot)
    private static float FrootPrestige; //Prestige Dependency of HI (Froot)

    //public static float TotalFollowers = 20f; //Base Population (BB_Stats script) 

    //Variables for deducting for idleness
    private static float IdleIsWrong; //Deduction for Idle Followers (an idle mind is the devil's workshop remember?)
    private static float IdleIsBad;
    public static float IdlePenalty;

    //Multipliers for affiity
    public static float BaseAssignmentAffinityBoost = 0.025f; //Froots Assigned to affinity tasks at base
	public static float QuestAffinityBoost = 0.025f; //Froots Assigned to affinity tasks on quests

    //Variables for calculating Base Health Dependency
    //public static float CurrentBaseHealth = 80f; 

    //Variables to calculate prestige dependency
    public static float CurrentPrestige;

    
	public static bool PlayerHasAFollowing; //Bool to active HI only when there are followers at the base.

    //Game Object references 
	private static  GameObject QuestManager; //Reference to get prestige variable
	//private GameObject Froot_HappinessUI; 
	public GameObject ActiveHIUI; //UI Active state
	public GameObject InactiveHIUI; //UI Inactive State

    // Start is called before the first frame update
    void Start()
    {
        
		QuestManager = GameObject.Find("QuestsDiplomacyManager");
		FrootHappiness = 0f;

		StartCoroutine (IdleFollower());
    }

    private static void SetFrootHappiness()
    {
        
		FrootHappiness = (CommonHappinessIndex.CommonHappiness + FrootAssignments + FrootPrestige);
        
		//FrootHappinessUI.text = "Froot Happiness:" + FrootHappiness;
		
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
            if(o.type == "Fo")
            {
                TotalFrootFollowers++;
            }
        }

        float TotalIdleFrootFollowers = 0f; //Self explanatory

        //using the NPC List to count idle fruit followers
        foreach(var o in NPCSystem.followers)
        {
            if(o.type == "Fo" || o.status == "idle")
            {
                TotalIdleFrootFollowers++;
            }
        }

        //Total Froot followers given quest assignments
        float TotalFrootsAssignedToQuests = QuestManager.GetComponent<QuestsDiplomacyManager>().FrootsCurrentlyQuesting;
        float FrootFollowersAssignedAtBase = TotalFrootFollowers - TotalIdleFrootFollowers; //total froot followers assigned at base     
        float FrootFollowersAssignedToAffinityBaseAssignments = 0f;//Total froot followers assigned to farming
        
        //using NPC List to count the number of NPCs engaged in farming at base
        foreach(var o in NPCSystem.followers)
        {
            if(o.type == "Fo" || o.status == "farming")
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
        float FrootFollowersAssignedToQuests = QuestManager.GetComponent<QuestsDiplomacyManager>().FrootsCurrentlyQuesting;;
        //Total froot followers assigned to affinity quests
        float FrootFollowersAssignedToAffinityQuests = QuestManager.GetComponent<QuestsDiplomacyManager>().FrootsQuestingatHome;

		//percentage of froot followers assigned to affinity quests
        float PercentOfFrootAffinityQuests = (FrootFollowersAssignedToAffinityQuests / FrootFollowersAssignedToQuests);
        
        //Total happiness achieved via quest assignements
        float Aq = MaxQuestAq + ((PercentOfFrootAffinityQuests) * MaxQuestAq *  QuestAffinityBoost);

		FrootAssignments = (Ab/10) + (Aq/10) - IdleIsBad ; //IdleIsBad is the reduction in froot assignment part of HI due to idle followers
		
    }

	
	
	static void SetFrootPrestige()
	{
		float TotalP = 5;
		float TotalPrestige = 100;
		float CurrentPrestige = QuestManager.GetComponent<QuestsDiplomacyManager>().Prestige_Froots;
		
		float PrestigeReduction = (TotalPrestige - CurrentPrestige) / TotalPrestige;

		FrootPrestige = (TotalP - ((PrestigeReduction) * TotalP)) / 10;

	}

	public static void RecalculateFrootHappinessIndex()
    {
		
		if(PlayerHasAFollowing == true)
		{
        SetAssignmentFactor();
		//SetBaseHealth();
		//SetBaseComfort();
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
        float TotalFrootFollowers = 0f;

        foreach (var o in NPCSystem.followers)
        {
            if (o.type == "Fo")
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
        float TotalFrootFollowers = 0f;

        foreach(var o in NPCSystem.followers)
        {
            if(o.type == "Fo")
            {
                TotalFrootFollowers++;
            }
        }

        if(TotalFollowers > 0 || TotalFrootFollowers > 0)
		{
			PlayerHasAFollowing = true;
			ActiveHIUI.SetActive(true);
			InactiveHIUI.SetActive(false);
		}
		else if(TotalFollowers == 0 || TotalFrootFollowers == 0)
		{
			PlayerHasAFollowing = false;
			ActiveHIUI.SetActive(false);
			InactiveHIUI.SetActive(true);
		}

	}
}
