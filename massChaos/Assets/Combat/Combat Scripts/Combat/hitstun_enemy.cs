using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitstun_enemy : MonoBehaviour
{
    public Behaviour move;
    public float tempStun = 1f; //stores temp stun value
    public float tempSeconds = 1f;  //stores temp time
    public bool touche = false;
    public float StunDuration= 0f;
    // Start is called before the first frame update
    void Start()
    {
        StunDuration = tempStun;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "stun")
        {
            move.enabled = false;
            touche = true;
            Debug.Log("collision detected");
           
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
