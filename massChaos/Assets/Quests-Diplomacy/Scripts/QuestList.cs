using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestList : MonoBehaviour
{
    public int Questnumber;
    public string QuestText, AdditionalQuestText, QuestRewardsText, ListofRewards, AddText;

    public GameObject FollowerSlotActive;


    public int Prestige_Nomads, Prestige_Ferrarium, Prestige_Froots, Prestige_Mimax,
                LootReward_Iron, LootReward_Wood, LootReward_Food, LootReward_Gold,
                ItemReward_Uncommon, ItemReward_Common, ItemReward_Rare,
                ItemReward_Recipe, ItemReward_Boss, Quest_Time, Reward_TimeChange;

    
    

    // Start is called before the first frame update
    void Start()
    {
        FollowerSlotActive = GameObject.Find("DummyFollowerSlot");        
    }

    private void Update()
    {
        
    }

   

    //Function to Provide Quest Description to Menu
    public string FetchQuest(int QuestID)
    {
         
        SelectQuest(QuestID);
        QuestRewardsText = QuestText + "\n" + AdditionalQuestText + "\n\n" + "This quest will take " + Quest_Time + " days." + "\n\n";
        ListofRewards = "QUEST COMPLETED \n";

        int[] RewardsArray = {Prestige_Nomads, Prestige_Ferrarium, Prestige_Froots, Prestige_Mimax,
                                LootReward_Iron, LootReward_Wood, LootReward_Food, LootReward_Gold,
                                ItemReward_Uncommon, ItemReward_Common, ItemReward_Rare,
                                ItemReward_Recipe, ItemReward_Boss, Reward_TimeChange};

        string[] RewardsName = {" prestige from Nomads", " prestige from Ferrarium", " prestige from Froots", " prestige from Mimax",
                                " iron", " wood", " food", " gold",
                                " uncommon item", " common item", " rare item",
                                " recipe", " Boss Item", "Change in time"};
        
        for(int count = 0; count < RewardsArray.Length; count++)
        {
            if (RewardsArray[count] != 0) //To make sure that only the relevant information is shown.
            {
                ListofRewards = ListofRewards + RewardsArray[count].ToString() + " " + RewardsName[count].ToString() + "\n";
                QuestRewardsText = QuestRewardsText + RewardsArray[count].ToString() + " " + RewardsName[count].ToString() + "\n";
            }
        }

        Debug.Log("Questrewards");
        return QuestRewardsText;
        
    }

    public string RewardsList()
    {
        string ListofRewards;

        ListofRewards = "aa";
        return ListofRewards;
    }

    //CALCULATE AND ADD OR SUBTRACT THE REWARDS. CALLED BY QUESTNODES
    public void SubmitQuestRewards()
    {
        GameObject.Find("QuestsDiplomacyManager").GetComponent<QuestsDiplomacyManager>().UpdateRewardsintoPool(Prestige_Nomads, Prestige_Ferrarium, Prestige_Froots, Prestige_Mimax,
                                                                                                                LootReward_Iron, LootReward_Wood, LootReward_Food, LootReward_Gold,
                                                                                                                ItemReward_Uncommon, ItemReward_Common, ItemReward_Rare,
                                                                                                                ItemReward_Recipe, ItemReward_Boss, Reward_TimeChange);
    }

    public void SetFollowerDetails()
    {
        int FollowerAddress = GameObject.Find("FollowerSlots").GetComponent<FollowerSlotsManager>().ActiveFollowerSlotID;
        FollowerSlotActive = GameObject.Find("FollowerSlots").GetComponent<FollowerSlotsManager>().FetchFollowerSlotDetails(FollowerAddress);
    }

    //NOMAD_QUESTS (1-15) FERRARUIM_QUESTS (16-30) FROOTS_QUESTS (31-45) MIMAX_QUESTS (46-60)
    public void SelectQuest(int NodeQuestNumber)
    {
        Questnumber = NodeQuestNumber;

        Prestige_Nomads = Prestige_Ferrarium = Prestige_Froots = Prestige_Mimax = LootReward_Iron = LootReward_Wood = LootReward_Food = LootReward_Gold =
                ItemReward_Uncommon = ItemReward_Common = ItemReward_Rare = ItemReward_Recipe = ItemReward_Boss = Reward_TimeChange = Quest_Time = 0; //Basically set everything to zero

        AdditionalQuestText = ""; //To reset Additional Questtext
        AddText = "";


        //NOMAD...NOMAD...NOMAD...NOMAD...NOMAD...NOMAD...NOMAD...NOMAD...NOMAD...NOMAD...NOMAD...NOMAD...NOMAD...NOMAD...NOMAD...NOMAD...NOMAD...NOMAD...NOMAD...
        if (Questnumber == 1)
        {

            QuestText = "The Nomads are looking for a fighter to help them with a dungeon.";

            Prestige_Nomads = 5;
            Quest_Time = 4;
            
            
            if(FollowerSlotActive.name != "DummyFollowerSlot" && FollowerSlotActive.GetComponent<FollowerSlot>().FollowerRace == "Nomad")
            {
                
                AddText = "The Nomad valiantly springs forth from the crowd to answer the call of Cleansing. \n";
                Prestige_Nomads += 2;
                Quest_Time -= 1;
                LootReward_Wood += 10;

                AdditionalQuestText += AddText;
            }

            if (FollowerSlotActive.name != "DummyFollowerSlot" && FollowerSlotActive.GetComponent<FollowerSlot>().FollowerClass == "warrior")
            {

                AddText = "A warrior honed in the way of the blade, the follower is sure to be well respected for the deed. \n";
                Prestige_Nomads += 4;
                Quest_Time -= 1;
                LootReward_Gold += 20;

                AdditionalQuestText += AddText;
            }

            if (FollowerSlotActive.name != "DummyFollowerSlot" && FollowerSlotActive.GetComponent<FollowerSlot>().FollowerClass == "maige")
            {

                AddText = "However, the Nomads' disdain for magic would hurt ties with them. Your follower however finds a stash sealed in magic. \n";
                Prestige_Nomads -= 4;
                LootReward_Gold += 50;

                AdditionalQuestText += AddText;
            }

        }

        if (Questnumber == 2)
        {
            QuestText = "Iron is scarce and the Nomads can't quell evil and death without weapons of destruction. They're asking for assistance in mining.";
            Prestige_Nomads = 5;
            Quest_Time = 4;
            LootReward_Iron = 5;


            if (FollowerSlotActive.name != "DummyFollowerSlot" && FollowerSlotActive.GetComponent<FollowerSlot>().FollowerRace == "Ferrarium")
            {
                AddText = "The skilled and crafty amalgamation of iron and flesh is well experienced on how to sap the earth of its riches. \n";
                Prestige_Nomads += 2;
                Quest_Time -= 2;
                LootReward_Iron += 10;

                AdditionalQuestText += AddText;
            }

            if (FollowerSlotActive.name != "DummyFollowerSlot" && FollowerSlotActive.GetComponent<FollowerSlot>().FollowerClass == "maige")
            {
                AddText = "Alchemy is frowned upon greatly by the Nomads but what can a mage do upon uncovering a hidden Alchemy Circle. \n";
                Prestige_Nomads -= 3;
                LootReward_Iron -= 5;
                LootReward_Gold += 10;

                AdditionalQuestText += AddText;
            }
        }

        if (Questnumber == 3)
        {
            QuestText = "Deep in the mountainside are great deposits of iron. Help the Nomads claim this bounty.";
            Prestige_Nomads = 2;

            Quest_Time = 4;
            LootReward_Iron = 10;

            if (FollowerSlotActive.name != "DummyFollowerSlot" && FollowerSlotActive.GetComponent<FollowerSlot>().FollowerRace == "Ferrarium")
            {
                AddText = "The skilled and crafty amalgamation of iron and flesh is well experienced on how to sap the earth of its riches. \n";
                Prestige_Nomads += 2;
                Quest_Time -= 2;
                LootReward_Iron += 10;

                AdditionalQuestText += AddText;
            }
        }

        if (Questnumber == 4)
        {
            QuestText = "A curse has befallen a Nomad hut. They begrudgingly request assistance from a mage.";
            
            Quest_Time = 4;
            LootReward_Gold = 5;

            if (FollowerSlotActive.name != "DummyFollowerSlot" && FollowerSlotActive.GetComponent<FollowerSlot>().FollowerClass == "maige")
            {
                AddText = "The incantations chanted aloud by your follower send children scurrying and peeking from meek corners out of fear; not of the unknown or harm but rather that invoked by indoctrination.";
                Prestige_Nomads -= 2;
                LootReward_Gold += 45;

                AdditionalQuestText += AddText;
            }
        }

        if (Questnumber == 5)
        {
            QuestText = "Iron mining has reduced an entire forest to dirt. The Nomads are looking for help on the matter.";
            Prestige_Nomads = 5;

            Quest_Time = 15;
            LootReward_Gold = 10;

            if (FollowerSlotActive.name != "DummyFollowerSlot" && FollowerSlotActive.GetComponent<FollowerSlot>().FollowerRace == "Froots")
            {
                AddText = "Healing takes time and more so when it is the earth in pain. But a Froot also knows how to soothe any ailing thing. \n";
                Prestige_Nomads += 10;
                Quest_Time -= 4;
                LootReward_Gold += 50;

                AdditionalQuestText += AddText;
            }
        }

        if (Questnumber == 6)
        {
            QuestText = "This is the Quest you must read.";
            Prestige_Nomads = 5;

            Quest_Time = 4;
            LootReward_Iron = 10;
        }




        //FERRARIUM...FERRARIUM...FERRARIUM...FERRARIUM...FERRARIUM...FERRARIUM...FERRARIUM...FERRARIUM...FERRARIUM...FERRARIUM...FERRARIUM...FERRARIUM...FERRARIUM...FERRARIUM...
        if (Questnumber == 16)
        {
            QuestText = "This is the Quest you must read.";
            Prestige_Ferrarium = 5;

            Quest_Time = 4;
            LootReward_Wood = 10;
        }
        if (Questnumber == 17)
        {
            QuestText = "This is the Quest you must read.";
            Prestige_Ferrarium = 5;

            Quest_Time = 4;
            LootReward_Gold = 10;
        }
        if (Questnumber == 18)
        {
            QuestText = "This is the Quest you must read.";
            Prestige_Ferrarium = 5;

            Quest_Time = 4;
            LootReward_Gold = 10;
        }
        if (Questnumber == 19)
        {
            QuestText = "This is the Quest you must read.";
            Prestige_Ferrarium = 5;

            Quest_Time = 4;
            LootReward_Gold = 10;
        }
        if (Questnumber == 20)
        {
            QuestText = "This is the Quest you must read.";
            Prestige_Ferrarium = 5;

            Quest_Time = 4;
            LootReward_Wood = 10;
        }
        if (Questnumber == 21)
        {
            QuestText = "This is the Quest you must read.";
            Prestige_Ferrarium = 5;

            Quest_Time = 4;
            LootReward_Gold = 10;
        }


        //FROOTS...FROOTS...FROOTS...FROOTS...FROOTS...FROOTS...FROOTS...FROOTS...FROOTS...FROOTS...FROOTS...FROOTS...FROOTS...FROOTS...
        if (Questnumber == 31)
        {
            QuestText = "This is the FROOTS Quest you must read.";
            Prestige_Froots = 5;

            Quest_Time = 4;
            LootReward_Wood = 10;
        }
        if (Questnumber == 32)
        {
            QuestText = "This is the FROOTS Quest you must read.";
            Prestige_Froots = 5;

            Quest_Time = 4;
            LootReward_Gold = 10;
        }
        if (Questnumber == 33)
        {
            QuestText = "This is the FROOTS Quest you must read.";
            Prestige_Froots = 5;

            Quest_Time = 4;
            LootReward_Gold = 10;
        }
        if (Questnumber == 34)
        {
            QuestText = "This is the FROOTS Quest you must read.";
            Prestige_Froots = 5;

            Quest_Time = 4;
            LootReward_Gold = 10;
        }
        if (Questnumber == 35)
        {
            QuestText = "This is the FROOTS Quest you must read.";
            Prestige_Froots = 5;

            Quest_Time = 4;
            LootReward_Wood = 10;
        }
        if (Questnumber == 36)
        {
            QuestText = "This is the FROOTS Quest you must read.";
            Prestige_Froots = 5;

            Quest_Time = 4;
            LootReward_Gold = 10;
        }


        //MIMAX...MIMAX...MIMAX...MIMAX...MIMAX...MIMAX...MIMAX...MIMAX...MIMAX...MIMAX...MIMAX...MIMAX...MIMAX...MIMAX...
        if (Questnumber == 46)
        {
            QuestText = "This is the FROOTS Quest you must read.";
            Prestige_Mimax = 5;

            Quest_Time = 4;
            LootReward_Wood = 10;
        }
        if (Questnumber == 47)
        {
            QuestText = "This is the FROOTS Quest you must read.";
            Prestige_Mimax = 5;

            Quest_Time = 4;
            LootReward_Gold = 10;
        }
        if (Questnumber == 48)
        {
            QuestText = "This is the FROOTS Quest you must read.";
            Prestige_Mimax = 5;

            Quest_Time = 4;
            LootReward_Gold = 10;
        }
        if (Questnumber == 49)
        {
            QuestText = "This is the FROOTS Quest you must read.";
            Prestige_Mimax = 5;

            Quest_Time = 4;
            LootReward_Gold = 10;
        }
        if (Questnumber == 50)
        {
            QuestText = "This is the FROOTS Quest you must read.";
            Prestige_Mimax = 5;

            Quest_Time = 4;
            LootReward_Wood = 10;
        }
        if (Questnumber == 51)
        {
            QuestText = "This is the FROOTS Quest you must read.";
            Prestige_Mimax = 5;

            Quest_Time = 4;
            LootReward_Gold = 10;
        }
    }

    
}
