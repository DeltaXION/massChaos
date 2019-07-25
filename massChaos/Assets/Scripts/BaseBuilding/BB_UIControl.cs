using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BB_UIControl : MonoBehaviour
{
    [SerializeField] GameObject Statbar;
    [SerializeField] GameObject AssignList;

    HouseDragHandler itemDragHandler;

    // Start is called before the first frame update
    void Start()
    {
        Statbar.SetActive(false);
        NPCAssignListEnable();
    }

      // Update is called once per frame
    void Update()
    {
        statVisibilityCheck(); // Visibility toggle for stat bar      
    }

    private void NPCAssignListEnable()
    {
        itemDragHandler = FindObjectOfType<HouseDragHandler>();

        if (itemDragHandler.displayNPCassignList)
        {
            AssignList.SetActive(true);
        }
    }

    private void statVisibilityCheck()
    {
        if (Input.GetMouseButtonDown(0) && Statbar.activeSelf)
        {
            // To Check if object hit any collider
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider == null)
            {
                Statbar.SetActive(false);

                itemDragHandler.displayNPCassignList = false;
                AssignList.SetActive(false);
                //Debug.Log(hit.collider.gameObject.name);
                //if (hit.collider.gameObject.name == "StatsUI")
                //{
                //    Debug.Log("Nested StatsUI");
                //    Statbar.SetActive(true);
                //}

            }
        }
    }

    public void OnMouseUp()
    {
        
        if (Statbar.activeSelf == false)
        {
           Statbar.SetActive(true);
           itemDragHandler.displayNPCassignList = false;
           AssignList.SetActive(false);
        }

    }

  

}
