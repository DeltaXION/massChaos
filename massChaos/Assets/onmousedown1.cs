﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onmousedown1 : MonoBehaviour
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
        Debug.Log("onmoousedown");
        FarmList.a.SetActive(true);
    }
}
