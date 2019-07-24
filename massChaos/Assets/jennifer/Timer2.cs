using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer2 : MonoBehaviour
{
    float button;
    public Image SeasonMeter;
    public float calen;
    public float datees;
    public GameObject SpringUI;
    public GameObject SummerUI;
    public GameObject AutumnUI;
    public GameObject WinterUI;
    public float Daymax ;
    public float Nightmax;
    public  float dayTime;
    public  float nightTime;
    public GameObject DayText;
    public GameObject NightText;
    public GameObject date;
    public float seasonDays = 25;
    public GameObject seasonName;
    public float startDay;
    public float year;
    public float time;
    public bool inDungeon = false;
    public bool timerActive = false;
    public bool skipActive = false;
    public float displayDate;
    public float skipTime ;
    public float travelTimeSeconds;
    public Text timevalue;
    public Text playButtonTxt;
    public Text skipButtonTxt;
    public float wholeDaySeconds;
    static public bool harshWeather = false;
    Image timeBar;
    public float season = 1;
    public float timeOfSeason;
    public float SeasonSeconds;
    public GameObject player;
    float playerSpeed;
    float springTimer;
    public float timeOfDay;
    static public bool itsDay;

   

    void Start()
    {
       GameObject. DontDestroyOnLoad(this.gameObject);
        DayText.SetActive(true);
        NightText.SetActive(false);
        timeBar = GetComponent<Image>();
      //  dayTime = Daymax;
    
        date = GameObject.Find("date");
    
      
        Daymax = wholeDaySeconds / 2;
        Nightmax = wholeDaySeconds/2;
       SeasonSeconds = wholeDaySeconds * seasonDays;
        SeasonSeconds = 7500;

        WinterUI.SetActive(false);
        SummerUI.SetActive(false);
        AutumnUI.SetActive(false);
        SpringUI.SetActive(false);
    }

    void Update()
    {
        GameObject go = GameObject.Find("Time_Canvas"); 

        if (timerActive)
        { 
            //Debug.Log("timer is active");
            time += Time.deltaTime;
            timeOfDay += Time.deltaTime;
            timeOfSeason += Time.deltaTime;

        }
            if (skipActive)
            {
                time = time + skipTime;
                timeOfDay = timeOfDay + skipTime;
                 timeOfSeason = timeOfSeason + skipTime;
            }
            calen = time / wholeDaySeconds;
            datees = Mathf.FloorToInt(calen + startDay);
            displayDate = Mathf.FloorToInt(datees);
            date.GetComponent<Text>().text = "Day " +displayDate.ToString();

        if( displayDate > 100)
        {
            year = Mathf.FloorToInt(displayDate / 100);

            displayDate = displayDate - 100;
          
            date.GetComponent<Text>().text = "Year "+ year + "  Day " + displayDate.ToString();
        }

        if (timeOfSeason >= SeasonSeconds)
        {
            season += 1;
            timeOfSeason -= SeasonSeconds;
        }
       

        if (timeOfDay >= wholeDaySeconds)
            {
                timeOfDay -= wholeDaySeconds;
                
              //  Debug.Log("day restart");
            }
      

        if (timeOfDay <= wholeDaySeconds / 2)
                {
                   // Debug.Log("its day");
                    DayText.SetActive(true);
                    NightText.SetActive(false);
                    timeBar.fillAmount = timeOfDay/ Daymax;
                    timevalue.text = (timeBar.fillAmount * Daymax).ToString("F0");
            itsDay = true;
            
                }
                if (timeOfDay >= wholeDaySeconds / 2)
                {
                   // Debug.Log("its night");
                    NightText.SetActive(true);
                    DayText.SetActive(false);
                float half = timeOfDay / 2;
                    timeBar.fillAmount = half / Nightmax;
                    timevalue.text = (timeBar.fillAmount * Nightmax).ToString("F0");
            itsDay = false;
                }

        if (displayDate <= 25)
        {
            SeasonMeter.fillAmount = timeOfSeason / SeasonSeconds;

            seasonName.GetComponent<Text>().text = "Spring";
            Spring();
            if (harshWeather)
            {
                seasonName.GetComponent<Text>().text = "Spring - harsh";
            }
        }
        else SpringUI.SetActive(false);

                if (displayDate > 25)
                {
                    SeasonMeter.fillAmount = timeOfSeason / SeasonSeconds;
                    seasonName.GetComponent<Text>().text = "Summer";
                    Summer();
                    if (harshWeather)
                    {
                        seasonName.GetComponent<Text>().text = "Summer - harsh";
                    }
        }
        else SummerUI.SetActive(false);
        if (displayDate > 50)
                {

                     SeasonMeter.fillAmount = timeOfSeason / SeasonSeconds;
                    seasonName.GetComponent<Text>().text = "Autumn";
                    Autumn();
                    if (harshWeather)
                    {
                        seasonName.GetComponent<Text>().text = "Autumn- harsh";
                    }
        }
        else AutumnUI.SetActive(false);

        if (displayDate >75)
        {
                     SeasonMeter.fillAmount = timeOfSeason / SeasonSeconds;
                     seasonName.GetComponent<Text>().text = "Winter";
                   Winter();
                    if (harshWeather)
                    {
                        seasonName.GetComponent<Text>().text = "Winter- harsh";
                    }
        }
        else WinterUI.SetActive(false);

    }
    
    public void Spring()
    {
            springTimer += displayDate;
        SpringUI.SetActive(true);
        if  (displayDate >= 10 )
        {// add 1 damage function;
            harshWeather = true;
            if(displayDate >=15)
            {
                harshWeather = false;
            }
        }
          
    }
    public void Summer()
    {
        SummerUI.SetActive(true);
        if (displayDate >= 37)
        { // add 1 damage function;
            harshWeather = true;
            if (displayDate >= 42)
            {
                harshWeather = false;
            }
        }

    }
    public void Autumn()
    {

        AutumnUI.SetActive(true);
        if (displayDate >= 62)
        {// add 1 damage function;
            harshWeather = true;
            if (displayDate >= 70)
            {
                harshWeather = false;
            }
        }

    }
    public void Winter()

    {
        WinterUI.SetActive(true);
        if (displayDate >= 85)
        {// add 1 damage function;
            harshWeather = true;
            if (displayDate >= 92)
            {
                harshWeather = false;
            }
        }

    }

    public void playButton()
    {
        
        timerActive = !timerActive;
        playButtonTxt.text = timerActive ? "Pause" : "Play";


    } 
    public void skipButton()
    {
        
        skipActive = !skipActive;
        skipButtonTxt.text = skipActive ? "Stop Skip" : "Skip";
       
    }
    public void goToDungeonButton()

   {if (!skipActive)
        {
            timerActive = false;
            inDungeon = true;
            time = time + travelTimeSeconds;
            timeOfDay = timeOfDay + travelTimeSeconds;
        }
               
     }
     
    public void exitDungeon()
    {if (inDungeon)
        {
           // timerActive = true;
            playButton();
        }
   


    }

}
