using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class dbManager : MonoBehaviour
{
    private int QuestId;
    private bool RaceCheck;
    private string NpcRace;

    private string connectionString;
    private IDbConnection dbConnection;
    private IDbCommand dbCommand;
    private IDataReader dataReader;

    public GameObject FollowerSlotActive;

    public static List<Quest> quests = new List<Quest>();


    void Start()
    {
       
        //QuestId = QuestList;
        //NpcRace = FollowerSlotActive.GetComponent<FollowerSlot>().FollowerRace; //getting npc race
        connectionString = "URI=file:" + Application.dataPath + "/Questsdb.db"; 
        //GetQuest(QuestId);

        
        //Debug.Log(quests[0].Questnumber + "__&&__" + quests[0].QuestText);

        //AssignNpc(QuestId, 1);

        if (1 >= quests[0].Questnumber && quests[0].Questnumber <= 6)
        {
            UpdateQuest(quests[0].Questnumber, NpcRace);
        }
        else if (16 >= quests[0].Questnumber && quests[0].Questnumber <= 21)
        {
            UpdateQuest(quests[0].Questnumber, NpcRace);
        }
        Debug.Log(quests[0].Questnumber + "__&&__" + quests[0].QuestText);
        //InsertData(5, 2);
    }



    void Update()
    {

        
    }

    public void getQuestnumber(int quest_number)
    {
        QuestId = quest_number;
    }

    

    public void GetQuest(int Quest_Id)
    {

        using (dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            
            using (dbCommand = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("SELECT * FROM QuestList WHERE Questnumber = {0}; ", Quest_Id);
                dbCommand.CommandText = sqlQuery;

                using (dataReader = dbCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Quest q = new Quest();
                        Debug.Log("dog days are overrrrr");
                        Debug.Log(dataReader.GetString(1) + " _ " + dataReader.GetValue(3));
                        q.Questnumber = dataReader.GetInt16(0);
                        q.QuestText = dataReader.GetString(1);
                        q.AdditionalQuestText = dataReader.GetString(2);
                        q.QuestRewardsText = dataReader.GetString(3);
                        q.ListofRewards = dataReader.GetString(4);
                        q.Prestige_Nomads = dataReader.GetInt16(5);
                        q.Prestige_Nomads = dataReader.GetInt16(5);
                        q.Prestige_Froots = dataReader.GetInt16(6);
                        q.Prestige_Mimax = dataReader.GetInt16(7);
                        q.LootReward_Iron = dataReader.GetInt16(8);
                        q.LootReward_Wood = dataReader.GetInt16(9);
                        q.LootReward_Food = dataReader.GetInt16(10);
                        q.LootReward_Gold = dataReader.GetInt16(11);
                        q.ItemReward_Uncommon = dataReader.GetInt16(12);
                        q.ItemReward_Common = dataReader.GetInt16(13);
                        q.ItemReward_Rare = dataReader.GetInt16(14);
                        q.ItemReward_Recipe = dataReader.GetInt16(15);
                        q.ItemReward_Boss = dataReader.GetInt16(16);
                        q.Quest_Time = dataReader.GetInt16(17);
                        q.Reward_TimeChange = dataReader.GetInt16(18);
                        
                        quests.Add(q);
                    }
                    dbConnection.Close();
                    dataReader.Close();
                }
            }
        }
    }

    public void UpdateQuest(int Quest_Id ,string race)
    {
        using (dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (dbCommand = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("select * from If_"+race+"_Rewardslist where Questnumber = '{0}' ", Quest_Id);

                dbCommand.CommandText = sqlQuery;
                Debug.Log("dog days are overrrrr");


                using (dataReader = dbCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Quest q = new Quest();
                        //Debug.Log(dataReader.GetString(1) + " _ " + dataReader.GetValue(3));
                        q.Questnumber = dataReader.GetInt16(0);
                        q.QuestText = dataReader.GetString(1);
                        q.AdditionalQuestText = dataReader.GetString(2);
                        q.QuestRewardsText = dataReader.GetString(3);
                        q.ListofRewards = dataReader.GetString(4);
                        q.Prestige_Nomads = dataReader.GetInt16(5);
                        q.Prestige_Nomads = dataReader.GetInt16(5);
                        q.Prestige_Froots = dataReader.GetInt16(6);
                        q.Prestige_Mimax = dataReader.GetInt16(7);
                        q.LootReward_Iron = dataReader.GetInt16(8);
                        q.LootReward_Wood = dataReader.GetInt16(9);
                        q.LootReward_Food = dataReader.GetInt16(10);
                        q.LootReward_Gold = dataReader.GetInt16(11);
                        q.ItemReward_Uncommon = dataReader.GetInt16(12);
                        q.ItemReward_Common = dataReader.GetInt16(13);
                        q.ItemReward_Rare = dataReader.GetInt16(14);
                        q.ItemReward_Recipe = dataReader.GetInt16(15);
                        q.ItemReward_Boss = dataReader.GetInt16(16);
                        q.Quest_Time = dataReader.GetInt16(17);
                        q.Reward_TimeChange = dataReader.GetInt16(18);

                        quests.Add(q);
                    }
                    dbConnection.Close();
                    dataReader.Close();
                }
            }
        }
    }


    /*private void AssignNpc(int Quest_id, int Npc_id)
    {
        using (dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (dbCommand = dbConnection.CreateCommand())
            {

                //string delete_table = "delete from Npc_Check";

                string AssignNpcQuest = String.Format("update Quest_List set Npc_Id = '{0}' where Quest_id = {1};", Npc_id,Quest_id);
                
                //dbCommand.CommandText = delete_table;
                //dbCommand.ExecuteScalar();
                dbCommand.CommandText = AssignNpcQuest;
                dbCommand.ExecuteScalar();
                dbConnection.Close();



            }
        }

    }*/
}
