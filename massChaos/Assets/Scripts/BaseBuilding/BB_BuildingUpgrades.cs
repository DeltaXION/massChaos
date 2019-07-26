using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BB_BuildingUpgrades : MonoBehaviour
{
    // Change Sprite
    SpriteRenderer spriteRenderer;
    [SerializeField] int currentUpgradeLevel = 0;

   // [SerializeField] NPCApplicants npcApplicantList;
    //Get Building Stats
    BB_BuildingStatsSO bB_BuildingStatsSO;
    [SerializeField] BB_BuildingStatsSO[] buildings;
    [SerializeField] Text capcityText, npcLiving, currentLevel, resourceRequired, npcApplicant;
    GameObject UpgradeButton;

    string[] applicantName = new string[20];
    string MovedInGuy = "";

    List<BaseCharachteristics> ApplicantList = NPCApplicants.applicants;

    [Header ("Button to ADD NPC")]
    [SerializeField] Button button1, button2;

    [Header("UI")]
    [SerializeField] GameObject statsUI, assignList;


    // Start is called before the first frame update
    void Start()
    {
        assignList.SetActive(true);
        spriteRenderer = GetComponent<SpriteRenderer>();

        

        npcApplicant.text = "Name: \n" + ApplicantList[0].name.ToString() + "\n\n" + ApplicantList[1].name.ToString();

    }

   

    // Update is called once per frame
    void Update()
    {
       
    }

   

    public void addNPCtoHouseFirstButton()
    {
        int i = 0;
        npcApplicant.text = ApplicantList[i].name.ToString() + " Moved In";
        applicantName[0] = ApplicantList[i].name.ToString();
        
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);

        statsUI.SetActive(true);
        assignList.SetActive(false);

        ApplicantList[i].status = "idle";
        ApplicantList[i].houseId  = FindObjectOfType<BB_House>().GetHouseID();

        NPCSystem.addFollower(ApplicantList[i].name,
                                ApplicantList[i].type, 
                                ApplicantList[i].classType, 
                                ApplicantList[i].secItem, 
                                ApplicantList[i].priItem, 
                                ApplicantList[i].status,
                                ApplicantList[i].houseId);
        
        FindObjectOfType<BB_GlobalStats>().addToPopulation();

        FindObjectOfType<BaseHealth>().BaseHealthCalc();

        changeSpirte();
    }


    public void addNPCtoHouseSecondButton()
    {
        int i = 1;
        npcApplicant.text = ApplicantList[i].name.ToString() + " Moved In";
        applicantName[0] = ApplicantList[i].name.ToString();
       
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);

        statsUI.SetActive(true);
        assignList.SetActive(false);

        ApplicantList[i].status = "idle";
        ApplicantList[i].houseId = FindObjectOfType<BB_House>().GetHouseID();

        NPCSystem.addFollower(ApplicantList[i].name, 
                              ApplicantList[i].type, 
                              ApplicantList[i].classType, 
                              ApplicantList[i].secItem, 
                              ApplicantList[i].priItem,
                              ApplicantList[i].status,
                              ApplicantList[i].houseId);

        FindObjectOfType<BB_GlobalStats>().addToPopulation();

        FindObjectOfType<BaseHealth>().BaseHealthCalc();

        changeSpirte();
    }



    public void changeSpirte()
    {
        if (this.currentUpgradeLevel >= buildings.Length)
        {
            return;
        }

        
        spriteRenderer.sprite = buildings[currentUpgradeLevel].GetBuildingSprite();
        capcityText.text = "Capacity: " + FindObjectOfType<BB_GlobalStats>().GetPopulation().ToString() +  "/" + buildings[currentUpgradeLevel].getCapacity().ToString();

        //npcLiving.text = "NPC living here: " + buildings[currentUpgradeLevel].npc_LivingName();

        npcLiving.text = "NPC living here: " + applicantName[0];
      


        currentLevel.text = "Current Level: " + buildings[currentUpgradeLevel].CurrentLevel();

    
         FindObjectOfType<BB_GlobalStats>().addToPopulationCapacity(currentUpgradeLevel);
       

        
        
        if (this.currentUpgradeLevel < buildings.Length-1)
        {
            resourceRequired.text = "Resource Required: " + buildings[currentUpgradeLevel + 1].resourcesRequired();
            currentUpgradeLevel++;

        }
        else if(this.currentUpgradeLevel == buildings.Length-1)
        {
            resourceRequired.fontSize = 50;
            resourceRequired.text = "Upgrade Maxed";
            disableUpgradeButton();

        }
 
    }


    public int GetCurrentUpgradeLevel()
    {
        return currentUpgradeLevel;
    }

    private void disableUpgradeButton()
    {
        gameObject.transform.Find("StatsUI/Canvas/UpgradeButton").gameObject.SetActive(false);
    }

    public void level0()
    {
        bB_BuildingStatsSO.npc_LivingName();
    }
}
