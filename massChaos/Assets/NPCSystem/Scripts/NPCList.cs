﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCList : MonoBehaviour
{
    public GameObject NPCEntry;
    public NPCSystem nPC;
    public string prestige;
    public string type;
    public string affinity;
    // public BaseCharachteristics b;


    // Start is called before the first frame update
    void Start()
    {
       // string name = b.Name; 

        foreach (var o in NPCSystem.followers)
        {
            
            GameObject go = (GameObject)Instantiate(NPCEntry);
            go.transform.SetParent(this.transform);
            go.transform.Find("id").GetComponent<Text>().text = o.Id.ToString();
            go.transform.Find("name").GetComponent<Text>().text = o.Name;
          
            switch (o.Type)
            {
                case "N":
                    prestige = Nomad.Prestige.ToString();
                    type = "Nomad";
                    go.transform.Find("affinity").GetComponent<Text>().text = "Combat";
                    break;
                case "Fr":
                    prestige = Ferrarium.Prestige.ToString();
                    type = "Ferrarium";
                    go.transform.Find("affinity").GetComponent<Text>().text = "Trade";
                    break;
                case "Fo":
                    prestige = Froots.Prestige.ToString();
                    type = "Froot";
                    go.transform.Find("affinity").GetComponent<Text>().text = "Farming";
                    break;
                case "M":
                    prestige = Mimax.Prestige.ToString();
                    type = "Mimax";
                    go.transform.Find("affinity").GetComponent<Text>().text = "Defence";
                    break;
            }
            go.transform.Find("prestige").GetComponent<Text>().text = prestige;
            go.transform.Find("type").GetComponent<Text>().text = type;


            // go.transform.Find("affinity").GetComponent<Text>().text = o.Affinity.ToString();
            //go.transform.Find("foodIntake").GetComponent<Text>().text = o.FoodIntake.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
