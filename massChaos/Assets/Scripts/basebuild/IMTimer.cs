using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IMTimer : MonoBehaviour
{
    public Image timer;
    public Text iron;
    public static float maxTime = 30;
    public static bool done = false;
    public static float timeLeft;
    public static int ironCnt = 1;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = maxTime;
        iron = GameObject.Find("ironnum").GetComponent<Text>();
        iron.text = ironCnt.ToString();
    }

    // Update is called once per frame
    //public static void TimeFill(float n)
    //{
    //    maxTime = n;
    //    timeLeft = maxTime;


    //}
    public void Update()
    {
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
            ironCnt = ironCnt + 1;
            //T.woodCount = woodCnt;
            //woods.text = woodCnt.ToString();
            timeLeft = maxTime;
            done = false;
        }

    }
}
