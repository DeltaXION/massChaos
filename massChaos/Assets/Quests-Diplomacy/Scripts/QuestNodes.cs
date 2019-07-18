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
        Debug.Log("QuestMenuPopup");
    }

    private void OnMouseOver()
    {
        Debug.Log("InfoPopup");
    }
}
