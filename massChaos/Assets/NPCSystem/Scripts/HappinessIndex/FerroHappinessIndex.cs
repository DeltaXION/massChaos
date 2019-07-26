using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FerroHappinessIndex : MonoBehaviour
{
    //These variables are for calculating the HAppiness index
    public static float FerroHappiness; //Calculated Happiness Index (HI)
    private static float FerroAssignments; //Assignment Dependency of HI (Ferro)
    private static float FerroPrestige; //Prestige Dependency of HI (Ferro)

    //public static float TotalFollowers = 20f; //Base Population (BB_Stats script) 

    //Variables for deducting for idleness
    private static float IdleIsWrong; //Deduction for Idle Followers (an idle mind is the devil's workshop remember?)
    private static float IdleIsBad;
    public static float IdlePenalty;

    //Multipliers for affiity
    public static float BaseAssignmentAffinityBoost = 0.025f; //Ferros Assigned to affinity tasks at base
    public static float QuestAffinityBoost = 0.025f; //Ferros Assigned to affinity tasks on quests

    //Variables for calculating Base Health Dependency
    //public static float CurrentBaseHealth = 80f; 

    //Variables to calculate prestige dependency
    public static float CurrentPrestige;


    public static bool PlayerHasAFollowing; //Bool to active HI only when there are followers at the base.

    //Game Object references 
    private static GameObject QuestManager; //Reference to get prestige variable
                                            //private GameObject Ferro_HappinessUI; 
    public GameObject ActiveHIUI; //UI Active state
    public GameObject InactiveHIUI; //UI Inactive State

    // Start is called before the first frame update
    void Start()
    {

        QuestManager = GameObject.Find("QuestsDiplomacyManager");
        FerroHappiness = 0f;

        StartCoroutine(IdleFollower());
    }

    private static void SetFerroHappiness()
    {

        FerroHappiness = (CommonHappinessIndex.CommonHappiness + FerroAssignments + FerroPrestige);

        //FerroHappinessUI.text = "Ferro Happiness:" + FerroHappiness;

    }


    static void SetAssignmentFactor()
    {
        float A = 20; //This is the total BASE happiness that can be achieved via basic Follower assignments.
        float MaxBaseAb = A / 2; //Total base happiness that can be achieved via basic base assignments
        float MaxQuestAq = A / 2; //Total base happiness that can be achieved via basic quest assignments
        float TotalFerroFollowers = 0f; //Total base population

        //using the NPCList to count Ferro followers
        foreach (var o in NPCSystem.followers)
        {
            if (o.Type == "Fr")
            {
                TotalFerroFollowers++;
            }
        }

        float TotalIdleFerroFollowers = 0f; //Self explanatory

        //using the NPC List to count idle fruit followers
        foreach (var o in NPCSystem.followers)
        {
            if (o.Type == "Fr" && o.Status == "idle")
            {
                TotalIdleFerroFollowers++;
            }
        }

        //Total Ferro followers given quest assignments
        float TotalFerrosAssignedToQuests = QuestManager.GetComponent<QuestsDiplomacyManager>().FerrariumCurrentlyQuesting;
        float FerroFollowersAssignedAtBase = TotalFerroFollowers - TotalIdleFerroFollowers; //total Ferro followers assigned at base     
        float FerroFollowersAssignedToAffinityBaseAssignments = 0f;//Total Ferro followers assigned to farming

        //using NPC List to count the number of NPCs engaged in farming at base
        foreach (var o in NPCSystem.followers)
        {
            if (o.Type == "Fr" && o.Status == "Workshop")
            {
                FerroFollowersAssignedToAffinityBaseAssignments++;
            }
        }

        //PErcentage of Ferros given affinity assignments at base
        float PercentOfFerroAffinityAssignments = (FerroFollowersAssignedToAffinityBaseAssignments / FerroFollowersAssignedAtBase);
        //Multiplier 

        float Ab = 0;

        //Total Happiness achieved via base assignments
        if (FerroFollowersAssignedAtBase == 0)
        {
            Ab = 0;
        }
        else if (FerroFollowersAssignedAtBase > 0)
        {
            Ab = MaxBaseAb + ((PercentOfFerroAffinityAssignments) * MaxBaseAb) * BaseAssignmentAffinityBoost;
        }
        //Total Ferro followers assigned to quests
        float FerroFollowersAssignedToQuests = QuestManager.GetComponent<QuestsDiplomacyManager>().FerrariumCurrentlyQuesting;
        //Total Ferro followers assigned to affinity quests
        float FerroFollowersAssignedToAffinityQuests = QuestManager.GetComponent<QuestsDiplomacyManager>().FerrariumQuestingatHome;

        //percentage of Ferro followers assigned to affinity quests
        float PercentOfFerroAffinityQuests = (FerroFollowersAssignedToAffinityQuests / FerroFollowersAssignedToQuests);
        float Aq = 0;
        //Total happiness achieved via quest assignements
        if (FerroFollowersAssignedToQuests == 0)
        {
            Aq = 0;
        }
        else if (FerroFollowersAssignedToQuests > 0)
        {
            Aq = MaxQuestAq + ((PercentOfFerroAffinityQuests) * MaxQuestAq * QuestAffinityBoost);
        }
        FerroAssignments = (Ab / 10) + (Aq / 10) - IdleIsBad; //IdleIsBad is the reduction in Ferro assignment part of HI due to idle followers

    }



    static void SetFerroPrestige()
    {
        float TotalP = 5;
        float TotalPrestige = 100;
        float CurrentPrestige = QuestManager.GetComponent<QuestsDiplomacyManager>().Prestige_Ferrarium;

        float PrestigeReduction = (TotalPrestige - CurrentPrestige) / TotalPrestige;

        if (CurrentPrestige == 0)
        {
            FerroPrestige = 0;
        }
        else if (CurrentPrestige > 0)
        {
            FerroPrestige = (TotalP - ((PrestigeReduction) * TotalP)) / 10;
        }
    }

    public static void RecalculateFerroHappinessIndex()
    {

        if (PlayerHasAFollowing == true)
        {
            SetAssignmentFactor();
            SetFerroPrestige();
            SetFerroHappiness();
        }

    }

    IEnumerator IdleFollower()
    {
        float TotalFerroFollowers = 0f;

        foreach (var o in NPCSystem.followers)
        {
            if (o.Type == "Fr")
            {
                TotalFerroFollowers++;
            }
        }

        float TotalFerroFollowersAssigned = 0f;

        foreach (var o in NPCSystem.followers)
        {
            if (o.Status != "idle")
            {
                TotalFerroFollowersAssigned++;
            }
        }

        while (TotalFerroFollowersAssigned < TotalFerroFollowers)
        {
            RecalculateFerroHappinessIndex();
            float TotalFerroFollowersIdle = TotalFerroFollowers - TotalFerroFollowersAssigned;
            IdlePenalty = (TotalFerroFollowersIdle / TotalFerroFollowers) * 0.05f;
            IdleIsBad = IdleIsBad + IdlePenalty;
            yield return new WaitForSeconds(3f);
        }
        while (TotalFerroFollowersAssigned == TotalFerroFollowers)
        {
            IdleIsBad = 0f;
            yield return new WaitForSeconds(3f);
        }
    }


    // Update is called once per frame
    void Update()
    {
        float TotalFollowers = NPCSystem.followers.Count;

        float TotalFerroFollowers = 0f;

        foreach (var o in NPCSystem.followers)
        {
            if (o.Type == "Fr")
            {
                TotalFerroFollowers++;
            }
        }

        if (TotalFollowers > 0 && TotalFerroFollowers >0)
        {
            PlayerHasAFollowing = true;
            ActiveHIUI.SetActive(true);
            InactiveHIUI.SetActive(false);
        }
        else if (TotalFollowers == 0 && TotalFerroFollowers == 0)
        {
            PlayerHasAFollowing = false;
            ActiveHIUI.SetActive(false);
            InactiveHIUI.SetActive(true);
        }

    }
}
