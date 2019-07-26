using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MimaxHIUIscript : MonoBehaviour
{

    private float CurrentHappiness;
    public Image Happiness;


    // Start is called before the first frame update
    void Start()
    {
        Happiness = GetComponent<Image>();
    }


    void ReadjustHappiness()
    {
        CurrentHappiness = MimaxHappinessIndex.MimaxHappiness;
        Happiness.fillAmount = CurrentHappiness / 10;
    }


    // Update is called once per frame
    void Update()
    {
        ReadjustHappiness();
    }
}