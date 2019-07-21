using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCApplicants : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ApplicantItems;
    static int id = 0;
    string type;
    public static List<BaseCharachteristics> applicants = new List<BaseCharachteristics>();

    void Start()
    {
        addFollower("Broom", "N", 'w', "gun");
        addFollower("Groom", "Fr", 'm', "sword");

        foreach (var o in applicants)
        {

            GameObject go = (GameObject)Instantiate(ApplicantItems);
            go.transform.SetParent(this.transform);
            go.transform.Find("name").GetComponent<Text>().text = o.Name;
           
            switch (o.Type)
            {
                case "N":                   
                    type = "Nomad";
                    go.transform.Find("affinity").GetComponent<Text>().text = "Combat";
                    break; 
                case "Fr":
                   
                    type = "Ferrarium";
                    go.transform.Find("affinity").GetComponent<Text>().text = "Trade";
                    break;
                case "Fo":
                  
                    type = "Froot";
                    go.transform.Find("affinity").GetComponent<Text>().text = "Farming";
                    break;
                case "M":
                    
                    type = "Mimax";
                    go.transform.Find("affinity").GetComponent<Text>().text = "Defence";
                    break;
            }



             go.transform.Find("type").GetComponent<Text>().text = type;
            //go.transform.Find("foodIntake").GetComponent<Text>().text = o.FoodIntake.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addFollower(string name, string type, char classType, string secItem)
    {
        id++;
        applicants.Add(new BaseCharachteristics(id, name, type, classType, secItem));
    }
}
