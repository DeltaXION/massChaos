using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowerSlot : MonoBehaviour
{
    public int FollowerSlotNumber;
    public GameObject QuestRewardsInfo, FollowerSlotInfo, TestNPCList;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(SelectedSlot); //Button starts function that gives SlotNumber to NPC List for reference
        FillSlots();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SelectedSlot()
    {

        foreach (GameObject item in GameObject.FindGameObjectsWithTag("NomadQuestNode"))
        {
            if (item.GetComponent<QuestNodes>().QuestisActive == true && item.GetComponent<QuestNodes>().IDofFollowerdoingQuest == FollowerSlotNumber)
            {
                item.GetComponent<QuestNodes>().PopUpFollowerIsAlreadyonQuest();
                return;
            }
        }

        foreach (GameObject item in GameObject.FindGameObjectsWithTag("FerrariumQuestNode"))
        {
            if (item.GetComponent<QuestNodes>().QuestisActive == true && item.GetComponent<QuestNodes>().IDofFollowerdoingQuest == FollowerSlotNumber)
            {
                item.GetComponent<QuestNodes>().PopUpFollowerIsAlreadyonQuest();
                return;
            }
        }


        TestNPCList.GetComponent<TestNPCList>().FollowerSlotisSelected(FollowerSlotNumber); //Function sends FollowerSlotNumber variable to NPC List 
        ShowQuest();
        
        
    }

    public void ShowQuest()
    {   
        QuestRewardsInfo.GetComponent<Text>().text = GameObject.Find("QuestList").GetComponent<QuestList>().FetchQuest(GameObject.Find("QuestList").GetComponent<QuestList>().Questnumber);
    }

    void FillSlots()
    {
        
        TestNPCList.GetComponent<TestNPCList>().FetchFollower(FollowerSlotNumber);

        FollowerSlotInfo.GetComponent<Text>().text = TestNPCList.GetComponent<TestNPCList>().FollowerName +"\n"+ TestNPCList.GetComponent<TestNPCList>().Race + " " + TestNPCList.GetComponent<TestNPCList>().Class + "\n" + TestNPCList.GetComponent<TestNPCList>().SecondaryItem;

        TestNPCList.GetComponent<TestNPCList>().FollowerIDnumber = 0; //To check if this is the one turning the ID to 3 everytime the QuestDetails Load.

    }
}
