﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ApplicantAccept : MonoBehaviour, ISelectHandler
{
    // Start is called before the first frame update
    NPCList n;
    public static GameObject g;
    void Start()
    {
       // g = GameObject.Find("ClassSelect");
        //g.transform.GetChild(0);
        // Resources.FindObjectsOfTypeAll(typeof(GameObject));
        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (go.name == "ClassSelect")
            {
                g = go;
            }
        }


        g.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        Debug.Log("Yesss");

    }

    public void OnSelect(BaseEventData eventData)
    {
        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (go.name == "ClassSelect")
            {
                g = go;
            }
        }
        string id = transform.parent.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text.ToString();
       // Debug.Log("!!!!!!!!!!!!!" +id);
        BaseCharachteristics b;
        if (this.gameObject.name == "accept") {
            g.SetActive(true);
           // b = NPCApplicants.GetFollowerByID(int.Parse((id)));
            NPCSystem.followerIdToUpdateClass = int.Parse((id));
            //NPCSystem.addFollower(b.Name, b.Type,"", "", "", "idle");
            
            Destroy(transform.parent.gameObject);
            NPCApplicants.removeFollower(int.Parse((id)));
        }
        if (this.gameObject.name == "reject")
        {
            transform.parent.gameObject.SetActive(false);
            NPCApplicants.removeFollower(int.Parse((id)));
        }
    }

   
}
