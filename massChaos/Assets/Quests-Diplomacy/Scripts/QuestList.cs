using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestList : MonoBehaviour
{
    public int Questnumber;
    public string QuestText, AdditionalQuestText, QuestRewardsText;

    public GameObject NPCDataList;


    public int Prestige_Nomads, Prestige_Ferrarium, Prestige_Froots, Prestige_Mimax,
                LootReward_Iron, LootReward_Wood, LootReward_Food, LootReward_Gold,
                ItemReward_Uncommon, ItemReward_Common, ItemReward_Rare,
                ItemReward_Recipe, ItemReward_Boss;

    
    

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    //Function to Provide Quest Description to Menu
    public string FetchQuest(int QuestID)
    {
        SelectQuest(QuestID);
        QuestRewardsText = QuestText + "\n" + AdditionalQuestText + "\n\n";

        int[] RewardsArray = {Prestige_Nomads, Prestige_Ferrarium, Prestige_Froots, Prestige_Mimax,
                                LootReward_Iron, LootReward_Wood, LootReward_Food, LootReward_Gold,
                                ItemReward_Uncommon, ItemReward_Common, ItemReward_Rare,
                                ItemReward_Recipe, ItemReward_Boss};

        string[] RewardsName = {" prestige from Nomads", " prestige from Ferrarium", " prestige from Froots", " prestige from Mimax",
                                " iron", " wood", " food", " gold",
                                " uncommon item", " common item", " rare item",
                                " recipe", " Boss Item"};
        
        for(int count = 0; count < RewardsArray.Length; count++)
        {            
            if(RewardsArray[count] != 0) //To make sure that only the relevant information is shown.

            QuestRewardsText = QuestRewardsText + RewardsArray[count].ToString() + " " + RewardsName[count].ToString() + "\n";            
        }

        Debug.Log(QuestText);
        Debug.Log(QuestRewardsText);

        return QuestRewardsText;
    }

    public string RewardsList()
    {
        string ListofRewards;

        ListofRewards = "aa";
        return ListofRewards;
    }



    




    //NOMAD_QUESTS (1-15) FERRARUIM_QUESTS (16-30) FROOTS_QUESTS (31-45) MIMAX_QUESTS (46-60)
    public void SelectQuest(int NodeQuestNumber)
    {
        Questnumber = NodeQuestNumber;

        Prestige_Nomads = Prestige_Ferrarium = Prestige_Froots = Prestige_Mimax = LootReward_Iron = LootReward_Wood = LootReward_Food = LootReward_Gold =
                ItemReward_Uncommon = ItemReward_Common = ItemReward_Rare = ItemReward_Recipe = ItemReward_Boss = 0; //Basically set everything to zero

        AdditionalQuestText = " "; //To reset Additional Questtext


        if (Questnumber == 1)
        {
            QuestText = "The Nomads are looking for a fighter to help them with a dungeon.";
            Prestige_Nomads = -100;
            Prestige_Ferrarium = 50;
            LootReward_Wood = 10;

            if(NPCDataList.GetComponent<TestNPCList>().Race == "Nomads")
            {
                AdditionalQuestText = "The Nomad valiantly springs forth from the crowd to answer the calling of his people";
                Debug.Log("He is a nomad");
            }
            
            
        }

        if (Questnumber == 2)
        {
            QuestText = "Iron is scarce and the Nomads can't quell evil and death without weapons of destruction. They're asking for an Engineer";
        }

        if (Questnumber == 3)
        {
            QuestText = "Deep in the mountainside are great deposits of iron. Help the Nomads claim this bounty.";
        }

        if (Questnumber == 4)
        {
            QuestText = "A curse has befallen a Nomad hut. They begrudgingly request assistance from a mage.";
        }

        if (Questnumber == 5)
        {
            QuestText = "Iron mining has reduced an entire forest to dirt. The Nomads are looking for help on the matter.";
        }

        if (Questnumber == 6)
        {
            QuestText = "This is the Quest you must read.";
        }
    }

    
}
