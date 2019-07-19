using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestNodes : MonoBehaviour
{
    public int QuestNumber;
    public string QuestInformation;


    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ShowQuest);

       
    }

    void ShowQuest()
    {
        Debug.Log(QuestNumber);
        QuestInformation = GameObject.Find("QuestList").GetComponent<QuestList>().FetchQuest(QuestNumber);
        Debug.Log(QuestInformation);
        
    }

   

    private void OnMouseOver()
    {
        Debug.Log("InfoPopup");
    }

}
