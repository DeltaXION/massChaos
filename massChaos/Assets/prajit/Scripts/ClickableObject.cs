using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour
{
    Item item;

    void OnGUI()
    {
        Debug.Log(item);
        Event e = Event.current;
        if (e.button == 0 && e.isMouse)
        {
            Debug.Log("Left Click");
        }
        else if (e.button == 1)
        {
            Debug.Log("Right Click");
            if (InventorySlot.current !=null)
            {
               InventorySlot.current.UsePrimary();
            }

        }
        else if (e.button == 2)
        {
            Debug.Log("Middle Click");
        }
        else if (e.button > 2)
        {
            Debug.Log("Another button in the mouse clicked");
        }
    }
}
    
