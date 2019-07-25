using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trees : MonoBehaviour
{
    public Text woods;
    public float fadeTIme;
    public bool displayInfo;
    public GameObject forestUI;
 
    // Start is called before the first frame update
    void Start()
    {
        displayInfo = false;
        forestUI.SetActive(displayInfo);
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
        woods = GameObject.Find("woodnum").GetComponent<Text>();
        woods.text = LinTimer.woodCnt.ToString();
    }
    private void OnMouseExit()
    {
        displayInfo = false;
        FadeInfo();
    }
    void FadeInfo()
    {
            forestUI.SetActive (displayInfo);
    }

}
