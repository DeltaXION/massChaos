using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class close : MonoBehaviour, ISelectHandler
{
    // Start is called before the first frame update
    public GameObject can;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnSelect(BaseEventData eventData)
    {
        GameObject[] entries = GameObject.FindGameObjectsWithTag("applicantItem");
        foreach (GameObject go in entries)
        {
            Destroy(go);
        }
        can.SetActive(false);
    }
}
