using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Image timeBar;
    public float Daymax;
    public float Nightmax;
    public static float dayTime;
    public static float nightTime;
    public GameObject DayText;
    public GameObject NightText;
    public GameObject date;
    public GameObject tim;
    float calen;
    public bool timerActive = false;
    public Text timevalue;
    public Text playButtonTxt;
    //float n;
    




    void Start()
    {
        DayText.SetActive(true);
        NightText.SetActive(false);

        timeBar = GetComponent<Image>();

        dayTime = Daymax;
        tim = GameObject.Find("time");

        date = GameObject.Find("date");
        calen = 1;
        

    }



    void Update()
    {
        if (timerActive)
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
               // timeBar.fillAmount = n;
                timevalue.text = (timeBar.fillAmount * Daymax).ToString("F2");

            }
            else
            {


                NightText.SetActive(true);
                DayText.SetActive(false);
                //Time.timeScale = 0; 
                nightTime -= Time.deltaTime;
                timeBar.fillAmount = nightTime / Nightmax;
                timevalue.text = (timeBar.fillAmount * Nightmax).ToString("F2");

                if (nightTime <= 0)
                {
                    dayTime = Daymax;

                }
                if (nightTime == 0)
                { calen -= 1; }



            }

        }

    }
    
    public void playButton()
    {
        timerActive = !timerActive;
        playButtonTxt.text = timerActive ? "Pause" : "Play";
    }



}
