using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestsDiplomacyParent : MonoBehaviour
{
    public Text PrestigeNomads, PrestigeFerrarium, PrestigeFroots, PrestigeMimax;
    private GameObject QuestsDiplomacyManager;
    private string[] QuestNodes;
    

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
        PrestigeFroots.text = ("Froots Prestige : " + QuestsDiplomacyManager.GetComponent<QuestsDiplomacyManager>().Prestige_Froots.ToString());
        PrestigeMimax.text = ("Mimax Prestige : " + QuestsDiplomacyManager.GetComponent<QuestsDiplomacyManager>().Prestige_Mimax.ToString());
    }

    void SetQuest()
    {
<<<<<<< HEAD
        QuestNodes = GameObject.FindGameObjectsWithTag("QuestNode");
        //NumberofQuestNodes = QuestNodes.Length;

        foreach (GameObject item in QuestNodes)
        {
            GameObject.Find(item.name).GetComponent<QuestNodes>().QuestNumber = Random.Range(1, 3);
            Debug.Log("Node name is " + item.name + "and QuestNumber is " + GameObject.Find(item.name).GetComponent<QuestNodes>().QuestNumber);
        }
=======
        QuestNodes[0] = "what";
        QuestNodes[1] = "where";

        Debug.Log(QuestNodes[1]);
>>>>>>> parent of 77614da... Incomplete UI
    }
}
