using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowerSlot : MonoBehaviour
{
    public int FollowerSlotNumber, FollowerQuestNumber;
    public GameObject QuestInfo, FollowerSlotInfo, TestNPCList;
    public string FollowerName, FollowerRace, FollowerClass, FollowerSecondaryWeapon, FollowerPrimaryWeapon, FollowerStatus;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(SelectedSlot); //Button starts function that gives SlotNumber to NPC List for reference
        InfoSlotsFill();
        
    }

    void SelectedSlot()
    {
        if(FollowerStatus == "Questing")
        {
            GameObject.Find("QuestNode").GetComponent<QuestNodes>().PopUpFollowerIsAlreadyonQuest();
            return;
        }
               
        //SO... THIS FUCTION CALL BASICALLY CHANGES THE VALUE OF A NODE STORED IN THE FOLLOWERSLOTMANAGER. THIS IS IN ORDER TO AVOID CALLING THE MULTIPLE NODES. THE NODE DATA IS STORED WHEN THE QUEST IS BROUGHT UP.
        GameObject.Find("FollowerSlots").GetComponent<FollowerSlotsManager>().ActiveNode.GetComponent<QuestNodes>().IDofFollowerdoingQuest = FollowerSlotNumber;
        GameObject.Find("FollowerSlots").GetComponent<FollowerSlotsManager>().ActiveFollowerSlotID = FollowerSlotNumber; //Sends FollowerID/Slot number to FollowerSlotsManager to store it for further reference.               

        GameObject.Find("QuestList").GetComponent<QuestList>().SetFollowerDetails();

        ShowQuest();
    }


    //GETS QUEST NUMBER AND INSERTS TEXT INTO THE QUEST INFORMATION TEXTBOX. THIS MAY OR MAY NOT BE WITH THE FOLLOWER MODIFIERS THUS IT IS CALLED WHENEVER A FOLLOWER SLOT IS SELECTED/CLICKED AND THE MODIFIERS CHANGE
    public void ShowQuest()
    {
        FollowerQuestNumber = GameObject.Find("FollowerSlots").GetComponent<FollowerSlotsManager>().ActiveNode.GetComponent<QuestNodes>().QuestNumber; //GetQuestNumber
        GameObject.Find("QuestList").GetComponent<QuestList>().SelectQuest(FollowerQuestNumber); //SetQuestonQuestList
        QuestInfo.GetComponent<Text>().text = GameObject.Find("QuestList").GetComponent<QuestList>().FetchQuest(GameObject.Find("QuestList").GetComponent<QuestList>().Questnumber); //DisplayQuestDetailsonQuestInfoBox
    }


    //MOSTLY CALLED BY FOLLOWERSLOTMANAGER. FUNCTION TO FILL THE INFORMATION TEXTBOX OF THE FOLLOWER SLOT BY FILLING IT WITH THE VARIABLES HERE CHANGED BY THE FOLLOWERSLOTMANAGER WHEN IT CALLS IT
    public void InfoSlotsFill() 
    {
        FollowerSlotInfo.GetComponent<Text>().text = FollowerName + "\n" + FollowerRace + "\n" + FollowerClass + "\n" + FollowerPrimaryWeapon + "\n" + FollowerSecondaryWeapon +"\n" + FollowerStatus;        
    }

}
