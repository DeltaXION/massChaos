using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class play_pause_button : MonoBehaviour
{
    public float timeStart;
    public Text textBox;
    public bool TimerActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerActive)
        {

        }
    }
    public void timerButton()
    {
        TimerActive = !TimerActive;
    }
}
