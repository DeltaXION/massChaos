using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCList : MonoBehaviour
{
    public GameObject NPCEntry;
    public NPCSystem nPC;
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
            go.transform.Find("type").GetComponent<Text>().text = o.Type;
            go.transform.Find("affinity").GetComponent<Text>().text = o.Affinity.ToString();
            go.transform.Find("foodIntake").GetComponent<Text>().text = o.FoodIntake.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
