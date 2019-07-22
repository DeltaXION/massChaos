using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowerSlot : MonoBehaviour
{
    public int FollowerSlotNumber;
    public GameObject QuestRewardsInfo;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(SelectedSlot); //Button starts function that gives SlotNumber to NPC List for reference
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SelectedSlot()
    {
        GameObject.Find("TestNPCList").GetComponent<TestNPCList>().FollowerSlotisSelected(FollowerSlotNumber); //Function sends FollowerSlotNumber variable to NPC List 
        ShowQuest();
        
    }

    public void ShowQuest()
    {   
        QuestRewardsInfo.GetComponent<Text>().text = GameObject.Find("QuestList").GetComponent<QuestList>().FetchQuest(GameObject.Find("QuestList").GetComponent<QuestList>().Questnumber);
    }
}
