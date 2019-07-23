using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestNodes : MonoBehaviour
{
    public int QuestNumber, IDofFollowerdoingQuest, NodeNumber; //NodeNumberisUniqueIdentifier
    public string QuestInformation;
    public bool QuestisActive = false, QuestisDone = false;
    public float QuestTimeRequired, QuestTimeStart;

    public GameObject QuestMenu, QuestRewardsInfo, SendFollowertoQuest, PopupNotification, TimerBaar;
    


    private void Start()
    {
        
        GameObject.Find("TestNPCList").GetComponent<TestNPCList>().FollowerIDnumber = 0;
        gameObject.GetComponent<Button>().onClick.AddListener(ShowQuest);
        PopupNotification.GetComponent<Button>().onClick.AddListener(KillPopup);
        SendFollowertoQuest.GetComponent<Button>().onClick.AddListener(SendFollower);

        TimerBaar = GameObject.Find("TimerBaar");
       
    }
    
    private void FixedUpdate()
    {
        CheckifQuestTimeisUp();
    }


    void CheckifQuestTimeisUp()
    {
        if (QuestisActive == true)
        {
            if ((TimerBaar.GetComponent<Timer2>().calen - QuestTimeStart) >= QuestTimeRequired)
                QuestisDone = true;
        }
    }
    
    public void ShowQuest()
    {
        Debug.Log(QuestTimeRequired);
        if (QuestisActive == false)
        {


            GameObject.Find("TestNPCList").GetComponent<TestNPCList>().FetchFollower(0); //To reset the NPC List
            if (GameObject.Find("QuestMenu") == false)
                QuestMenu.SetActive(true);
            
            QuestRewardsInfo.GetComponent<Text>().text = GameObject.Find("QuestList").GetComponent<QuestList>().FetchQuest(QuestNumber);
        }

        if (QuestisActive == true)
        PopUpActiveQuestStatus();
    }

    void SendFollower()
    {
        if(GameObject.Find("TestNPCList").GetComponent<TestNPCList>().FollowerIDnumber == 0)
        PopUpNoFollowerSelected();

        else if (QuestisActive == false && QuestNumber == GameObject.Find("QuestList").GetComponent<QuestList>().Questnumber)
        {
            IDofFollowerdoingQuest = GameObject.Find("TestNPCList").GetComponent<TestNPCList>().FollowerIDnumber; //To get the followerID of the follower on the quest.
            QuestTimeRequired = GameObject.Find("QuestList").GetComponent<QuestList>().Quest_Time; //To get the time required to finish the quest
            QuestTimeStart = TimerBaar.GetComponent<Timer2>().calen;
            QuestisActive = true;
            QuestMenu.SetActive(false);
        }
    }





    //POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS

    void PopUpActiveQuestStatus()
    {
        if (QuestisDone == true) //WHEN THE QUEST IS FINISHED
        {
            GameObject.Find("QuestList").GetComponent<QuestList>().FetchQuest(QuestNumber);
            PopupNotification.SetActive(true);

            GameObject.Find("PopupText").GetComponent<Text>().text = GameObject.Find("QuestList").GetComponent<QuestList>().ListofRewards;
            GameObject.Find("QuestList").GetComponent<QuestList>().SubmitQuestRewards();

            QuestisActive = false;
            QuestisDone = false;

            Debug.Log("Gold amount for the quest is " + GameObject.Find("QuestList").GetComponent<QuestList>().LootReward_Gold);
            gameObject.SetActive(false);
        }

        else
        {
            GameObject.Find("QuestList").GetComponent<QuestList>().FetchQuest(QuestNumber);
            GameObject.Find("TestNPCList").GetComponent<TestNPCList>().FetchFollower(IDofFollowerdoingQuest);
            PopupNotification.SetActive(true);
            GameObject.Find("PopupText").GetComponent<Text>().text = "The Quest is currently being fulfilled by " + GameObject.Find("TestNPCList").GetComponent<TestNPCList>().Race
                                                                     + " " + GameObject.Find("TestNPCList").GetComponent<TestNPCList>().Class + " "
                                                                     + GameObject.Find("TestNPCList").GetComponent<TestNPCList>().FollowerName + "\nDays Left = "
                                                                     + (QuestTimeRequired - (TimerBaar.GetComponent<Timer2>().calen - QuestTimeStart));
        }
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
