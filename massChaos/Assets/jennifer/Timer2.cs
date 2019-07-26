using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer2 : MonoBehaviour
{
   
    public Image SeasonMeter; // the season meter bar 
    public float calen;     
    public float datees;        // calculated date in float.
    public GameObject SpringUI;
    public GameObject SummerUI;
    public GameObject AutumnUI;
    public GameObject WinterUI;
    public float Daymax = 150;
    public float Nightmax = 150;
    public float dayTime;
    public float nightTime;
    public GameObject DayText;
    public GameObject NightText;
    public GameObject date;
    public float seasonDays = 25;
    public GameObject seasonName;
    public float startDay = 1;
    public float year;
    public float time;
    public bool inDungeon = false;
    public bool timerActive = false;
    public bool skipActive = false;
    public bool skipX2Active = false;
    public float displayDate;
    public float skipTime;  // how many seconds will be skipped ;

    public float travelTimeSeconds = 450;
    public Text timevalue; // day/night time bar:
    public Text playButtonTxt;
    public Text skipButtonTxt;
    public Text skipX2ButtonTxt;
    public Text DungeonButtonTxt ;
    public float wholeDaySeconds = 300;
    static public bool harshWeather = false;
    public bool harshWeathers = false;  // only for refering to the Day/Night color script.
    Image timeBar;
    public float season = 1;
    public float timeOfSeason;
    public float SeasonSeconds;
    public GameObject player;
    public float playerSpeed = 8;
    float springTimer;
    public float timeOfDay;
    static public bool itsDay;
    public GameObject exitDuBut;
    float test = 0;

    private GameObject BaseHealthObj;

    void Start()
    {
        BaseHealthObj = GameObject.Find("baseValue");
        playerSpeed = 8;

        GameObject.DontDestroyOnLoad(this.gameObject);
        DayText.SetActive(true);
        NightText.SetActive(false);
        timeBar = GetComponent<Image>();
        //  dayTime = Daymax;

        date = GameObject.Find("date");


        Daymax = wholeDaySeconds / 2;
        Nightmax = wholeDaySeconds / 2;
        SeasonSeconds = wholeDaySeconds * seasonDays;
        SeasonSeconds = 7500;

        WinterUI.SetActive(false);
        SummerUI.SetActive(false);
        AutumnUI.SetActive(false);
        SpringUI.SetActive(false);
        exitDuBut.SetActive(false);
    }

    void Update()
    {
        
        playerSpeed = player.GetComponent<BB_BasicControls>().speed;
       
        GameObject go = GameObject.Find("Time_Canvas");

        // ONGOING TIME - TIMER : DAY : SEASON :-
        if (timerActive)
        {
            playButtonTxt.text = "Pause";
            time += Time.deltaTime;
            timeOfDay += Time.deltaTime;
            timeOfSeason += Time.deltaTime;

        }

        //  DISPLAY DATE - CALCULATING: DAYS

        calen = time / wholeDaySeconds;
        datees = Mathf.FloorToInt(calen + startDay);
        displayDate = Mathf.FloorToInt(datees);
        date.GetComponent<Text>().text = "Day " + displayDate.ToString();

        // SKIP X1
        if (skipActive)
        {
            time = time + skipTime;
            timeOfDay = timeOfDay + skipTime;
            timeOfSeason = timeOfSeason + skipTime;
            skipX2Active = false;
            playerSpeed = 50;
            if (!skipX2Active)
            { skipX2ButtonTxt.text = "FFX2"; }

        }
        
        // SKIP X2
        if (skipX2Active)
        {
            time = time + skipTime * 2;
            timeOfDay = timeOfDay + skipTime * 2;
            timeOfSeason = timeOfSeason + skipTime * 2;
            skipActive = false;
            playerSpeed = 250;
            if (!skipActive)
            { skipButtonTxt.text = "FF"; }


        }
        // PLAYER SPEED
        if(!skipX2Active && !skipActive)
        {
            playerSpeed = 8;
        }

        // SHREEYA Additions :SHREEYA :- MINI BOSS DAMAGE

        if (displayDate == 100)
        {
            if (timeOfDay >= 20 && timeOfDay <=21)
            {
                Debug.Log("dstroy");
                Damage();
            }
           
           // test = test + 1;
           // Debug.Log(test);
        }

        if (displayDate == 100)
        {
           BaseDamage.MiniBDamage();
        }


        // SPLITTING DAYS INTO :: YEARS AND DAYS :-

        if (displayDate > 100)
        {
            year = Mathf.FloorToInt(displayDate / 100);
            displayDate = displayDate - 100;
            date.GetComponent<Text>().text = "Year " + year + "  Day " + displayDate.ToString();
        }

        // SEASON - NO OF SEASONS PASSED :
        if (timeOfSeason >= SeasonSeconds)
        {
            season += 1;
            timeOfSeason -= SeasonSeconds;
        }

        // DAYS RESET TO 1 IF YEAR > 0
        if (timeOfDay >= wholeDaySeconds)
        {
            timeOfDay -= wholeDaySeconds;

        }

        // DAY :-
        if (timeOfDay <= wholeDaySeconds / 2)
        {
            if (timeOfDay >= 20 && timeOfDay <= 21)
            {
                BaseHealthObj.GetComponent<BaseHealth>().BaseHealthCalc();
            }

            DayText.SetActive(true);
            NightText.SetActive(false);
            timeBar.fillAmount = timeOfDay / Daymax;
            timevalue.text = (timeBar.fillAmount * Daymax).ToString("F0");
            itsDay = true;

        }
        // NIGHT :- 
        if (timeOfDay >= wholeDaySeconds / 2)
        { // activate the code below once merged - NIYATI.

            if (timeOfDay >= 160 && timeOfDay <= 161)
            {
                CommonHappinessIndex.TimeToEat();
                CommonHappinessIndex.RecaclculateHappinessIndex();
                GameObject.Find("HappinessIndex Variant").GetComponent<FollowerLeaving>().updateFollowerLeaving();
            }

            NightText.SetActive(true);
            DayText.SetActive(false);
            float half = timeOfDay / 2;
            timeBar.fillAmount = half / Nightmax;
            timevalue.text = (timeBar.fillAmount * Nightmax).ToString("F0");
            itsDay = false;
        }
        // SPRING :-
        if (displayDate <= 25)
        {
            SeasonMeter.fillAmount = timeOfSeason / SeasonSeconds; // SEASON METER.

            seasonName.GetComponent<Text>().text = "Spring";
            Spring();
            if (harshWeather)
            {
                seasonName.GetComponent<Text>().text = "Spring - harsh";
            }
        }
        else SpringUI.SetActive(false);

        // SUMMER :-
        if (displayDate > 25)
        {
            SeasonMeter.fillAmount = timeOfSeason / SeasonSeconds;// SEASON METER.
            seasonName.GetComponent<Text>().text = "Summer";
            Summer();
            if (harshWeather)
            {
                seasonName.GetComponent<Text>().text = "Summer - harsh";
            }
        }
        else SummerUI.SetActive(false);

        // AUTUMN :-
        if (displayDate > 50)
        {

            SeasonMeter.fillAmount = timeOfSeason / SeasonSeconds;// SEASON METER.
            seasonName.GetComponent<Text>().text = "Autumn";
            Autumn();
            if (harshWeather)
            {
                seasonName.GetComponent<Text>().text = "Autumn- harsh";
            }
        }
        else AutumnUI.SetActive(false);

        // WINTER:-
        if (displayDate > 75)
        {
            SeasonMeter.fillAmount = timeOfSeason / SeasonSeconds;// SEASON METER.
            seasonName.GetComponent<Text>().text = "Winter";
            Winter();
            if (harshWeather)
            {
                seasonName.GetComponent<Text>().text = "Winter- harsh";
            }
        }
        else WinterUI.SetActive(false);

    }

    public void Damage()
    {
        test = test + 1;
        Debug.Log(test + "test");
    }

    // SPRING FUNCTOIN :
    public void Spring()
    {
        springTimer += displayDate;
        SpringUI.SetActive(true);
        if (displayDate >= 10)
        {
            if (displayDate == 10)
            {// SHREEYA :- HARSH DAMAGE - 1DAY
                if (timeOfDay >= 20 && timeOfDay <= 21)
                { 
                      BaseDamage.WeatherDamage();
                                    
                }
               

            }


                harshWeather = true;
            harshWeathers = true;
            if (displayDate >= 15)
            {
                harshWeather = false;
                harshWeathers = false;
            }
            }
        
    }

    // SUMMER FUNCTION :
    public void Summer()
    {
        SummerUI.SetActive(true);
        if (displayDate >= 37)
        {
            if (displayDate == 37)
            {// SHREEYA :- HARSH DAMAGE - 1DAY
                if (timeOfDay >= 20 && timeOfDay <= 21)
                {  BaseDamage.WeatherDamage();
                  
                }
                  
            }
            harshWeather = true;
            harshWeathers = true;
            if (displayDate >= 42)
            {
                harshWeather = false;
                harshWeathers = false;
            }
        }

    }

    // AUTUMNFUNCTION :
    public void Autumn()
    {

        AutumnUI.SetActive(true);
        if (displayDate >= 62)
        {
            if(displayDate == 62)
            {
                // SHREEYA :- HARSH DAMAGE - 1DAY
                if (timeOfDay >= 20 && timeOfDay <= 21)
                {  BaseDamage.WeatherDamage();
                   
                  
                }

            }

            harshWeather = true;
            harshWeathers = true;
            if (displayDate >= 70)
            {
                harshWeather = false;
                harshWeathers = false;
            }
        }

    }
    // WINTER FUNCTION:
    public void Winter()

    {
        WinterUI.SetActive(true);
        if (displayDate >= 85)
        {
            if (displayDate == 85)
            {
                // SHREEYA :- HARSH DAMAGE - 1DAY
                if (timeOfDay >= 20 && timeOfDay <= 21)
                { BaseDamage.WeatherDamage();
                    
                   
                }

            }

            harshWeather = true;
            harshWeathers = true;
            if (displayDate >= 92)
            {
                harshWeather = false;
                harshWeathers = false;
            }
        }

    }
    // PLAY/PAUSE BUTTON :-
    public void playButton()
    {
        timerActive = !timerActive;

        if (timerActive)
        { playButtonTxt.text =  "Pause" ; }
        if (!timerActive)
        { playButtonTxt.text =  "Play"; }
    }

    // SKIP BUTTON :-

    public void skipButton()
    {

        skipActive = !skipActive;
       // skipButtonTxt.text = skipActive ? "Stop FF" : "FF";
        if (skipActive)
        {
            skipX2Active = false;
            skipButtonTxt.text = "Stop";

        }
        if (!skipActive)
        {
            skipButtonTxt.text = "FF";

        }

    }

    // SKIP X 2 BUTTON :-

    public void skipX2Button()
    {

        skipX2Active = !skipX2Active;
      //  skipX2ButtonTxt.text = skipX2Active ? "Stop" : "FFX2";
        if (skipX2Active)
        {
            skipActive = false;
            skipX2ButtonTxt.text = "Stop";

        }
        if (!skipX2Active)
        {
            skipX2ButtonTxt.text = "FFX2";

        }


    }

    // ENTER DUNGEON - NEXT FLOOR BUTTON :-

    public void goToDungeonButton()

    {
        if (!skipActive && !skipX2Active)
        {
            timerActive = false;
        inDungeon = true;
            if(inDungeon)
            {
                exitDuBut.SetActive(true);
            }
           
        DungeonButtonTxt.text = "Next Floor";
        time = time + travelTimeSeconds;
        timeOfDay = timeOfDay + travelTimeSeconds;
        timeOfSeason = timeOfSeason + travelTimeSeconds;
        }

    }
 
    // EXIT DUNGEON BUTTON :-
    public void exitDungeon()
    {
        if (inDungeon)
        {
            DungeonButtonTxt.text = "Dungeon";
            timerActive = true;
            inDungeon = false;
            time = time + travelTimeSeconds;
            timeOfDay = timeOfDay + travelTimeSeconds;
            timeOfSeason = timeOfSeason + travelTimeSeconds;
            exitDuBut.SetActive(false);


        }



    }

}
