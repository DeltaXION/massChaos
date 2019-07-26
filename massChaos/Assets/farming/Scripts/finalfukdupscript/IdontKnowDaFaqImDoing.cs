using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IdontKnowDaFaqImDoing
{
    private GameObject gameObject;
    private int buildTick;
    private int buildTickMax;
    private bool isConstructing;

    public IdontKnowDaFaqImDoing(Vector3 position, int ticksToConstruct)
    {
        buildTick = 0;
        buildTickMax = ticksToConstruct;
        isConstructing = true;
        System.EventHandler<TickTimerScript.onTickEventArgs> TickTimerScript_OnTick = null;
        TickTimerScript.OnTick += TickTimerScript_OnTick;
    }

    private void TickTimerScript_OnClick(object sender,TickTimerScript.onTickEventArgs e)
    {
        if (isConstructing)
        {
            buildTick += 1;
            if (buildTick >= buildTickMax)
            {
                isConstructing = false;
            }
        }
    }

}
