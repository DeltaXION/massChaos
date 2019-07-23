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
        FillSlots();
    }

    void SelectedSlot()
    {

        if(FollowerStatus == "Questing")
        {
            gameObject.GetComponent<QuestNodes>().PopUpFollowerIsAlreadyonQuest();
            return;
        }

        //COMEBACKHERE
        // TestNPCList.GetComponent<TestNPCList>().FollowerSlotisSelected(FollowerSlotNumber); //Function sends FollowerSlotNumber variable to NPC List 

        GameObject.Find("QuestList").GetComponent<QuestList>().PickFollower(gameObject);
        ShowQuest();
        
        
    }


    //INSERTS TEXT INTO THE QUEST INFORMATION TEXTBOX. THIS MAY OR MAY NOT BE WITH THE FOLLOWER MODIFIERS THUS IT IS CALLED WHENEVER A FOLLOWER SLOT IS SELECTED/CLICKED AND THE MODIFIERS CHANGE
    public void ShowQuest()
    {   

        QuestInfo.GetComponent<Text>().text = GameObject.Find("QuestList").GetComponent<QuestList>().FetchQuest(GameObject.Find("QuestList").GetComponent<QuestList>().Questnumber);
    }


    //MOSTLY CALLED BY FOLLOWERSLOTMANAGER. FUNCTION TO FILL THE INFORMATION TEXTBOX OF THE FOLLOWER SLOT BY FILLING IT WITH THE VARIABLES HERE CHANGED BY THE FOLLOWERSLOTMANAGER WHEN IT CALLS IT
    public void FillSlots() 
    {
        FollowerSlotInfo.GetComponent<Text>().text = FollowerName + "\n" + FollowerRace + "\n" + FollowerClass + "\n" + FollowerPrimaryWeapon + "\n" + FollowerSecondaryWeapon +"\n" + FollowerStatus;        
    }
}
