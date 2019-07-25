using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BB_BuildingUpgrades : MonoBehaviour
{
    // Change Sprite
    SpriteRenderer spriteRenderer;
    int currentUpgradeLevel = 0;
    

    //Get Building Stats
    BB_BuildingStatsSO bB_BuildingStatsSO;
    [SerializeField] BB_BuildingStatsSO[] buildings;
    [SerializeField] Text capcityText, npcLiving, currentLevel, resourceRequired;
    GameObject UpgradeButton;
    

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        changeSpirte();
        
    }

   

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.Find("StatsUI/Canvas/UpgradeButton") == null)
        {
            Debug.Log("Object Not Found %%%%%%");
        }
    }

    public void changeSpirte()
    {
        if (this.currentUpgradeLevel >= buildings.Length)
        {
            return;
        }

        spriteRenderer.sprite = buildings[currentUpgradeLevel].GetBuildingSprite();
        capcityText.text = "Capacity: " + "0/" + buildings[currentUpgradeLevel].getCapacity().ToString();
        npcLiving.text = "NPC living here: " + buildings[currentUpgradeLevel].npc_LivingName();
        currentLevel.text = "Current Level: " + buildings[currentUpgradeLevel].CurrentLevel();

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
