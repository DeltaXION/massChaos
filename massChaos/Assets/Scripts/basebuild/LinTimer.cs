using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinTimer : MonoBehaviour
{
    public Image timer;
    public Text woods;
    public static float maxTime = 20;
    public static bool done = false;
    public static float timeLeft;
    public static int woodCnt = 5;  
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = maxTime;
        woods = GameObject.Find("woodnum").GetComponent<Text>();
        woods.text = woodCnt.ToString();
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
            Debug.Log("LinTimer");
            //woods = GameObject.Find("woodnum").GetComponent<Text>();
            woodCnt = woodCnt + 5;
            //T.woodCount = woodCnt;
            //woods.text = woodCnt.ToString();
            timeLeft = maxTime;
            done = false;
        }
      
    }
}
