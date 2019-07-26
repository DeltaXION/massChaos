using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        //new IdontKnowDaFaqImDoing(Vector3.zero); 
        TickTimerScript.OnTick += delegate (object sender, TickTimerScript.onTickEventArgs e)
          {
              Debug.Log("tick" + e.tick);
          };
    }

    // Update is called once per frame
  private  void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //new IdontKnowDaFaqImDoing (50);
        }
    }
}
