using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIData : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float fadeTIme;
    public bool displayInfo;
    public GameObject forestUI;
    public bool click;
    // Start is called before the first frame update
    void Start()
    {
        displayInfo = false;
        click = false;
        forestUI.SetActive(displayInfo);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        displayInfo = true;
        //Debug.Log("Mouse");
        FadeInfo();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        displayInfo = false;
        click = false;
        FadeInfo();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        displayInfo = false;
        click = true;
        FadeInfo();
    }
    void FadeInfo()
    {   if (click == false)
        forestUI.SetActive(displayInfo);
    }

}
