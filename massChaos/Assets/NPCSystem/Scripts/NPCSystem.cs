using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPCSystem : MonoBehaviour
{

    public GameObject can;

    public static int id = 0;
    public static List<BaseCharachteristics> followers = new List<BaseCharachteristics>();
    BaseCharachteristics b;


   
    public float totalHappiness;
    public double totalNomads;
    public double totalFerrarium;
    public double totalFroots;
    public double totalMimax;
    public int baseCapacity;
    public int numberOfNpcs;
    NPCList n;
    // Start is called before the first frame update


    void Start()
    {
        setHappinessIndex();

        addFollower("Broom",  "N", "warrior", "gun", "sword", "idle");
        addFollower("Groom", "Fr", "maige", "sword", "bazooka", "idle");

        setPrestige();
        can.SetActive(false);
        AppplicantsCalculation();
        //b = GetFollowerByID(2);
        //Debug.Log(b.Name);
        Debug.Log("Happpy = " + Nomad.HappinessIndex);
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
        Nomad.happinessIndex = 57;
        Ferrarium.happinessIndex = 14;
        Froots.happinessIndex = 15;
        Mimax.happinessIndex = 17;
    }


    public static void addFollower( string name, string type, string classType, string secItem, string priItem, string status) {
        id++;
        followers.Add(new BaseCharachteristics(id, name, type, classType, secItem, priItem, status));


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


    public void removeFollower(int id)
    {
        int index = id - 1;
        followers.RemoveAt(index);
    }

    public void OnMouseDown()
    {
        can.SetActive(true);
        Debug.Log("mouse");
        
        n = new NPCList();
        n.UpdateNPCList();
        // GameObject go = (GameObject)Instantiate(can);
       
    }

    public void onExitClick() {
       
       
        Debug.Log("mouse2");
        GameObject[] entries= GameObject.FindGameObjectsWithTag("NPCEntry");
        foreach (GameObject go in entries)
        {
            Destroy(go);
        }
        can.SetActive(false);
    }

    public void classAssign() {

    }

    public void AppplicantsCalculation() {

        numberOfNpcs = baseCapacity * 2;

       // Debug.Log("Happpy2 = " + Nomad.HappinessIndex);

        totalHappiness = Nomad.HappinessIndex + Ferrarium.HappinessIndex + Mimax.HappinessIndex + Froots.HappinessIndex;

        float nomadCountDec = ((Nomad.happinessIndex / totalHappiness) * numberOfNpcs) ;

        float ferrariumCountDec = ((Ferrarium.happinessIndex / totalHappiness) * numberOfNpcs);

        float mimaxCountDec = ((Mimax.happinessIndex / totalHappiness) * numberOfNpcs) ;

        float frootsCountDec = ((Froots.happinessIndex / totalHappiness) * numberOfNpcs);

        totalNomads = Math.Round(nomadCountDec);

        Debug.Log("Nomad Count = " + totalNomads);

        totalFerrarium = Math.Round(ferrariumCountDec);

        Debug.Log("ferrarium Count = " + totalFerrarium);

        totalFroots = Math.Round(frootsCountDec);

        Debug.Log("totalFroots = " + totalFroots);

        totalMimax = Math.Round(mimaxCountDec);

        Debug.Log("totalMimax = " + totalMimax);
    }


    public void ApplicantSelect() {
        Debug.Log("Cliccked");
    }

}
