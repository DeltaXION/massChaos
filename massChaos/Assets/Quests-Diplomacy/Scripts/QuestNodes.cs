using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestNodes : MonoBehaviour
{
    public int QuestNumber;
    public string QuestInformation;

    public GameObject QuestMenu, QuestRewardsInfo;
    //public Text QuestRewardsInfo;


    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ShowQuest);

       
    }

    void ShowQuest()
    {
        if(GameObject.Find("QuestMenu") == false)
        QuestMenu.SetActive(true);
        
        Debug.Log("Quest number is " + QuestNumber);
        
        QuestRewardsInfo.GetComponent<Text>().text = GameObject.Find("QuestList").GetComponent<QuestList>().FetchQuest(QuestNumber);

    }

   

    private void OnMouseOver()
    {
        Debug.Log("InfoPopup");
    }

}
