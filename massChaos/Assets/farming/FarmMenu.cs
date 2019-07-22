using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class FarmMenu : MonoBehaviour
{
    //add anothergameobject below  for add follower. Also, 
    public GameObject PlantASeed, AddFollower, ExitFarmMenu;
    public static List<PlantList> list1 = new List<PlantList>();
    // Start is called before the first frame update

    void Start()
    {
        gameObject.SetActive(false);
        PlantASeed.GetComponent<Button>().onClick.AddListener(SeedPlant);
        ExitFarmMenu.GetComponent<Button>().onClick.AddListener(FarmMenuExit);
        AddFollower.GetComponent<Button>().onClick.AddListener(FollowerAdd);
        //Uncomment above code after AddFollowerFarm is added to public GameObject


        

        list1.Add(new PlantList(1, "Cherry", false, 120, 65));
        list1.Add(new PlantList(2, "Apple", true, 100, 40));
        list1.Add(new PlantList(3, "Grape", false, 400, 150));
        list1.Add(new PlantList(4, "Orange", false, 580, 220));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SeedPlant()
    {
        Debug.Log("SeedPlanted");
    }

    void FarmMenuExit()
    {
        
        Debug.Log("Close button works");

    }

    void FollowerAdd()
    {
        Debug.Log("FollowerAdded");
    }
    //Uncomment after AddFollowerFarm is added to public GameObject
}
