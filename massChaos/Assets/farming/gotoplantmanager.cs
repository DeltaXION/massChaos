using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotoplantmanager : MonoBehaviour
{
    public GameObject hoverimage, FarmMenu;
    public bool IsMouseOverHoverimage = false;

    public void Start()
    {
        hoverimage.SetActive(false);
    }

    private void OnMouseOver()
    {
        //if (gameObject.active == true)
        IsMouseOverHoverimage = true;
    }
    private void OnMouseExit()
    {
        IsMouseOverHoverimage = false;
    }

    public void OnMouseDown()
    {
        //hoverimage.SetActive(true);
        FarmMenu.SetActive(true);
        Debug.Log("Click Works");
    }




}
