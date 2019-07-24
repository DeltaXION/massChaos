using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BB_ResourceManager : MonoBehaviour
{
    Text wood, food, iron, gold;

    // Start is called before the first frame update
    void Start()
    {
        GetResourceCanvasTextComponents();
    }

    private void GetResourceCanvasTextComponents()
    {
        
        wood = GameObject.Find("BB_Main_Canvas/woodCount").GetComponent<Text>();
        food = GameObject.Find("BB_Main_Canvas/stoneCount").GetComponent<Text>();
        iron = GameObject.Find("BB_Main_Canvas/ironCount").GetComponent<Text>();
        gold = GameObject.Find("BB_Main_Canvas/goldCount").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        wood.text = "10";
    }
}
