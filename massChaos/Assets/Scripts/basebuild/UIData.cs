using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIData : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float fadeTIme;
    public bool displayInfo;
    public GameObject forestUI;
    // Start is called before the first frame update
    void Start()
    {
        displayInfo = false;
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
        FadeInfo();
    }
    void FadeInfo()
    {
        forestUI.SetActive(displayInfo);
    }

}
