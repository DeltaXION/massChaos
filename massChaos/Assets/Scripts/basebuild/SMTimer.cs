using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SMTimer : MonoBehaviour
{
    public Image timer;
    public Text stone;
    public static float maxTime = 25;
    public static bool done = false;
    public static float timeLeft;
    public static int stoneCnt = 1;
    Timer2 timer2;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = maxTime;
        stone = GameObject.Find("stnnum").GetComponent<Text>();
        stone.text = stoneCnt.ToString();
    }

    // Update is called once per frame
    //public static void TimeFill(float n)
    //{
    //    maxTime = n;
    //    timeLeft = maxTime;


    //}
    public void Update()
    {
        timer2 = FindObjectOfType<Timer2>();

        if (timer2.timeOfDay < 150 && !Timer2.harshWeather)
        {
            maxTime = 25;
        }
        else
        {
            maxTime = 35;
        }
        if (timeLeft > 0 && done == false)
        {
            timeLeft -= Time.deltaTime;
            timer.fillAmount = timeLeft / maxTime;


        }
        else
        {
            done = true;
            //Debug.Log("LinTimer");
            //woods = GameObject.Find("woodnum").GetComponent<Text>();
            stoneCnt = stoneCnt + 1;
            //T.woodCount = woodCnt;
            //woods.text = woodCnt.ToString();
            timeLeft = maxTime;
            done = false;
        }

    }
}
