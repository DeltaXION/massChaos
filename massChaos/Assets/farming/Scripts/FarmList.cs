using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmList : MonoBehaviour
{
    public List<PlantItem> farmLand = new List<PlantItem>();
    public FarmListDisplay farmListDisplayPrefab;

    public static GameObject a;
    
    // Start is called before the first frame update
    void Start()
    {
        
        FarmListDisplay farm = (FarmListDisplay)Instantiate(farmListDisplayPrefab);
        farm.Prime(farmLand);
        
        a = GameObject.FindGameObjectWithTag("Farm");
        a.gameObject.SetActive(false);
        Debug.Log(a);
        //b = GameObject.FindGameObjectWithTag("ExitButton");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseDown()
    {
        
    }
}
