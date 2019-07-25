using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectWood : MonoBehaviour
{
    public Text woods;




    public void OnItemClicked()
{       
        //if(Input.GetMouseButtonDown(0))
        //{  
            //  woodCount = woodCount + 5;
            //     Debug.Log(woodCount);

            ResourceManager.addWood(LinTimer.woodCnt);
            Debug.Log(ResourceManager.wood);
            LinTimer.woodCnt = 0;
        woods = GameObject.Find("woodnum").GetComponent<Text>();
        woods.text = LinTimer.woodCnt.ToString();


        //}


    }
}