using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestsDiplomacyParent : MonoBehaviour
{
    public Text PrestigeNomads, PrestigeFerrarium, PrestigeFroots, PrestigeMimax;
    private GameObject QuestsDiplomacyManager;
    private GameObject[] QuestNodes;

    private int RandomNumberPulled;
    

    void Start()
    {
        QuestsDiplomacyManager = GameObject.Find("QuestsDiplomacyManager");

        //Update data from the QuestDiplomacyManager(Prestige, Quests, WorldState) to the DiplomacyMap
        UpdateDiplomacyMap();

        //Select which Quest to select from a pool
        SetQuest();

        
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    void UpdateDiplomacyMap()
    {
        PrestigeNomads.text = ("Nomads Prestige : " + QuestsDiplomacyManager.GetComponent<QuestsDiplomacyManager>().Prestige_Nomads.ToString());
        PrestigeFerrarium.text = ("Ferrarium Prestige : " + QuestsDiplomacyManager.GetComponent<QuestsDiplomacyManager>().Prestige_Ferrarium.ToString());
        /*
        PrestigeFroots.text = ("Froots Prestige : " + QuestsDiplomacyManager.GetComponent<QuestsDiplomacyManager>().Prestige_Froots.ToString());
        PrestigeMimax.text = ("Mimax Prestige : " + QuestsDiplomacyManager.GetComponent<QuestsDiplomacyManager>().Prestige_Mimax.ToString());*/
    }


    void SetQuest()
    {
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
        //NumberofQuestNodes = QuestNodes.Length;

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
