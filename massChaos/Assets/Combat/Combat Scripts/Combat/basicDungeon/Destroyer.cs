using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("dungeonPlayer") && !other.gameObject.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
        }
    }

}
