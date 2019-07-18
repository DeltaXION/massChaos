using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Image timeBar;
    public float Daymax;
    public float Nightmax;
    public float dayTime;
    public float nightTime;
    public GameObject DayText;
    public GameObject NightText;
    public GameObject date;
    float calen;
    




    void Start()
    {
        DayText.SetActive(true);

        timeBar = GetComponent<Image>();

        dayTime = Daymax;

        date = GameObject.Find("date");
        calen = 1;

    }



    void Update()
    {
        if (dayTime >= 0)
        {
            

            //calen = calen + h;

            date.GetComponent<Text>().text = "Day" + calen.ToString();
            nightTime = Nightmax;
            NightText.SetActive(false);
            dayTime -= Time.deltaTime;
            timeBar.fillAmount = dayTime / Daymax;
            if (timeBar.fillAmount == 0)
            {
                calen = calen + 1;
            }
            DayText.SetActive(true);
            
        }
        else
        {


            NightText.SetActive(true);
            DayText.SetActive(false);
            //Time.timeScale = 0; 
            nightTime -= Time.deltaTime;
            timeBar.fillAmount = nightTime / Nightmax;

            if (nightTime <= 0)
            {
                dayTime = Daymax;
               
            }
            if (nightTime == 0)
            { calen -= 1; }



        }



    }



}
