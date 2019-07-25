using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stone : MonoBehaviour
{
    public Text stone;
    public float fadeTIme;
    public bool displayInfo;
    public GameObject stoneMUI;

    // Start is called before the first frame update
    void Start()
    {
        displayInfo = false;
        stoneMUI.SetActive(displayInfo);
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnMouseOver()
    {//display wood collection UI
        displayInfo = true;
        //Debug.Log("Mouse");
        FadeInfo();
        stone = GameObject.Find("stnnum").GetComponent<Text>();
        stone.text = SMTimer.stoneCnt.ToString();
    }
    private void OnMouseExit()
    {
        displayInfo = false;
        FadeInfo();
    }
    void FadeInfo()
    {
        stoneMUI.SetActive(displayInfo);
    }

}
