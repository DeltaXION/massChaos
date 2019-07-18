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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectQuest()
    {
        if(Questnumber == 1)
        {
            QuestText.text = "This is the quest you must do.";
        }
    }
}
