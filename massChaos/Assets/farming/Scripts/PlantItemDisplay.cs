using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlantItemDisplay : MonoBehaviour
{
    public Text plantName;
    public Image plantImage;
    public Image seedImage;
    public Text plantGrowDuration;
    public Text plantReward;

    public PlantItem item;
    // Start is called before the first frame update
    void Start()
    {
        if (item != null)
            Prime(item);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Prime(PlantItem item)
    {
        this.item = item;
        if (plantName != null)
            plantName.text = item.plantDisplayName;
        if (plantImage != null)
            plantImage.sprite = item.plantSpriteDisplay;
        if (plantGrowDuration != null)
            plantGrowDuration.text = item.growDurationDisplay;
        if (plantReward != null)
            plantReward.text = item.plantRewardDisplay;
        if (seedImage != null)
            seedImage.sprite = item.seedSpriteDisplay;

    }
}
