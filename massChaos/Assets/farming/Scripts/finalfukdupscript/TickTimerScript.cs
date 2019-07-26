using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using CollabProxy;

public class TickTimerScript : MonoBehaviour
{
    public class onTickEventArgs : EventArgs
    {
        public int tick;
    }
    public static event EventHandler<onTickEventArgs> OnTick;
    private const float TICK_TIMER_MAX = .2f;
    private int tick;
    private float tickTimer;


    private void Awake()
    {
        tick = 0;
    }

    private void Update()
    {
        tickTimer += Time.deltaTime;
        if (tickTimer>=TICK_TIMER_MAX)
        {
            tickTimer -= TICK_TIMER_MAX;
            tick++;
            if (OnTick != null) OnTick(this,new onTickEventArgs { tick = tick });
            Debug.Log("tick" + tick);
            
        }
    }
}
