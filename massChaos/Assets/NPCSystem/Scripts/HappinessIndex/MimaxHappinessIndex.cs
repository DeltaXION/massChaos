using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MimaxHappniessIndex : MonoBehaviour
{
    //These variables are for calculating the HAppiness index
    public static float MimaxHappiness; //Calculated Happiness Index (HI)
    private static float MimaxAssignments; //Assignment Dependency of HI (Mimax)
    private static float MimaxPrestige; //Prestige Dependency of HI (Mimax)

    //public static float TotalFollowers = 20f; //Base Population (BB_Stats script) 

    //Variables for deducting for idleness
    private static float IdleIsWrong; //Deduction for Idle Followers (an idle mind is the devil's workshop remember?)
    private static float IdleIsBad;
    public static float IdlePenalty;

    //Multipliers for affiity
    public static float BaseAssignmentAffinityBoost = 0.025f; //Mimaxs Assigned to affinity tasks at base
    public static float QuestAffinityBoost = 0.025f; //Mimaxs Assigned to affinity tasks on quests

    //Variables for calculating Base Health Dependency
    //public static float CurrentBaseHealth = 80f; 

    //Variables to calculate prestige dependency
    public static float CurrentPrestige;


    public static bool PlayerHasAFollowing; //Bool to active HI only when there are followers at the base.

    //Game Object references 
    private static GameObject QuestManager; //Reference to get prestige variable
                                            //private GameObject Mimax_HappinessUI; 
    public GameObject ActiveHIUI; //UI Active state
    public GameObject InactiveHIUI; //UI Inactive State

    // Start is called before the first frame update
    void Start()
    {

        QuestManager = GameObject.Find("QuestsDiplomacyManager");
        MimaxHappiness = 0f;

        StartCoroutine(IdleFollower());
    }

    private static void SetMimaxHappiness()
    {

        MimaxHappiness = (CommonHappinessIndex.CommonHappiness + MimaxAssignments + MimaxPrestige);

        //MimaxHappinessUI.text = "Mimax Happiness:" + MimaxHappiness;

    }


    static void SetAssignmentFactor()
    {
        float A = 20; //This is the total BASE happiness that can be achieved via basic Follower assignments.
        float MaxBaseAb = A / 2; //Total base happiness that can be achieved via basic base assignments
        float MaxQuestAq = A / 2; //Total base happiness that can be achieved via basic quest assignments
        float TotalMimaxFollowers = 0f; //Total base population

        //using the NPCList to count Mimax followers
        foreach (var o in NPCSystem.followers)
        {
            if (o.Type == "M")
            {
                TotalMimaxFollowers++;
            }
        }

        float TotalIdleMimaxFollowers = 0f; //Self explanatory

        //using the NPC List to count idle fruit followers
        foreach (var o in NPCSystem.followers)
        {
            if (o.Type == "M" && o.Status == "idle")
            {
                TotalIdleMimaxFollowers++;
            }
        }

        //Total Mimax followers given quest assignments
        float TotalMimaxsAssignedToQuests = QuestManager.GetComponent<QuestsDiplomacyManager>().MimaxCurrentlyQuesting;
        float MimaxFollowersAssignedAtBase = TotalMimaxFollowers - TotalIdleMimaxFollowers; //total Mimax followers assigned at base     
        float MimaxFollowersAssignedToAffinityBaseAssignments = 0f;//Total Mimax followers assigned to farming

        //using NPC List to count the number of NPCs engaged in farming at base
        foreach (var o in NPCSystem.followers)
        {
            if (o.Type == "M" && (o.Status == "Barracks" || o.Status == "OutPost"))
            {
                MimaxFollowersAssignedToAffinityBaseAssignments++;
            }
        }

        //PErcentage of Mimaxs given affinity assignments at base
        float PercentOfMimaxAffinityAssignments = (MimaxFollowersAssignedToAffinityBaseAssignments / MimaxFollowersAssignedAtBase);
        //Multiplier 
        

        float Ab = 0;

        //Total Happiness achieved via base assignments
        if (MimaxFollowersAssignedAtBase == 0)
        {
            Ab = 0;
        }
        else if (MimaxFollowersAssignedAtBase > 0)
        {
            Ab = MaxBaseAb + ((PercentOfMimaxAffinityAssignments) * MaxBaseAb) * BaseAssignmentAffinityBoost;
        }
        //Total Mimax followers assigned to quests
        float MimaxFollowersAssignedToQuests = QuestManager.GetComponent<QuestsDiplomacyManager>().MimaxCurrentlyQuesting;
        //Total Mimax followers assigned to affinity quests
        float MimaxFollowersAssignedToAffinityQuests = QuestManager.GetComponent<QuestsDiplomacyManager>().MimaxQuestingatHome;

        //percentage of Mimax followers assigned to affinity quests
        float PercentOfMimaxAffinityQuests = (MimaxFollowersAssignedToAffinityQuests / MimaxFollowersAssignedToQuests);

        float Aq = 0;
        //Total happiness achieved via quest assignements
        if (MimaxFollowersAssignedToQuests == 0)
        {
            Aq = 0;
        }
        else if (MimaxFollowersAssignedToQuests > 0)
        {
            Aq = MaxQuestAq + ((PercentOfMimaxAffinityQuests) * MaxQuestAq * QuestAffinityBoost);
        }
        MimaxAssignments = (Ab / 10) + (Aq / 10) - IdleIsBad; //IdleIsBad is the reduction in Mimax assignment part of HI due to idle followers

    }



    static void SetMimaxPrestige()
    {
        float TotalP = 5;
        float TotalPrestige = 100;
        float CurrentPrestige = QuestManager.GetComponent<QuestsDiplomacyManager>().Prestige_Mimax;

        float PrestigeReduction = (TotalPrestige - CurrentPrestige) / TotalPrestige;

        if (CurrentPrestige == 0)
        {
            MimaxPrestige = 0;
        }
        else if (CurrentPrestige > 0)
        {
            MimaxPrestige = (TotalP - ((PrestigeReduction) * TotalP)) / 10;
        }

    }

    public static void RecalculateMimaxHappinessIndex()
    {

        if (PlayerHasAFollowing == true)
        {
            SetAssignmentFactor();
            SetMimaxPrestige();
            SetMimaxHappiness();
        }

    }

    IEnumerator IdleFollower()
    {
        float TotalMimaxFollowers = 0f;

        foreach (var o in NPCSystem.followers)
        {
            if (o.Type == "M")
            {
                TotalMimaxFollowers++;
            }
        }

        float TotalMimaxFollowersAssigned = 0f;

        foreach (var o in NPCSystem.followers)
        {
            if (o.Status != "idle")
            {
                TotalMimaxFollowersAssigned++;
            }
        }

        while (TotalMimaxFollowersAssigned < TotalMimaxFollowers)
        {
            RecalculateMimaxHappinessIndex();
            float TotalMimaxFollowersIdle = TotalMimaxFollowers - TotalMimaxFollowersAssigned;
            IdlePenalty = (TotalMimaxFollowersIdle / TotalMimaxFollowers) * 0.05f;
            IdleIsBad = IdleIsBad + IdlePenalty;
            yield return new WaitForSeconds(3f);
        }
        while (TotalMimaxFollowersAssigned == TotalMimaxFollowers)
        {
            IdleIsBad = 0f;
            yield return new WaitForSeconds(3f);
        }
    }


    // Update is called once per frame
    void Update()
    {
        float TotalFollowers = NPCSystem.followers.Count;

        float TotalMimaxFollowers = 0f;

        foreach (var o in NPCSystem.followers)
        {
            if (o.Type == "M")
            {
                TotalMimaxFollowers++;
            }
        }

        if (TotalFollowers > 0 && TotalMimaxFollowers > 0)
        {
            PlayerHasAFollowing = true;
            ActiveHIUI.SetActive(true);
            InactiveHIUI.SetActive(false);
        }
        else if (TotalFollowers == 0 && TotalMimaxFollowers == 0)
        {
            PlayerHasAFollowing = false;
            ActiveHIUI.SetActive(false);
            InactiveHIUI.SetActive(true);
        }

    }
}

