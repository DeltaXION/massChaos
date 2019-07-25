using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestsDiplomacyParent : MonoBehaviour
{
    public Text PrestigeNomads, PrestigeFerrarium, PrestigeFroots, PrestigeMimax;
    private GameObject QuestsDiplomacyManager;
    private GameObject[] QuestNodes;

    public GameObject Node1, Node2, Node3, Node4, Node5, Node6, Node7, Node8;

    private int RandomNumberPulled;

    private float TimeCheckpoint = 0;
    

    void Start()
    {
        QuestsDiplomacyManager = GameObject.Find("QuestsDiplomacyManager");

        //Update data from the QuestDiplomacyManager(Prestige, Quests, WorldState) to the DiplomacyMap
        UpdateDiplomacyMap();

        //Select which Quest to select from a pool. Also resets the existing Quests.
        SetQuest();

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckNodeResetTimer();
        UpdateDiplomacyMap();
    }

    void CheckNodeResetTimer() //To check each time the timer crosses a certain threshold at which the map will change what quests are online except for the ones already active.
    {
        if(GameObject.Find("TimerBaar").GetComponent<Timer2>().calen - TimeCheckpoint >= 10)
        {
            SetQuest();
            TimeCheckpoint = GameObject.Find("TimerBaar").GetComponent<Timer2>().calen;
        }
    }

    void UpdateDiplomacyMap()
    {
        PrestigeNomads.text = ("Nomads Prestige : " + QuestsDiplomacyManager.GetComponent<QuestsDiplomacyManager>().Prestige_Nomads.ToString());
        PrestigeFerrarium.text = ("Ferrarium Prestige : " + QuestsDiplomacyManager.GetComponent<QuestsDiplomacyManager>().Prestige_Ferrarium.ToString());
        /*
        PrestigeFroots.text = ("Froots Prestige : " + QuestsDiplomacyManager.GetComponent<QuestsDiplomacyManager>().Prestige_Froots.ToString());
        PrestigeMimax.text = ("Mimax Prestige : " + QuestsDiplomacyManager.GetComponent<QuestsDiplomacyManager>().Prestige_Mimax.ToString());*/
    }


    void EnableorDisableQuests()
    {
        GameObject[] Nodes = { Node1, Node2, Node3, Node4, Node5, Node6, Node7, Node8};
        foreach(GameObject item in Nodes)
        {
            int RandomNumber = Random.Range(0, 2);
            if (RandomNumber == 0)
            {
                if(item.GetComponent<QuestNodes>().QuestisActive == false)
                item.SetActive(false);

            }
            else
                item.SetActive(true);
        }
    }


    void SetQuest()
    {
        EnableorDisableQuests();

        //NOMAD_QUESTS (1-15) FERRARUIM_QUESTS (16-30) FROOTS_QUESTS (31-45) MIMAX_QUESTS (46-60)
        SetQuestforRace("NomadQuestNode", 1, 6);
        SetQuestforRace("FerrariumQuestNode", 16, 21);
        /*
        SetQuestforRace("FrootsQuestNode", 31, 36);
        SetQuestforRace("MimaxQuestNode", 46, 51);
        */
    }

    void SetQuestforRace(string RaceName, int min, int max)
    {
        QuestNodes = GameObject.FindGameObjectsWithTag(RaceName);
        
        foreach (GameObject item in QuestNodes)
        {
        Repeat:
            RandomNumberPulled = Random.Range(min, max);

            foreach (GameObject node in QuestNodes)
            {
                if (node.GetComponent<QuestNodes>().QuestNumber == RandomNumberPulled)

                    goto Repeat;


            }
            item.GetComponent<QuestNodes>().QuestNumber = RandomNumberPulled;

        }
    }
}
