using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectWood : MonoBehaviour
{
    public Text woods;

    public int woodCount;

    // Start is called before the first frame update


    public void OnItemClicked()
{       
        //if(Input.GetMouseButtonDown(0))
        //{  
            //  woodCount = woodCount + 5;
            //     Debug.Log(woodCount);
            //     woods = GameObject.Find("woodCount").GetComponent<Text>();
             //    woods.text = woodCount.ToString();
            ResourceManager.addWood(5);
            Debug.Log(ResourceManager.wood);


        //}


    }
}