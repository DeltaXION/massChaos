using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSystem : MonoBehaviour
{

    public GameObject can;
    public static int id = 0;
    public static List<BaseCharachteristics> followers = new List<BaseCharachteristics>();
    BaseCharachteristics b;
    // Start is called before the first frame update


void Start()
    {
        addFollower("Broom",  "N");
        addFollower("Groom", "Fr");
        setPrestige();
        can.SetActive(false);
        //b = GetFollowerByID(2);
        //Debug.Log(b.Name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Applications() {

    }

    void setPrestige() {
        Nomad.prestige = 32;
        Ferrarium.prestige = 20;
        Froots.prestige = 25;
        Mimax.prestige = 16;
    }

    void setAffinity()
    {
        Nomad.affinity = 'c';
        Ferrarium.affinity = 't';
        Froots.affinity = 'f';
        Mimax.affinity = 'd';
    }

    void setHappinessIndex()
    {
        Nomad.happinessIndex = 12;
        Ferrarium.happinessIndex = 14;
        Froots.happinessIndex = 15;
        Mimax.happinessIndex = 17;
    }

    public void addFollower( string name, string type) {
        id++;
        followers.Add(new BaseCharachteristics(id, name, type));
    }

    public void updateFollower()
    {
    }

    public List<BaseCharachteristics> getFollower()
    {
        return followers;
    }

    public BaseCharachteristics GetFollowerByID(int id) {

        BaseCharachteristics b = null;
        foreach (var o in NPCSystem.followers) {
            if (o.id == id)
            {
                b = o;
            }
        }
        return b; 
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

    public void classAssign() {

    }

}
