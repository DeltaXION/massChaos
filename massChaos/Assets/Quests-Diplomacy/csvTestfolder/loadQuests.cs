using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadQuests : MonoBehaviour
{
    List<Quest> quests = new List<Quest>();

    // Start is called before the first frame update
    void Start()
    {

        TextAsset questdata = Resources.Load<TextAsset>("questData");

        string[] data = questdata.text.Split(new char[] { '\n' });
        Debug.Log(data.Length);

        for (int i = 1; i < data.Length - 1; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });

            Quest q = new Quest();
            int.TryParse(row[0], out q.Quest_id);
            q.Quest_type = row[1];
            q.Quest_name = row[2];
            q.Quest_discription = row[3];
            int.TryParse(row[4], out q.Prestige_Nomads);
            int.TryParse(row[5], out q.Prestige_Ferrarium);
            int.TryParse(row[6], out q.Prestige_Froots);
            int.TryParse(row[7], out q.Prestige_Mimax);
            int.TryParse(row[8], out q.Common_item);
            int.TryParse(row[9], out q.Uncommon_item);
            int.TryParse(row[10], out q.Rare_item);
            int.TryParse(row[11], out q.Wood);
            int.TryParse(row[12], out q.Iron);
            int.TryParse(row[13], out q.Gold);
            int.TryParse(row[14], out q.Food);
            int.TryParse(row[15], out q.Boss_item_ID);
            int.TryParse(row[16], out q.Recipe_item_ID);
            int.TryParse(row[17], out q.Quest_time);
            int.TryParse(row[18], out q.Reward_timequest);

            quests.Add(q);
        }

        foreach(Quest q in quests)
        {
            Debug.Log(q.Quest_name);
            Debug.Log(q.Quest_time);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
