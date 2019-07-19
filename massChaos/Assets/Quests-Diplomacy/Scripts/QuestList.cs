using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestList : MonoBehaviour
{
    private int Questnumber;
    public Text QuestText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SelectQuest()
    {
        if(Questnumber == 1)
        {
            QuestText.text = "This is the quest you must do.";
        }

        if(Questnumber == 2)
        {
            QuestText.text = "This is the Quest you must receive.";
        }

        if (Questnumber == 3)
        {
            QuestText.text = "This is the Quest you must read.";
        }
    }

    //Function to Provide Quest Description to Menu
    public string FetchQuest(int QuestID)
    {
        Questnumber = QuestID;
        return QuestText.text;
    }
}
