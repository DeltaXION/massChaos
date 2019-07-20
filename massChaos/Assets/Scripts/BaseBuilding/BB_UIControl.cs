using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_UIControl : MonoBehaviour
{
    [SerializeField] GameObject Statbar;
    
    // Start is called before the first frame update
    void Start()
    {
        Statbar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        statVisibilityCheck(); // Visibility toggle for stat bar
    }

    private void statVisibilityCheck()
    {
        if ((Input.GetMouseButtonDown(0)) && Statbar.activeSelf)
        {
            Statbar.SetActive(false);
        }
    }

    public void OnMouseUp()
    {
        
        if (Statbar.activeSelf == false)
        {
           Statbar.SetActive(true);
        }

    }

}
