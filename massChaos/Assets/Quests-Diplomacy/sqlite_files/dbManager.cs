using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class dbManager : MonoBehaviour
{
    public int QuestId;

    private string connectionString;
    private IDbConnection dbConnection;
    private IDbCommand dbCommand;
    private IDataReader dataReader;


    List<Quest> quests = new List<Quest>();


    void Start()
    {
        quests.Clear();
        connectionString = "URI=file:" + Application.dataPath + "/QuestsDatabase.db";
        GetData(7);
        Debug.Log(quests[0].Quest_id +"__&&__"+quests[0].Quest_discription);
        //Debug.Log(quests[1].Quest_id + "__&&__" + quests[1].Quest_discription);

        //InsertData(3, 4);
        //InsertData(5, 2);
    }



    void Update()
    {
        
    }

    private void GetData(int QuestId)
    {
        using (dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (dbCommand = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format( "SELECT * FROM Quest_List WHERE Quest_id = {0}; ",QuestId);

                dbCommand.CommandText = sqlQuery;

                using (dataReader = dbCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Quest q = new Quest();
                        //Debug.Log(dataReader.GetString(1) + " _ " + dataReader.GetValue(3));
                        q.Quest_id = dataReader.GetInt16(0);
                        q.Quest_type = dataReader.GetString(1);
                        q.Quest_name = dataReader.GetString(2);
                        q.Quest_discription = dataReader.GetString(3);
                        q.Prestige_Nomads = dataReader.GetInt16(4);
                        q.Prestige_Ferrarium = dataReader.GetInt16(5);
                        q.Prestige_Froots = dataReader.GetInt16(6);
                        q.Prestige_Mimax = dataReader.GetInt16(7);
                        q.Common_item = dataReader.GetInt16(8);
                        q.Uncommon_item = dataReader.GetInt16(9);
                        q.Rare_item = dataReader.GetInt16(10);
                        q.Wood = dataReader.GetInt16(11);
                        q.Iron = dataReader.GetInt16(12);
                        q.Gold = dataReader.GetInt16(13);
                        q.Food = dataReader.GetInt16(14);
                        q.Boss_item_ID = dataReader.GetInt16(15);
                        q.Recipe_item_ID = dataReader.GetInt16(16);
                        q.Quest_time = dataReader.GetInt16(17);
                        q.Reward_timequest = dataReader.GetInt16(18);

                        quests.Add(q);
                    }
                    dbConnection.Close();
                    dataReader.Close();
                }
            }
        }
    }


    private void InsertData(int Quest_id, int Npc_id)
    {
        using (dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (dbCommand = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format( "INSERT INTO Npc_Check (Quest_id, Npc_id) VALUES('{0}', '{1}'); ",Quest_id,Npc_id);

                dbCommand.CommandText = sqlQuery;
                dbCommand.ExecuteScalar();
                dbConnection.Close();

                
            }
        }

    }
}
