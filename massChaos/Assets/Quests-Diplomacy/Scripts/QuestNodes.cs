using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestNodes : MonoBehaviour
{
    public int QuestNumber, IDofFollowerdoingQuest, NodeNumber; //NodeNumberisUniqueIdentifier
    public string QuestInformation;
    public bool QuestisActive = false;

    public GameObject QuestMenu, QuestRewardsInfo, SendFollowertoQuest, PopupNotification;
    //public Text QuestRewardsInfo;


    private void Start()
    {
        
        GameObject.Find("TestNPCList").GetComponent<TestNPCList>().FollowerIDnumber = 0;
        gameObject.GetComponent<Button>().onClick.AddListener(ShowQuest);
        PopupNotification.GetComponent<Button>().onClick.AddListener(KillPopup);
        SendFollowertoQuest.GetComponent<Button>().onClick.AddListener(SendFollower);
       
    }

    public void ShowQuest()
    {
        if (QuestisActive == false)
        {


            GameObject.Find("TestNPCList").GetComponent<TestNPCList>().FetchFollower(0); //To reset the NPC List
            if (GameObject.Find("QuestMenu") == false)
                QuestMenu.SetActive(true);
            
            QuestRewardsInfo.GetComponent<Text>().text = GameObject.Find("QuestList").GetComponent<QuestList>().FetchQuest(QuestNumber);
        }

        if (QuestisActive == true)
        PopUpQuestisCurrentlyBeingFulfilled();
    }

    void SendFollower()
    {
        if(GameObject.Find("TestNPCList").GetComponent<TestNPCList>().FollowerIDnumber == 0)
        PopUpNoFollowerSelected();

        else if (QuestisActive == false && QuestNumber == GameObject.Find("QuestList").GetComponent<QuestList>().Questnumber)
        {
            //Debug.Log(GameObject.Find("TestNPCList").GetComponent<TestNPCList>().FollowerName + " is going to embark on QuestID " + GameObject.Find("QuestList").GetComponent<QuestList>().Questnumber);
            IDofFollowerdoingQuest = GameObject.Find("TestNPCList").GetComponent<TestNPCList>().FollowerIDnumber;
            QuestisActive = true;
            QuestMenu.SetActive(false);
        }
    }





    //POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS

    void PopUpQuestisCurrentlyBeingFulfilled()
    {
        GameObject.Find("QuestList").GetComponent<QuestList>().FetchQuest(QuestNumber);
        GameObject.Find("TestNPCList").GetComponent<TestNPCList>().FetchFollower(IDofFollowerdoingQuest);
        PopupNotification.SetActive(true);
        GameObject.Find("PopupText").GetComponent<Text>().text = "The Quest is currently being fulfilled by " + GameObject.Find("TestNPCList").GetComponent<TestNPCList>().Race + " " + GameObject.Find("TestNPCList").GetComponent<TestNPCList>().Class + " " + GameObject.Find("TestNPCList").GetComponent<TestNPCList>().FollowerName;
    }

    public void PopUpFollowerIsAlreadyonQuest()
    {
        PopupNotification.SetActive(true);
        GameObject.Find("PopupText").GetComponent<Text>().text = "FollowerIsAlreadyDoingQuest";
        GameObject.Find("TestNPCList").GetComponent<TestNPCList>().FollowerIDnumber = 0;
    }

    void PopUpNoFollowerSelected()
    {
        PopupNotification.SetActive(true);
        GameObject.Find("PopupText").GetComponent<Text>().text = "No follower selected";
    }

    void KillPopup()
    {
        PopupNotification.SetActive(false);
    }
}
