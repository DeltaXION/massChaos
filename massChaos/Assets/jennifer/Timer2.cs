using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer2 : MonoBehaviour
{
    //public GameObject art;
    float button;
    public float calen;
    public float datees;
    
    public float Daymax ;
    public float Nightmax;
    public static float dayTime;
    public static float nightTime;
    public GameObject DayText;
    public GameObject NightText;
    public GameObject date;
  
   
  //  public float seasonDays;
  //  public float season;
    public GameObject seasonName;
    public float startDay;
  //  public float travel;
    public float year;
    public float time;
    public bool inDungeon = false;
  //  public float travelSkip;
    public bool timerActive = false;
    public bool skipActive = false;
    public float displayDate;
    public float skipTime ;
    public float travelTimeSeconds;
    public Text timevalue;
    public Text playButtonTxt;
    public Text skipButtonTxt;
    public float wholeDaySeconds;
    public bool harshWeather = false;
    Image timeBar;
    bool addYear;

    public GameObject player;
    float playerSpeed;
    float springTimer;
    public float timeOfDay;


    void Start()
    {
        DayText.SetActive(true);
        NightText.SetActive(false);
        timeBar = GetComponent<Image>();
        dayTime = Daymax;
    
        date = GameObject.Find("date");
       
      
        Daymax = wholeDaySeconds / 2;
        Nightmax = wholeDaySeconds/2;

        



    }



    void Update()
    {

     


        if (timerActive)
        {
            //Debug.Log("timer is active");
            time += Time.deltaTime;
            timeOfDay += Time.deltaTime;

        }
            if (skipActive)
            {
                time = time + skipTime;
                timeOfDay = timeOfDay + skipTime;
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
        


        if (timeOfDay >= wholeDaySeconds)
            {
                timeOfDay -= wholeDaySeconds;
                
                Debug.Log("day restart");
            }
      

        if (timeOfDay <= wholeDaySeconds / 2)
                {
                    Debug.Log("its day");
                    DayText.SetActive(true);
                    NightText.SetActive(false);
                    timeBar.fillAmount = timeOfDay/ Daymax;
                    timevalue.text = (timeBar.fillAmount * Daymax).ToString("F0");
                }
                if (timeOfDay >= wholeDaySeconds / 2)
                {
                    Debug.Log("its night");
                    NightText.SetActive(true);
                    DayText.SetActive(false);
                float half = timeOfDay / 2;
                    timeBar.fillAmount = half / Nightmax;
                    timevalue.text = (timeBar.fillAmount * Nightmax).ToString("F0");
                }

                if (displayDate <= 25)
                    {
                        seasonName.GetComponent<Text>().text = "Spring";
                         Spring();
                    if (harshWeather)
                    {
                        seasonName.GetComponent<Text>().text = "Spring - harsh";
                    }
                    }

                if (displayDate > 25)
                {
                    seasonName.GetComponent<Text>().text = "Summer";
                    Summer();
                    if (harshWeather)
                    {
                        seasonName.GetComponent<Text>().text = "Summer - harsh";
                    }
                }
                if (displayDate > 50)
                {
                    seasonName.GetComponent<Text>().text = "Autumn";
                    Autumn();
                    if (harshWeather)
                    {
                        seasonName.GetComponent<Text>().text = "Autumn- harsh";
                    }
                }

                if (displayDate >75)
                {
                    seasonName.GetComponent<Text>().text = "Winter";
                   Winter();
                    if (harshWeather)
                    {
                        seasonName.GetComponent<Text>().text = "Winter- harsh";
                    }
                }




    }

    public void Spring()
    {
            springTimer += displayDate;
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
