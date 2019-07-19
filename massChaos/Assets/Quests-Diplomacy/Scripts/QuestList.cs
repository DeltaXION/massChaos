using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestList : MonoBehaviour
{
    private int Questnumber;
    public string QuestText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SelectQuest()
    {
        if(Questnumber == 1)
        {
            QuestText = "This is the quest you must do.";
        }

        if(Questnumber == 2)
        {
            QuestText = "This is the Quest you must receive.";
        }

        if (Questnumber == 3)
        {
            QuestText = "This is the Quest you must read.";
        }
    }

    //Function to Provide Quest Description to Menu
    public string FetchQuest(int QuestID)
    {
        
        Questnumber = QuestID;
        SelectQuest();
        Debug.Log("The string to be returned is " + QuestText);
        
        return QuestText;
    }
}
