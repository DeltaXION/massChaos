using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectIron : MonoBehaviour
{
    public Text iron;
    public void OnItemClicked()
    {

        ResourceManager.addIron(IMTimer.ironCnt);
        Debug.Log(ResourceManager.iron);
        IMTimer.ironCnt = 0;
        iron = GameObject.Find("ironnum").GetComponent<Text>();
        iron.text = IMTimer.ironCnt.ToString();

        //}


    }

}
