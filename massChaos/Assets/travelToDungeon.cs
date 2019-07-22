using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class travelToDungeon : MonoBehaviour
{
    public GameObject enterthedungeon;
    public bool entered = false;
    public float checkDungeonEntry = 0;


    // Start is called before the first frame update
    void Start()
    {
        //  entered = false;
        enterthedungeon.gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            entered = true;
            Debug.Log("you have entered dungeon");
            // enterDungeonText = true;
            enterthedungeon.gameObject.SetActive(true);
            checkDungeonEntry = 1;
            Debug.Log("check dungeon entry = 1");



        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        enterthedungeon.gameObject.SetActive(false);
        checkDungeonEntry = 0;
        entered = false;

    }




}
