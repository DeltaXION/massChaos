using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectStone : MonoBehaviour
{
    public Text stone;
    // Start is called before the first frame update
    public void OnItemClicked()
    {

        ResourceManager.addStone(SMTimer.stoneCnt);
        Debug.Log(ResourceManager.stone);
        SMTimer.stoneCnt = 0;
        stone = GameObject.Find("stnnum").GetComponent<Text>();
        stone.text = SMTimer.stoneCnt.ToString();


        //}


    }

}
