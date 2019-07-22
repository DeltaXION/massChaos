using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BB_BuildingUpgrades : MonoBehaviour
{
    // Change Sprite
    SpriteRenderer spriteRenderer;
    int i = 0;

    //Get Building Stats
    BB_BuildingStatsSO bB_BuildingStatsSO;
    [SerializeField] BB_BuildingStatsSO[] buildings;
    [SerializeField] Text capcityText, npcLiving, currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        changeSpirte();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeSpirte()
    {
        if (this.i >= buildings.Length)
        {
           return;
        }

        spriteRenderer.sprite = buildings[i].GetBuildingSprite();
        capcityText.text = "Capacity: " + "0/" + buildings[i].getCapacity().ToString();
        npcLiving.text = "NPC living here: " + buildings[i].npc_LivingName();
        currentLevel.text = "Current Level: " + buildings[i].CurrentLevel();

        i++;
      
    }

    public void level0()
    {
        bB_BuildingStatsSO.npc_LivingName();
    }
}
