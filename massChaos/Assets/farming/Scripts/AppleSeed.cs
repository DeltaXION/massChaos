using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleSeed : MonoBehaviour
{
    public GameObject newPlant;
    public PlantItemDisplay plantItemDisplayPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlantAppleSeed()
    {
        PlantItemDisplay display = (PlantItemDisplay)Instantiate(plantItemDisplayPrefab);
    }
}
