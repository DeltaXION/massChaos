using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Iron : MonoBehaviour
{
    public Text iron;
    public float fadeTIme;
    public bool displayInfo;
    public GameObject ironMUI;

    // Start is called before the first frame update
    void Start()
    {
        displayInfo = false;
        ironMUI.SetActive(displayInfo);
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
        iron = GameObject.Find("ironnum").GetComponent<Text>();
        iron.text = IMTimer.ironCnt.ToString();
    }
    private void OnMouseExit()
    {
        displayInfo = false;
        FadeInfo();
    }
    void FadeInfo()
    {
        ironMUI.SetActive(displayInfo);
    }

}


