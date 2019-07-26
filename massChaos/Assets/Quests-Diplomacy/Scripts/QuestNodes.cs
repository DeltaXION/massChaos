using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestNodes : MonoBehaviour
{
    public int QuestNumber, IDofFollowerdoingQuest, NodeNumber; //NodeNumberisUniqueIdentifier, IDofFollowerdoingQuest also stores ID of selected Follower
    public string QuestInformation;
    public bool QuestisActive = false, QuestisDone = false, NodeisActive = false;
    public float QuestTimeRequired, QuestTimeStart;

    public GameObject QuestMenu, QuestRewardsInfo, SendFollowertoQuest, PopupNotification, TimerBaar, QuestDiplomacyMenuButton, QuestMenuExitButton;
    


    private void Start()
    {
        
        //GameObject.Find("TestNPCList").GetComponent<TestNPCList>().FollowerIDnumber = 0;

        gameObject.GetComponent<Button>().onClick.AddListener(ShowQuest);
        PopupNotification.GetComponent<Button>().onClick.AddListener(KillPopup);
        SendFollowertoQuest.GetComponent<Button>().onClick.AddListener(SendFollower);
        QuestDiplomacyMenuButton.GetComponent<Button>().onClick.AddListener(TurnoffNode);
        QuestMenuExitButton.GetComponent<Button>().onClick.AddListener(TurnoffQuestMenu);

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


    //TURN OFF QUESTMENU AND MAKE NODE INACTIVE
    void TurnoffQuestMenu()
    {
        GameObject.Find("FollowerSlots").GetComponent<FollowerSlotsManager>().ActiveFollowerSlotID = 0;

        ResetQuestActiveFollower();

        if (QuestisActive == false)
            ResetNodeIDofFollower();

        QuestMenu.SetActive(false);
        TurnoffNode();
    }


    //TO SWITCH NODE ACTIVE OR NOT TO MAKE IT EASIER TO SEE WHICH QUESTS ARE RELEVANT SINCE ALL NODES HAVE ONE QUEST EACH
    void TurnoffNode()
    {
        NodeisActive = false;
    }

    private void ResetQuestActiveFollower()
    {
        GameObject.Find("QuestList").GetComponent<QuestList>().FollowerSlotActive = GameObject.Find("DummyFollowerSlot");
    }

    public void ShowQuest()
    {

        if (QuestisActive == true)
            PopUpActiveQuestStatus();
        //GameObject ActiveFollowerReference = GameObject.Find("FollowerSlots").GetComponent<FollowerSlotsManager>().SendActiveNode();
        else if (QuestisActive == false)
        {
            ResetQuestIDofFollower();
            NodeisActive = true;
            if (GameObject.Find("QuestMenu") == false)
                QuestMenu.SetActive(true);


            //IDofFollowerdoingQuest = GameObject.Find("FollowerSlots").GetComponent<FollowerSlotsManager>().ActiveFollowerSlotID;
            GameObject.Find("FollowerSlots").GetComponent<FollowerSlotsManager>().SendActiveNode(gameObject);

            QuestRewardsInfo.GetComponent<Text>().text = GameObject.Find("QuestList").GetComponent<QuestList>().FetchQuest(QuestNumber);
        }

    }


    //WHAT HAPPENS WHEN SEND FOLLOWER BUTTON IS CLICKED
    void SendFollower()
    {


        if (IDofFollowerdoingQuest == 0 && NodeisActive == true) //CONSIDERED TO BE CHANGEED WITH VALUE IN FOLLOWERSLOT            
        {
            Debug.Log("NoFollowerSelected");
            PopUpNoFollowerSelected();
        }

        else if (QuestisActive == false && QuestNumber == GameObject.Find("QuestList").GetComponent<QuestList>().Questnumber)
        {
            //IDofFollowerdoingQuest = GameObject.Find("FollowerSlots").GetComponent<FollowerSlotsManager>().ActiveFollowerSlotID;

            QuestTimeRequired = GameObject.Find("QuestList").GetComponent<QuestList>().Quest_Time; //To get the time required to finish the quest
            QuestTimeStart = TimerBaar.GetComponent<Timer2>().calen;

            GameObject.Find("FollowerSlots").GetComponent<FollowerSlotsManager>().ChangeFollowerStatebetweenBusyandIdle(IDofFollowerdoingQuest);

            //NIYATI's HAPPINESS
            CommonHappinessIndex.RecaclculateHappinessIndex();

            QuestisActive = true;
            NodeisActive = false;
            ChangeColourofNode();


            ResetQuestActiveFollower();
            QuestMenu.SetActive(false);
           
        }
    }

    void ChangeColourofNode()
    {
        if(QuestisActive==true)
        gameObject.GetComponent<Image>().color = new Color32(255,180,80,255);

        if (QuestisActive == false)
         gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }


    //REAP THE REWARDS OF THE QUEST. CALLS SUBMIT QUESTREWARDS IN QUESTLISTS WHICH THEN CALLS UPDATEREWARDSINTOPOOL IN QUESTDIPLOMACYMANAGER
    void ReapRewards()
    {
        //SETTING UP THE RELEVANT FOLLOWER FOR THE QUESTLIST REWARD
        GameObject.Find("FollowerSlots").GetComponent<FollowerSlotsManager>().ActiveFollowerSlotID = IDofFollowerdoingQuest;
        GameObject.Find("QuestList").GetComponent<QuestList>().SetFollowerDetails();

        GameObject.Find("FollowerSlots").GetComponent<FollowerSlotsManager>().ChangeFollowerStatebetweenBusyandIdle(IDofFollowerdoingQuest);
        GameObject.Find("QuestList").GetComponent<QuestList>().FetchQuest(QuestNumber);
        PopupNotification.SetActive(true);

        GameObject.Find("PopupText").GetComponent<Text>().text = GameObject.Find("QuestList").GetComponent<QuestList>().ListofRewards;
        GameObject.Find("QuestList").GetComponent<QuestList>().SubmitQuestRewards();

        QuestisActive = false;
        QuestisDone = false;
        ChangeColourofNode();


        ResetNodeIDofFollower();
        gameObject.SetActive(false);
    }

    void ResetNodeIDofFollower()
    {
        IDofFollowerdoingQuest = 0;
    }

    void ResetQuestIDofFollower()
    {
        GameObject.Find("QuestList").GetComponent<QuestList>().FollowerSlotActive = GameObject.Find("DummyFollowerSlot");
    }





    //POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS...POPUPS

    void PopUpActiveQuestStatus()
    {
        if (QuestisDone == true) //WHEN THE QUEST IS FINISHED
        ReapRewards();

        
        else
        {
            GameObject.Find("QuestList").GetComponent<QuestList>().FetchQuest(QuestNumber);
            GameObject Follower = GameObject.Find("FollowerSlots").GetComponent<FollowerSlotsManager>().FetchFollowerSlotDetails(IDofFollowerdoingQuest); //MINUS 1 BECAUSE ALL ARRAYS START FROM ZERO
            
            PopupNotification.SetActive(true);
            GameObject.Find("PopupText").GetComponent<Text>().text = "The Quest is currently being fulfilled by " + Follower.GetComponent<FollowerSlot>().FollowerRace
                                                                     + " " + Follower.GetComponent<FollowerSlot>().FollowerClass + " "
                                                                     + Follower.GetComponent<FollowerSlot>().FollowerName + "\nDays Left = "
                                                                     + (QuestTimeRequired - (TimerBaar.GetComponent<Timer2>().calen - QuestTimeStart));
            ResetQuestIDofFollower();
        }
    }

    public void PopUpFollowerIsAlreadyonQuest()
    {
        PopupNotification.SetActive(true);
        
        GameObject.Find("PopupText").GetComponent<Text>().text = "Follower is already on a Quest.";
        GameObject.Find("FollowerSlots").GetComponent<FollowerSlotsManager>().ActiveFollowerSlotID = 0;
        if (NodeisActive == true)
            ResetNodeIDofFollower();

    }

    void PopUpNoFollowerSelected()
    {
        PopupNotification.SetActive(true);
        GameObject.Find("PopupText").GetComponent<Text>().text = "No follower selected.";
    }

    void KillPopup()
    {
        PopupNotification.SetActive(false);
    }
}
