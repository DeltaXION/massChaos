using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEntry : MonoBehaviour
{
    public GameObject DungeonUI;
    // Start is called before the first frame update
    public void OnMouseDown()
    {

            DungeonUI.SetActive(true);
            Debug.Log("Dungeon");



    }
}
