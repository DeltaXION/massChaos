using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class NPCSystem : MonoBehaviour
{

    public GameObject can;
    public Dropdown classOptions;
    public Dropdown weaponOptions;

    public static BaseCharachteristics followerToAdd;

    public static int id = 0;
    public static List<BaseCharachteristics> followers = new List<BaseCharachteristics>();
    BaseCharachteristics b;

    public static GameObject weaponCanvas;

   
    public float totalHappiness;
    public double totalNomads;  
    public double totalFerrarium;
    public double totalFroots;
    public double totalMimax;
    public int baseCapacity;
    public int numberOfNpcs;
    public static string classFinal = "Warrior";
    public static string weaponFinal = "";
    public static int followerIdToUpdate;
    public static int followerIdToUpdateClass;
    public GameObject classMenuList;
    public GameObject WeaponMenuList;
    public GameObject WeaponSelectOption;

    NPCList n;
    // Start is called before the first frame update
    public GameObject g;

    void Start()
    {
        //addFollower("Broom", "N", "", "sword", "sword", "idle", 0);
        //addFollower("Groom", "Fr", "", "", "", "idle", 0);
        setHappinessIndex();

        

        populateList();
        WeaponSelect();
        weaponCanvas = GameObject.Find("WeaponOptions");
        classMenuList = GameObject.Find("AssignListTavern");
        WeaponMenuList = GameObject.Find("WeaponAssign");
        WeaponMenuList.SetActive(false);
        classMenuList.SetActive(false);
       // weaponCanvas.SetActive(false);

        setPrestige();
        //can.SetActive(false);
        AppplicantsCalculation();
        g = GameObject.Find("ClassSelect");
        g.SetActive(false);
        //b = GetFollowerByID(2);
        //Debug.Log(b.Name);
        Debug.Log("Happpy = " + Nomad.HappinessIndex);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void classMenu() {
        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (go.name == "AssignListTavern")
            {
                classMenuList = go;
            }
        }
        classMenuList.SetActive(true);
        NPCApplicants npc = new NPCApplicants();
        npc.PopulateList();
    }

    public void classWeaponMenu()
    {
        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (go.name == "WeaponAssign")
            {
                WeaponMenuList = go;
            }
        }
        WeaponMenuList.SetActive(true);
        NPCApplicants npc = new NPCApplicants();
        npc.PopulateListForWeapons();
    }

    public static void UpdateWeapon(int id) {
        id-=1;
        followers[id].PriItem = weaponFinal; 

    }

    public static void UpdateClass(int id)
    {
        id-=1;
        followers[id].ClassType = classFinal;

    }

    public void weaponMenuPop() {
       // weaponCanvas.SetActive(true);
    }

    public void weaponMenuClose()
    {
        weaponCanvas.SetActive(false);
    }

    List<string> weapons = new List<string>() {"Sword", "Stick" };

    public void WeaponSelect() {
       // WeaponBaseInventory inventory = new WeaponBaseInventory();
        //foreach (var o in inventory.items) {
         //   int i = 0;
        //    weapons[i] = o.name;
        //    i++;
      //  }
        weaponOptions.AddOptions(weapons);
    }

    public void Dropdown_IndexChangeWeapons(int index)
    {
        weaponFinal = weapons[index];
    }

    public void WeaponSelected() {
        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (go.name == "WeaponSelect")
            {
                WeaponSelectOption = go;
            }
        }
        WeaponSelectOption.SetActive(false);
        UpdateWeapon(followerIdToUpdate);
    }


    void populateList()
    {

        classOptions.AddOptions(classes);
    }

    public void classSelected() {
        Debug.Log(classFinal);
        // addFollower(followerToAdd.Name, followerToAdd.Type, classFinal, "", "", "idle", 0);
        UpdateClass(followerIdToUpdateClass);
        GameObject.Find("ClassSelect").SetActive(false);
    }


    // Start is called before the first frame update

    List<string> classes = new List<string>() { "Warrior", "Maige", "Ranger" };

    public void Dropdown_IndexChange(int index)
    {
       // Debug.Log(classes[index]);
        classFinal = classes[index];
        Debug.Log(classFinal);
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


    public static void addFollower( string name, string type, string classType, string secItem, string priItem, string status, int houseId) {
        id++;
        followers.Add(new BaseCharachteristics(id, name, type, classType, secItem, priItem, status, houseId));


    }

    public void updateFollower()
    {
    }

    public static List<BaseCharachteristics> getFollower()
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


    public static void removeFollower(int id)
    {
        int index = id - 1;
        if(index<0)
        {
            index = 0;
        }
        
        followers.RemoveAt(index);
    }

    public void OnMouseDown()
    {

        can.SetActive(true);
       // Debug.Log("mouse");

        
        n = new NPCList();
        n.UpdateNPCList();
        // GameObject go = (GameObject)Instantiate(can);
       
    }

    public void onExitClick() {

       
        
       // Debug.Log("mouse2");
        GameObject[] entries= GameObject.FindGameObjectsWithTag("NPCEntry");
        foreach (GameObject go in entries)
        {
            Destroy(go);
        }
        can = GameObject.Find("NPCCanvas");
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
