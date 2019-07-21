using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsDiplomacyManager : MonoBehaviour
{
    public int Prestige_Nomads = 0, Prestige_Ferrarium = 0, Prestige_Froots = 0, Prestige_Mimax = 0,
               QuestsCompleted_Nomads, QuestsCompleted_Ferrarium, QuestsCompleted_Froots, QuestsCompleted_Mimax,
               FollowersCurrentlyQuesting, FollowersCurrentlyQuestingatHome,
               NomadsCurrentlyQuesting, FerrariumCurrentlyQuesting, FrootsCurrentlyQuesting, MimaxCurrentlyQuesting,
               NomadsQuestingatHome, FerrariumQuestingatHome, FrootsQuestingatHome, MimaxQuestingatHome;

    public GameObject DiplomacyMap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("`"))
        {
            if (GameObject.Find("QuestMenu") == true)
                GameObject.Find("QuestMenu").SetActive(false);

                if (GameObject.Find("QuestsDiplomacyParent") == true)
                DiplomacyMap.SetActive(false);
            else if (GameObject.Find("QuestsDiplomacyParent") == false)
                DiplomacyMap.SetActive(true);
        }

        if (Input.GetKeyDown("w"))
        {
            GetDataonQuestingFollowers();
            
        }

    }

    public void GetDataonQuestingFollowers()
    {
        FollowersCurrentlyQuesting = NomadsCurrentlyQuesting = FerrariumCurrentlyQuesting = FrootsCurrentlyQuesting = MimaxCurrentlyQuesting =
               NomadsQuestingatHome = FerrariumQuestingatHome = FrootsQuestingatHome = MimaxQuestingatHome = 0;                                     //Reset all values because everything builds up here on ++


        FindWorkingFollowers("NomadQuestNode", "Nomad");
        FindWorkingFollowers("FerrariumQuestNode", "Ferrarium");
        FindWorkingFollowers("FrootsQuestNode", "Froots");
        FindWorkingFollowers("MimaxQuestNode", "Mimax");

        Debug.Log("Followers currently questing = " + FollowersCurrentlyQuesting);

        Debug.Log("Nomads currently questing = " + NomadsCurrentlyQuesting);
        Debug.Log("Ferrarium currently questing = " + FerrariumCurrentlyQuesting);
        Debug.Log("Froots currently questing = " + FrootsCurrentlyQuesting);
        Debug.Log("Mimax currently questing = " + MimaxCurrentlyQuesting);

        Debug.Log("Nomads currently questing at home = " + NomadsQuestingatHome);
        Debug.Log("Ferrarium currently questing at home = " + FerrariumQuestingatHome);
        Debug.Log("Froots currently questing at home = " + FrootsQuestingatHome);
        Debug.Log("Mimax currently questing at home = " + MimaxQuestingatHome);

        Debug.Log("Followers currently questing at home = " + FollowersCurrentlyQuestingatHome);
    }

    void FindWorkingFollowers(string NodeType, string HomeRace)
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag(NodeType))
        {
            if (item.GetComponent<QuestNodes>().QuestisActive == true)
            {
                FollowersCurrentlyQuesting++;

                int FollowerID = item.GetComponent<QuestNodes>().IDofFollowerdoingQuest;
                GameObject.Find("TestNPCList").GetComponent<TestNPCList>().FetchFollower(FollowerID);

                if (GameObject.Find("TestNPCList").GetComponent<TestNPCList>().Race == "Nomad")
                    NomadsCurrentlyQuesting++;
                if (GameObject.Find("TestNPCList").GetComponent<TestNPCList>().Race == "Ferrarium")
                    FerrariumCurrentlyQuesting++;
                if (GameObject.Find("TestNPCList").GetComponent<TestNPCList>().Race == "Froots")
                    FrootsCurrentlyQuesting++;
                if (GameObject.Find("TestNPCList").GetComponent<TestNPCList>().Race == "Mimax")
                    MimaxCurrentlyQuesting++;

                if (GameObject.Find("TestNPCList").GetComponent<TestNPCList>().Race == HomeRace)
                {
                    FollowersCurrentlyQuestingatHome++;

                    if (GameObject.Find("TestNPCList").GetComponent<TestNPCList>().Race == "Nomad")
                        NomadsQuestingatHome++;
                    if (GameObject.Find("TestNPCList").GetComponent<TestNPCList>().Race == "Ferrarium")
                        FerrariumQuestingatHome++;
                    if (GameObject.Find("TestNPCList").GetComponent<TestNPCList>().Race == "Froots")
                        FrootsQuestingatHome++;
                    if (GameObject.Find("TestNPCList").GetComponent<TestNPCList>().Race == "Mimax")
                        MimaxQuestingatHome++;
                }

                GameObject.Find("TestNPCList").GetComponent<TestNPCList>().FetchFollower(0);
            }
        }
    }
}
