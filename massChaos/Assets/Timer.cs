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
    public GameObject art;
    public float travel;
    public float startDay;
    public float time = 10;
    public float wholeDaySeconds;
    public float travelSkip;
    public bool timerActive = false;
    public Text timevalue;
    public Text playButtonTxt;
    float button;
    float calen;
    public GameObject player;
    float playerSpeed;
    
   
    void Start()
    {
        DayText.SetActive(true);
        NightText.SetActive(false);
        timeBar = GetComponent<Image>();
        dayTime = Daymax;
        tim = GameObject.Find("time");
        date = GameObject.Find("date");
        calen = 1;
        // art = travelToDungeon.GetComponent<travelToDungeon>().checkDungeonEntry;
        art = GameObject.Find("travel");//.GetComponent<travelToDungeon>().checkDungeonEntry;
        //  player = GameObject.Find("BB_Player");
        // playerSpeed = GetComponent<BB_BasicControls>();
       playerSpeed = GetComponent<BB_BasicControls>().speed;



    }



    void Update()
    {
        
        travel = art.GetComponent<travelToDungeon>().checkDungeonEntry;
        if (travel == 1)
        {
            timerActive = false;
            playButtonTxt.text = "Play";
            Debug.Log("dungeon entered, time paused");
            button = 1;
            time += travelSkip;
            date.GetComponent<Text>().text = "Day" + calen.ToString("F0");
            playerSpeed = 0;
               
        }
        if (travel == 2)
        {
            timerActive = true;
            playButtonTxt.text = "Pause";
            button = 0;
        }


        if (timerActive)
        {
            time += Time.deltaTime;
            calen = time / wholeDaySeconds;
            date.GetComponent<Text>().text = "Day " + calen.ToString("F0");
            playButtonTxt.text = "Pause";

            if (dayTime >= 0)
            {

                nightTime = Nightmax;
                NightText.SetActive(false);
                dayTime -= Time.deltaTime;
                timeBar.fillAmount = dayTime / Daymax;
                /* if (timeBar.fillAmount == 0)
                 {
                     calen = calen + 1;
                 }*/
                DayText.SetActive(true);
                // timeBar.fillAmount = n;
                timevalue.text = (timeBar.fillAmount * Daymax).ToString("F0");

            }
            else
            {
                NightText.SetActive(true);
                DayText.SetActive(false);
                //Time.timeScale = 0; 
                nightTime -= Time.deltaTime;
                timeBar.fillAmount = nightTime / Nightmax;
                timevalue.text = (timeBar.fillAmount * Nightmax).ToString("F0");

                if (nightTime <= 0)
                {
                    dayTime = Daymax;

                }



            }

        }

    }

    public void playButton()
    {
        //if (button == 0)
       // {
            timerActive = !timerActive;
            playButtonTxt.text = timerActive ? "Pause" : "Play";
       // }

    }


}

