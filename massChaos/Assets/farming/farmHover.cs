using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class farmHover : MonoBehaviour

{
    public GameObject hoverimage;
    private bool IsMouseStillOverImage, MakeImageStayCoroutineisRunning = false;

    public void Start()

    {
        hoverimage.SetActive(false);
    }

    public void OnMouseOver()
    {
        IsMouseStillOverImage = true;
        if (MakeImageStayCoroutineisRunning == false)
            StartCoroutine(MakeImageStay());

    }


    public void OnMouseExit()
    {
        IsMouseStillOverImage = false;

    }

    IEnumerator MakeImageStay()
    {
        MakeImageStayCoroutineisRunning = true;
    Start:
        hoverimage.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        if (IsMouseStillOverImage == false)
            if (GameObject.Find("farm hover screen") == true)
                if (GameObject.Find("farm hover screen").GetComponent<gotoplantmanager>().IsMouseOverHoverimage == true)
                    goto Start;
                else
                    hoverimage.SetActive(false);
            else
                goto Start;



        MakeImageStayCoroutineisRunning = false;
    }

}