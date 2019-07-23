using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ApplicantAccept : MonoBehaviour, ISelectHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        Debug.Log("Yesss");

    }

    public void OnSelect(BaseEventData eventData)
    {
        string name = transform.parent.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().ToString();
        Debug.Log(name);
    }
}
