using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmListDisplay : MonoBehaviour
{
    public Transform farmTargetTransform;
    public PlantItemDisplay plantItemDisplayPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Prime(List<PlantItem> farmLand)
    {
        foreach (PlantItem item in farmLand)
        {
            PlantItemDisplay display = (PlantItemDisplay)Instantiate(plantItemDisplayPrefab);
            display.transform.SetParent(farmTargetTransform, false);
            display.Prime(item);

        }
    }
}
