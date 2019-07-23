using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BB_DragandDrop : MonoBehaviour
{
    [SerializeField] GameObject house;
    [SerializeField] GameObject farm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DragandDrop();
    }

    private void DragandDrop()
    {
        if (EventSystem.current.currentSelectedGameObject.name == "house")
        {
            //
        }
    }

    public void ReturnGameButtonName()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
    }

    
}
