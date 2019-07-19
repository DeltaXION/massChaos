using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSystem : MonoBehaviour
{

    public GameObject can;
    public static List<BaseCharachteristics> followers = new List<BaseCharachteristics>();
    // Start is called before the first frame update


void Start()
    {
        addFollower(1, "Broom", 20, 30, "N");
        addFollower(2, "Groom", 25, 36, "F");
        can.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    public void addFollower(int id, string name, float affinity, float foodIntake, string type) {
        followers.Add(new BaseCharachteristics(id, name, affinity, foodIntake, type));
    }

    public void updateFollower()
    {
    }

    public List<BaseCharachteristics> getFollower()
    {
        return followers;
    }


    public void removeFollower()
    {
    }

    public void OnMouseDown()
    {
        Debug.Log("mouse");
        can.SetActive(true);
    }

    public void exit() {
        can.SetActive(false);
    }

    

}
