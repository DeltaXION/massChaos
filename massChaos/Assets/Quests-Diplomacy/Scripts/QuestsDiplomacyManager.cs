using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsDiplomacyManager : MonoBehaviour
{
    public int Prestige_Nomads = 0, Prestige_Ferrarium = 0, Prestige_Froots = 0, Prestige_Mimax = 0,
               QuestsCompleted_Nomads, QuestsCompleted_Ferrarium, QuestsCompleted_Froots, QuestsCompleted_Mimax;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if (Input.GetKeyDown("`"))
        {
            if (GameObject.Find("QuestsDiplomacyParent") == true)
                DiplomacyMap.SetActive(false);
            else if (GameObject.Find("QuestsDiplomacyParent") == false)
                DiplomacyMap.SetActive(true);
        }
=======
        
>>>>>>> parent of 77614da... Incomplete UI
    }
}
