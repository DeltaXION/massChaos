using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NomadHappinessIndex : MonoBehaviour
{
    //These variables are for calculating the HAppiness index
    public static float NomadHappiness; //Calculated Happiness Index (HI)
    private static float NomadAssignments; //Assignment Dependency of HI (Nomad)
    private static float NomadPrestige; //Prestige Dependency of HI (Nomad)

    //public static float TotalFollowers = 20f; //Base Population (BB_Stats script) 

    //Variables for deducting for idleness
    private static float IdleIsWrong; //Deduction for Idle Followers (an idle mind is the devil's workshop remember?)
    private static float IdleIsBad;
    public static float IdlePenalty;

    //Multipliers for affiity
    public static float BaseAssignmentAffinityBoost = 0.025f; //Nomads Assigned to affinity tasks at base
    public static float QuestAffinityBoost = 0.025f; //Nomads Assigned to affinity tasks on quests

    //Variables for calculating Base Health Dependency
    //public static float CurrentBaseHealth = 80f; 

    //Variables to calculate prestige dependency
    public static float CurrentPrestige;


    public static bool PlayerHasAFollowing; //Bool to active HI only when there are followers at the base.

    //Game Object references 
    private static GameObject QuestManager; //Reference to get prestige variable
                                            //private GameObject Nomad_HappinessUI; 
    public GameObject ActiveHIUI; //UI Active state
    public GameObject InactiveHIUI; //UI Inactive State

    // Start is called before the first frame update
    void Start()
    {

        QuestManager = GameObject.Find("QuestsDiplomacyManager");
        NomadHappiness = 0f;

        StartCoroutine(IdleFollower());
    }

    private static void SetNomadHappiness()
    {

        NomadHappiness = (CommonHappinessIndex.CommonHappiness + NomadAssignments + NomadPrestige);

        //NomadHappinessUI.text = "Nomad Happiness:" + NomadHappiness;

    }


    static void SetAssignmentFactor()
    {
        float A = 20; //This is the total BASE happiness that can be achieved via basic Follower assignments.
        float MaxBaseAb = A / 2; //Total base happiness that can be achieved via basic base assignments
        float MaxQuestAq = A / 2; //Total base happiness that can be achieved via basic quest assignments
        float TotalNomadFollowers = 0f; //Total base population
        

        //using the NPCList to count Nomad followers
        foreach (var o in NPCSystem.followers)
        {
            if (o.Type == "N")
            {
                TotalNomadFollowers++;
            }
        }

        float TotalIdleNomadFollowers = 0f; //Self explanatory

        //using the NPC List to count idle fruit followers
        foreach (var o in NPCSystem.followers)
        {
            if (o.Type == "N" && o.Status == "idle")
            {
                TotalIdleNomadFollowers++;
            }
        }

        //Total Nomad followers given quest assignments
        float TotalNomadsAssignedToQuests = QuestManager.GetComponent<QuestsDiplomacyManager>().NomadsCurrentlyQuesting;
        float NomadFollowersAssignedAtBase = TotalNomadFollowers - TotalIdleNomadFollowers; //total Nomad followers assigned at base     
        float NomadFollowersAssignedToAffinityBaseAssignments = 0f;//Total Nomad followers assigned to farming

        //using NPC List to count the number of NPCs engaged in farming at base
        foreach (var o in NPCSystem.followers)
        {
            if (o.Type == "N" && o.Status == "Barracks")
            {
                NomadFollowersAssignedToAffinityBaseAssignments++;
            }
        }

        //PErcentage of Nomads given affinity assignments at base
        float PercentOfNomadAffinityAssignments = (NomadFollowersAssignedToAffinityBaseAssignments / NomadFollowersAssignedAtBase);
        //Multiplier 
        float Ab = 0;

        //Total Happiness achieved via base assignments
        if (NomadFollowersAssignedAtBase == 0)
        {
            Ab = 0;
        }
        else if (NomadFollowersAssignedAtBase > 0)
        { 
            Ab = MaxBaseAb + ((PercentOfNomadAffinityAssignments) * MaxBaseAb) * BaseAssignmentAffinityBoost;
        }

        //Total Nomad followers assigned to quests
        float NomadFollowersAssignedToQuests = QuestManager.GetComponent<QuestsDiplomacyManager>().NomadsCurrentlyQuesting;
        //Total Nomad followers assigned to affinity quests
        float NomadFollowersAssignedToAffinityQuests = QuestManager.GetComponent<QuestsDiplomacyManager>().NomadsQuestingatHome;

        //percentage of Nomad followers assigned to affinity quests
        float PercentOfNomadAffinityQuests = (NomadFollowersAssignedToAffinityQuests / NomadFollowersAssignedToQuests);
        float Aq = 0;
        //Total happiness achieved via quest assignements
        if (NomadFollowersAssignedToQuests == 0)
        {
            Aq = 0;
        }
        else if(NomadFollowersAssignedToQuests > 0)
        { 
        Aq = MaxQuestAq + ((PercentOfNomadAffinityQuests) * MaxQuestAq * QuestAffinityBoost);
        }

        NomadAssignments = ((Ab + Aq)/10) - IdleIsBad; //IdleIsBad is the reduction in Nomad assignment part of HI due to idle followers

    }



    static void SetNomadPrestige()
    {
        float TotalP = 5;
        float TotalPrestige = 100;
        float CurrentPrestige = QuestManager.GetComponent<QuestsDiplomacyManager>().Prestige_Nomads;

        float PrestigeReduction = (TotalPrestige - CurrentPrestige) / TotalPrestige;

        if(CurrentPrestige == 0)
        {
            NomadPrestige = 0;
        }
        else if(CurrentPrestige >0)
        { 
        NomadPrestige = (TotalP - ((PrestigeReduction) * TotalP)) / 10;
        }
    }

    public static void RecalculateNomadHappinessIndex()
    {

        if (PlayerHasAFollowing == true)
        {
            SetAssignmentFactor();
            SetNomadPrestige();
            SetNomadHappiness();
        }

    }

    IEnumerator IdleFollower()
    {
        float TotalNomadFollowers = 0f;

        foreach (var o in NPCSystem.followers)
        {
            if (o.Type == "N")
            {
                TotalNomadFollowers++;
            }
        }

        float TotalNomadFollowersAssigned = 0f;

        foreach (var o in NPCSystem.followers)
        {
            if (o.Status != "idle")
            {
                TotalNomadFollowersAssigned++;
            }
        }

        while (TotalNomadFollowersAssigned < TotalNomadFollowers)
        {
            RecalculateNomadHappinessIndex();
            float TotalNomadFollowersIdle = TotalNomadFollowers - TotalNomadFollowersAssigned;
            IdlePenalty = (TotalNomadFollowersIdle / TotalNomadFollowers) * 0.05f;
            IdleIsBad = IdleIsBad + IdlePenalty;
            yield return new WaitForSeconds(3f);
        }
        while (TotalNomadFollowersAssigned == TotalNomadFollowers)
        {
            IdleIsBad = 0f;
            yield return new WaitForSeconds(3f);
        }
    }


    // Update is called once per frame
    void Update()
    {
        float TotalFollowers = NPCSystem.followers.Count;

        float TotalNomadFollowers = 0f;

        foreach (var o in NPCSystem.followers)
        {
            if (o.Type == "N")
            {
                TotalNomadFollowers++;
            }
        }

        if (TotalFollowers > 0 && TotalNomadFollowers > 0)
        {
            PlayerHasAFollowing = true;
            ActiveHIUI.SetActive(true);
            InactiveHIUI.SetActive(false);
        }
        else if (TotalFollowers == 0 && TotalNomadFollowers == 0)
        {
            PlayerHasAFollowing = false;
            ActiveHIUI.SetActive(false);
            InactiveHIUI.SetActive(true);
        }

    }
}
