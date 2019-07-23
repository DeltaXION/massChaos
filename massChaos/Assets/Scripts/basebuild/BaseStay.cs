using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStay : MonoBehaviour
{
    public GameObject DungeonUI;
    public void OnItemClicked()
    {
        DungeonUI.SetActive(false);
    }

}