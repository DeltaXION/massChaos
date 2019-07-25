using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestList : MonoBehaviour
{
    
    public int Questnumber;
    public string QuestText, AdditionalQuestText, QuestRewardsText, ListofRewards;

    public GameObject FollowerSlotActive;
    public string NpcRace;

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

    //TO SELECT FOLLOWER TO CHECK QUEST ON. ACTIVATES WHENEVER THE FOLLOWER SLOT WITH AN IDLE FOLLOWER IS SELECTED. THIS IS THEN USED TO SET AND COMPARE THE CONDITIONS OF THE QUEST
    public void PickFollower(GameObject Follower)
    {
        FollowerSlotActive = Follower;
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

        return QuestRewardsText;
    }

    public string RewardsList()
    {
        string ListofRewards;

        ListofRewards = "aa";
        return ListofRewards;
    }

    public void SubmitQuestRewards()
    {
        GameObject.Find("QuestsDiplomacyManager").GetComponent<QuestsDiplomacyManager>().UpdateRewardsintoPool(Prestige_Nomads, Prestige_Ferrarium, Prestige_Froots, Prestige_Mimax,
                                                                                                                LootReward_Iron, LootReward_Wood, LootReward_Food, LootReward_Gold,
                                                                                                                ItemReward_Uncommon, ItemReward_Common, ItemReward_Rare,
                                                                                                                ItemReward_Recipe, ItemReward_Boss, Reward_TimeChange);
    }



  




    //NOMAD_QUESTS (1-15) FERRARUIM_QUESTS (16-30) FROOTS_QUESTS (31-45) MIMAX_QUESTS (46-60)
    public void SelectQuest(int NodeQuestNumber)
    {
        
        Questnumber = NodeQuestNumber;
        GameObject.Find("DBManager").GetComponent<dbManager>().GetQuest(NodeQuestNumber);
        //Debug.Log("dog days are overrrrr");

        AssignQuestValues();
        //UpdateQuestValues(Questnumber);
        dbManager.quests.Clear();
    }

    void AssignQuestValues()
    {
        List<Quest> dbQuests = dbManager.quests;
        foreach (Quest quest in dbQuests)
        {
            Questnumber = quest.Questnumber;
            QuestText = quest.QuestText;
            AdditionalQuestText = quest.AdditionalQuestText;
            QuestRewardsText = quest.QuestRewardsText;
            ListofRewards = quest.ListofRewards;
            Prestige_Nomads = quest.Prestige_Nomads;
            Prestige_Ferrarium = quest.Prestige_Ferrarium;
            Prestige_Froots = quest.Prestige_Froots;
            Prestige_Mimax = quest.Prestige_Mimax;
            LootReward_Iron = quest.LootReward_Iron;
            LootReward_Wood = quest.LootReward_Wood;
            LootReward_Food = quest.LootReward_Food;
            LootReward_Gold = quest.LootReward_Gold;
            ItemReward_Uncommon = quest.LootReward_Gold;
            ItemReward_Common = quest.ItemReward_Common;
            ItemReward_Rare = quest.ItemReward_Rare;
            ItemReward_Recipe = quest.ItemReward_Recipe;
            ItemReward_Boss = quest.ItemReward_Boss;
            Quest_Time = quest.Quest_Time;
            Reward_TimeChange = quest.Reward_TimeChange;
        }
    }

    void UpdateQuestValues(int Quest_id)
    {
        NpcRace = FollowerSlotActive.GetComponent<FollowerSlot>().FollowerRace;
        List<Quest> dbQuests = dbManager.quests;
        foreach (Quest quest in dbQuests)
        {
            if (1 >= quest.Questnumber && quest.Questnumber <= 6 )
            {
                if (NpcRace == "Nomads")
                {
                    dbManager.quests.Clear();
                    GameObject.Find("DBManager").GetComponent<dbManager>().UpdateQuest(Quest_id, NpcRace);
                }
            }
            else if (16 >= quest.Questnumber && quest.Questnumber <= 21)
            {
                if (NpcRace == "Ferrarium")
                {
                    dbManager.quests.Clear();
                    GameObject.Find("DBManager").GetComponent<dbManager>().UpdateQuest(Quest_id, NpcRace);
                }
            }
        }
    }
}
