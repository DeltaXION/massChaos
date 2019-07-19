using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestNodes : MonoBehaviour
{
    public int QuestNumber;

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ShowQuest);
       
    }

    void ShowQuest()
    {
        Debug.Log("QuestMenuPopup for Node "+ gameObject.name + " with Quest number " + QuestNumber);
    }

   

    private void OnMouseOver()
    {
        Debug.Log("InfoPopup");
    }
}
